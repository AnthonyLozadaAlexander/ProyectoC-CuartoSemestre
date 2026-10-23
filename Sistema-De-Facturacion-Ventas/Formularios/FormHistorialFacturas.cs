using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_De_Facturacion_Ventas.Datos;
using Sistema_De_Facturacion_Ventas.Modelos;

namespace Sistema_De_Facturacion_Ventas.Formularios {
    public partial class FormHistorialFacturas : Form
    {

        //creacion de una lista, guardara facturas y servira para exportar CSV
        private List<Factura> facturas = new List<Factura>();


        public FormHistorialFacturas()
        {
            InitializeComponent();
        }


        private void FormHistorialFacturasLoad(object sender, EventArgs e)
        {
            //con esto muestro desde que se abre el formulario, informacion dentro
            cboEstado.Items.AddRange(new object[] { "Todas", "Activas", "Anuladas" });//envia al cbox
            cboEstado.SelectedIndex = 0;//
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;


            //se configuran las fechas por defecto
            //tomamos la fecha de hoy y se le resta 1 mes, asi muestra por defecto ventas de ultimo mes y las de hoy
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;


            //permiso de seguridad en el boton Anular
            //si entra un cajero el boton naceria bloqueado
            btnAnular.Enabled = Sesion.EsAdministrador;

            //se llama al metodo filtrar, para que de una vez aparezcan facturas en la tabla
            Filtrar();

        }

        private void Filtrar()
        {
            //Se mete a RespositorioDatos.Factura y llena la tabla, deja en gris las anuladas
            //calcula ingresos solo de facturas Activa

            DateTime desde = dtpDesde.Value.Date;
            DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

            string texto = txtBuscar.Text.Trim();
            string estado = cboEstado.SelectedItem.ToString();

            //aplicamos LINQ se unen los 3 filtros la Fecha, el Texto y el Estado
            //buscamos en el RepositorioDatos usamos LINQ el .Where
            facturas = RepositorioDatos.Facturas.Where(f =>
            f.FechaEmision >= desde && f.FechaEmision <= hasta &&
            (texto == ""
            || f.NumeroFactura.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
            || (f.ClienteAsociado != null && f.ClienteAsociado.CedulaRuc.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)) &&


            (estado == "Todas"
            || (estado == "Activas" && f.Estado == "Activa")
            || (estado == "Anuladas" && f.Estado == "Anulada")))

            .OrderByDescending(f => f.FechaEmision).ToList();


            //se limpia y se llena la tabla principal la maestra
            dgvFacturas.Rows.Clear();
            foreach (Factura f in facturas)
            {
                int i = dgvFacturas.Rows.Add(
                    f.NumeroFactura,
                    f.FechaEmision.ToString("dd/MM/yyyy"),
                    f.ClienteAsociado != null ? f.ClienteAsociado.NombreCompleto : "",
                    f.Subtotal.ToString("N2"),
                    f.ValorIva.ToString("N2"),
                    f.Total.ToString("N2"),
                    f.Estado);

                //si esta anulada se la pinta gris
                if (f.Estado == "Anulada")

                    dgvFacturas.Rows[i].DefaultCellStyle.ForeColor = Color.Gray;
            }

            //vamos a sumar solo las facturas activas
            var activas = facturas.Where(f => f.Estado == "Activa").ToList();
            lblIngresos.Text = "$ " + activas.Sum(f => f.Total).ToString("N2");
            lblVentas.Text = activas.Count.ToString();

            //si no hay algo en la factura, se limpia el detalle
            if (facturas.Count == 0)
                dgvDetalle.Rows.Clear();

        }

        private Factura FacturaSeleccionada()
        {
            if (dgvFacturas.CurrentRow == null || dgvFacturas.CurrentRow.Cells[0].Value == null)
                return null; 

            return RepositorioDatos.BuscarFactura(dgvFacturas.CurrentRow.Cells[0].Value.ToString());
        }



        private void dgvFacturas_SelectionChanged (object sender, EventArgs e)
        {

            
            dgvDetalle.Rows.Clear();
            Factura f = FacturaSeleccionada();
            if (f == null) return;


            foreach(DetalleFactura d in f.Detalles) {
                dgvDetalle.Rows.Add(
                    d.CodigoProducto,
                        d.NombreProducto,
                        d.Cantidad,
                        d.PrecioUnitario.ToString("N2"),
                        d.SubtotalLinea.ToString("N2"));
                

        }

            //el boton anular se activa unicamente si es administrador y la factura anda activa
            btnAnular.Enabled = Sesion.EsAdministrador && f.Estado == "Activa";
    }
          
        
        private void btnAnular_Click(object sender, EventArgs e)
        {
            //obtengo la factura seleccionada en la tabla
            Factura f = FacturaSeleccionada();

            if (f == null)
            {
                MessageBox.Show("Selecciona una factura");
                return;
            }

            //emite un mensaje de confirmacion SI o NO
            if (MessageBox.Show("Anular la factura? " + f.NumeroFactura + " ? Se le devuelve el stock",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            
            //se anula la factura y se actualiza pantalla
            try
            {
                RepositorioDatos.AnularFactura(f.NumeroFactura);
                MessageBox.Show("Factura anulada, stock reintegrado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Filtrar();

                //el menu principal recalculara las ventas del dia
                FormMenuPrincipal menu = MdiParent as FormMenuPrincipal;
                if (menu != null) menu.ActualizarDashboard();

            } catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //si la tabla esta vacia no habra nada que exportar
            if (facturas.Count == 0)
            {
                MessageBox.Show("No hay facturas en la lista para exportar");
                return;
            }

            //---------------------------------con este codigo abrimos la ventana de GUARDAR COMO de Windows
            using (SaveFileDialog dlg = new SaveFileDialog())
                //---------------------------------
            {
                dlg.Filter = "CSV (*.csv)|*.csv";
                dlg.FileName = "resumen_ventas.csv";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                //se arma el texto del archivo y se guarda en el disco
                try
                {
                    //Se arma el texto en memoria, 
                    StringBuilder sb = new StringBuilder();

                    //va escribiendo un renglon nuevo
                    sb.AppendLine("Numero;Fecha;Cliente;Subtotal;IVA;Total;Estado");

                    //recorre lista facturas y escribe una linea por cada factura
                    // ; punto y coma separa datos, en columnas en excel
                    foreach (Factura f in facturas)
                    {
                        sb.AppendLine(
                            f.NumeroFactura + ";" +
                            f.FechaEmision.ToString("dd/MM/yyyy") + ";" +
                            (f.ClienteAsociado != null ? f.ClienteAsociado.NombreCompleto : "") + ";" +
                            f.Subtotal.ToString("0.00") + ";" +
                            f.ValorIva.ToString("0.00") + ";" +
                            f.Total.ToString("0.00") + ";" +
                            f.Estado);
                    }

                    //aqui crea el archivo en la computadora
                    //Enconding.UTF* las tildes y letras ñ se guarden, evitando simbolos
                    File.WriteAllText(dlg.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Resumen exportado correctamente.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el archivo: " + ex.Message);
                }
            
        }
    
}

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value.Date > dtpHasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que la fecha 'Hasta, ", "Error, revisa de nuevo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Filtrar();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            txtBuscar.Clear();
            cboEstado.SelectedIndex = 0;
            Filtrar();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using Sistema_De_Facturacion_Ventas.Datos;
using Sistema_De_Facturacion_Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_De_Facturacion_Ventas.Formularios 
{
    public partial class FormFacturacion : Form
    {
        private Factura facturaActual;
        public FormFacturacion()
        {
            InitializeComponent();
            nudCantidad.ReadOnly = true;
        }

       
        private void IniciarNuevaFactura()
        {
            
            facturaActual = new Factura(
                RepositorioDatos.GenerarNumeroFactura(),
                null,
                RepositorioDatos.IvaPorDefecto);

            label2.Text = facturaActual.NumeroFactura;
            label4.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            txtCedula.Clear();
            textNombres.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            dgvDetalles.Rows.Clear();

            CargarProductos();
            ActualizarTotales();
        }
        private void CargarProductos()
        {
            
            cboProductos.Items.Clear();
            foreach (Producto p in RepositorioDatos.Productos)
                cboProductos.Items.Add(p);

            if (cboProductos.Items.Count > 0)
                cboProductos.SelectedIndex = 0;
            else
            {
                lblPrecio.Text = "$ 0.00";
                lbl_Stock.Text = "0";
                nudCantidad.Enabled = false;
            }
        }
        private int CantidadEnFactura(string codigoProducto)
        {
            DetalleFactura detalle = facturaActual.Detalles
                .FirstOrDefault(d => d.CodigoProducto == codigoProducto);

            return detalle == null ? 0 : detalle.Cantidad;
        }

        private void MostrarProductoSeleccionado()
        {
            Producto p = cboProductos.SelectedItem as Producto;

            if (p == null)
            {
                lblPrecio.Text = "$ 0.00";
                lbl_Stock.Text = "0";
                nudCantidad.Enabled = false;
                return;
            }

            lblPrecio.Text = "$ " + p.PrecioUnitario.ToString("0.00");
            lbl_Stock.Text = p.Stock.ToString();

            
            int disponible = p.Stock - CantidadEnFactura(p.Codigo);

            if (disponible <= 0)
            {
               
                nudCantidad.Maximum = 1;
                nudCantidad.Value = 1;
                nudCantidad.Enabled = false;
            }
            else
            {
                nudCantidad.Enabled = true;
                nudCantidad.Maximum = disponible;

                if (nudCantidad.Value > disponible) nudCantidad.Value = disponible;
                if (nudCantidad.Value < 1) nudCantidad.Value = 1;
            }
        }

        private void ActualizarGrilla()
        {
            dgvDetalles.Rows.Clear();

            foreach (DetalleFactura d in facturaActual.Detalles)
            {
                dgvDetalles.Rows.Add(
                    d.CodigoProducto,
                    d.NombreProducto,
                    
                    d.Cantidad,
                    d.PrecioUnitario.ToString("0.00"),
                    d.SubtotalLinea.ToString("0.00"));
            }
        }

        private void ActualizarTotales()
        {
            
            facturaActual.CalcularTotales();

            lblsubtotal2.Text = "$ " + facturaActual.Subtotal.ToString("0.00");
            lblIVA.Text = "IVA(" + facturaActual.PorcentajeIva.ToString("0") + "%):";
            lblTotalIVA.Text = "$ " + facturaActual.ValorIva.ToString("0.00");
            lblTotalFinal.Text = "$ " + facturaActual.Total.ToString("0.00");
        }

        private void Refrescar()
        {
            ActualizarGrilla();
            ActualizarTotales();
            MostrarProductoSeleccionado();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            //instancia bntBuscar
            string cedula = txtCedula.Text.Trim();

            if (cedula == "")
            {
                MessageBox.Show("Ingrese la cédula/RUC del cliente.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCedula.Focus();
                return;
            }

            Cliente cliente = RepositorioDatos.BuscarCliente(cedula);

            if (cliente == null)
            {
                facturaActual.ClienteAsociado = null;
                textNombres.Clear();
                txtDireccion.Clear();
                txtTelefono.Clear();

                MessageBox.Show("No existe un cliente con la cédula/RUC " + cedula + ".",
                    "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            facturaActual.ClienteAsociado = cliente;
            textNombres.Text = cliente.NombreCompleto;
            txtDireccion.Text = cliente.Direccion;
            txtTelefono.Text = cliente.Telefono;

        }

        private void btnBuscarProducto_Click_1(object sender, EventArgs e)
        {
            //instancia bntBuscarProducto
            if (cboProductos.Items.Count == 0)
            {
                MessageBox.Show("No hay productos registrados.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MostrarProductoSeleccionado();
            cboProductos.Focus();
            cboProductos.DroppedDown = true;
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            //instancia
            Producto p = cboProductos.SelectedItem as Producto;

            

            if (p == null)
            {
                MessageBox.Show("Seleccione un producto.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;

            if (cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cantidad > p.Stock)
            {
                MessageBox.Show("La cantidad solicitada supera el stock disponible.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int yaAgregado = CantidadEnFactura(p.Codigo);
            int totalSolicitado = yaAgregado + cantidad;


            if (!p.ValidarStock(totalSolicitado))
            {
                int disponible = p.Stock - yaAgregado;
                if (disponible < 0) disponible = 0;

                MessageBox.Show(
                    "Stock insuficiente para \"" + p.Nombre + "\".\n" +
                    "Stock actual: " + p.Stock + "\n" +
                    "Ya agregado en la factura: " + yaAgregado + "\n" +
                    "Puede agregar como máximo: " + disponible,
                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            facturaActual.AgregarDetalle(new DetalleFactura(
                0,
                p.Codigo,
                p.Nombre,
                p.PrecioUnitario,
                cantidad));

            Refrescar();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //instancia btnEliminarReglon
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el renglón que desea eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigo = Convert.ToString(dgvDetalles.CurrentRow.Cells[0].Value);

            DetalleFactura detalle = facturaActual.Detalles
                .FirstOrDefault(d => d.CodigoProducto == codigo);

            if (detalle == null) return;

            facturaActual.RemoverDetalle(detalle.IdDetalle);
            Refrescar();
        }

        private void btnEmitir_Click_1(object sender, EventArgs e)
        {
            //instancia
            if (facturaActual.Detalles.Count == 0)
            {
                MessageBox.Show("La factura no tiene productos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (facturaActual.ClienteAsociado == null)
            {
                Cliente cliente = RepositorioDatos.BuscarCliente(txtCedula.Text.Trim());

                if (cliente == null)
                {
                    MessageBox.Show("Debe buscar y seleccionar un cliente antes de emitir.",
                        "Cliente requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCedula.Focus();
                    return;
                }

                facturaActual.ClienteAsociado = cliente;
            }

            try
            {
                facturaActual.FechaEmision = DateTime.Now;


                RepositorioDatos.RegistrarFactura(facturaActual);

                string numero = facturaActual.NumeroFactura;
                decimal total = facturaActual.Total;

                MessageBox.Show(
                    "Factura " + numero + " emitida correctamente.\n" +
                    "Total a pagar: $ " + total.ToString("0.00"),
                    "Factura emitida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                IniciarNuevaFactura();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "No se pudo emitir la factura",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);


                CargarProductos();
                Refrescar();
            }

        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            //instancia
            if (facturaActual.Detalles.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea descartar la factura en curso?",
                    "Limpiar factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes) return;
            }

            IniciarNuevaFactura();
        }

        private void lblTotalFinal_Click_1(object sender, EventArgs e)
        {

        }

        private void lblsubtotal2_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTotalIVA_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click_1(object sender, EventArgs e)
        {
            //instancia
        }

        private void dgvDetalles_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //instancia
        }

        private void cboProductos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //instancia
            MostrarProductoSeleccionado();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            //instancia
        }

        private void textNombres_TextChanged_1(object sender, EventArgs e)
        {
            //instancia
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormFacturacion_Load(object sender, EventArgs e)
        {
            this.Text = "Facturación";


            textNombres.ReadOnly = true;
            txtDireccion.ReadOnly = true;
            txtTelefono.ReadOnly = true;


            IniciarNuevaFactura();
        }
    }
}

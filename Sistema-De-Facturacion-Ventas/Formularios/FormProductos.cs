using System;
using System.Collections.Generic;
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
    public partial class FormProductos : Form {
        public FormProductos() {
            InitializeComponent();
            CenterToScreen();
            configurarTabla();
            configurarComboBox();
            cargarProductosTabla();
        }

        private void configurarTabla() {
            // Configurar el DataGridView para que se ajuste automáticamente al tamaño de las columnas
            dvgProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cargarProductosTabla() {
            dvgProductos.Rows.Clear(); // limpiar la tabla antes de cargar los productos
            foreach(Producto p in RepositorioDatos.Productos) {
                agregarProductoTabla(p);
            }
        }

        private void configurarComboBox() {
            foreach (Categoria c in RepositorioDatos.Categorias) {
                cboCategoria.Items.Add(c.IdCategoria.ToString());
            }
        }

        private bool validarCampos(String codigo, String nombre, String precio, String Stock) {
            if (String.IsNullOrWhiteSpace(codigo) || String.IsNullOrWhiteSpace(nombre) || String.IsNullOrWhiteSpace(precio) || String.IsNullOrWhiteSpace(Stock)) {
                return false;
            }
            return true;
        }

        private void agregarProductoTabla(Producto p) {
            dvgProductos.Rows.Add(p.Codigo, p.Nombre, p.PrecioUnitario, p.Stock, p.IdCategoria);
        }

        private bool verificarDuplicadoCodigo(String codigo) {
            return RepositorioDatos.Productos.Any(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        private void btnGuardar_Click(object sender, EventArgs e) {
            int categoriaSeleccionada = -1;
            if (!validarCampos(txtCodigo.Text, txtNombre.Text, txtPrecio.Text, txtStock.Text)) {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String codigo = txtCodigo.Text;

            if (verificarDuplicadoCodigo(codigo)) {
                MessageBox.Show("El código del producto ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if(!Decimal.TryParse(txtPrecio.Text, out Decimal precio)){
                MessageBox.Show("El precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!Int32.TryParse(txtStock.Text,  out Int32 stock)) {
                MessageBox.Show("El stock no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            String nombre = txtNombre.Text;
           
            categoriaSeleccionada = cboCategoria.SelectedIndex;
            if (categoriaSeleccionada == -1) {
                MessageBox.Show("Debe seleccionar una categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCategoria = RepositorioDatos.Categorias[categoriaSeleccionada].IdCategoria; // Obtenemos el id de la categoria seleccionada

            Producto p = new Producto(codigo, nombre, precio, stock, idCategoria);
            RepositorioDatos.Productos.Add(p);
            agregarProductoTabla(p);
            limpiarCampos();
        }

        private void limpiarCampos() {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtBuscar.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cboCategoria.SelectedIndex = -1;
        }

        private void btnActualizar_Click(object sender, EventArgs e) {

        }

        private void btnEliminar_Click(object sender, EventArgs e) {

        }

        private void btnLimpiar_Click(object sender, EventArgs e) {
            limpiarCampos();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) {
            List<Producto> busqueda = null;
            string texto = txtBuscar.Text.Trim();

            if (!String.IsNullOrWhiteSpace(texto)) {
                // filtrar los productos por código o nombre que contengan el texto ingresado (ignorando mayúsculas y minúsculas)
                busqueda = RepositorioDatos.Productos.Where(p => p.Codigo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0 
                || p.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            else {
                // Si el campo de búsqueda está vacío, mostrar todos los productos
                busqueda = RepositorioDatos.Productos;
            }

            cargarProductos(busqueda);

        }

        // Cargar los productos en el DataGridView
        private void cargarProductos(List<Producto> p) {
            dvgProductos.Rows.Clear();
            foreach(Producto pr in p) {
                agregarProductoTabla(pr);
            }
        }
    }
}

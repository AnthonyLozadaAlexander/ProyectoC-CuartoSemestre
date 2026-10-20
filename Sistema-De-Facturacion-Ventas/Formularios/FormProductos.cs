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
            dvgProductos.AutoSize = DataGridViewAutoSizeColumnsMode.Fill;
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
            String nombre = txtNombre.Text;
            Decimal precio = Convert.ToDecimal(txtPrecio.Text);
            int stock = Convert.ToInt32(txtStock.Text);

            categoriaSeleccionada = cboCategoria.SelectedIndex;
            if (categoriaSeleccionada == -1) {
                MessageBox.Show("Debe seleccionar una categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCategoria = RepositorioDatos.Categorias[categoriaSeleccionada].IdCategoria; // Obtenemos el id de la categoria seleccionada

            Producto p = new Producto(codigo, nombre, precio, stock, idCategoria);
            RepositorioDatos.Productos.Add(p);
            agregarProductoTabla(p);
        }

        
    }
}

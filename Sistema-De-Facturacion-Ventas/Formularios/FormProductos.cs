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

        // Configurar el ComboBox con las categorías disponibles
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

        // Agregar un producto a la tabla del DataGridView
        private void agregarProductoTabla(Producto p) {
            dvgProductos.Rows.Add(p.Codigo, p.Nombre, p.PrecioUnitario, p.Stock, p.IdCategoria);
        }

        // Verificar si un producto con el código ingresado ya existe en la lista de productos
        private bool verificarDuplicadoCodigo(String codigo) {
            return RepositorioDatos.Productos.Any(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }

        // Verificar si un producto con el código ingresado ya existe en la lista de productos
        private bool verificarExisteCodigo(String codigo) {
            return RepositorioDatos.Productos.Any(p => p.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }
        // Manejar el evento de clic del botón "Guardar" para agregar un nuevo producto
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
            if (categoriaSeleccionada == -1) { // Verificar si se ha seleccionado una categoría
                MessageBox.Show("Debe seleccionar una categoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCategoria = RepositorioDatos.Categorias[categoriaSeleccionada].IdCategoria; // Obtenemos el id de la categoria seleccionada

            Producto p = new Producto(codigo, nombre, precio, stock, idCategoria); // Creamos un nuevo producto con los datos ingresados
            RepositorioDatos.Productos.Add(p);
            agregarProductoTabla(p);
            limpiarCampos();
        }

        // Limpiar los campos de texto y el ComboBox
        private void limpiarCampos() {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtBuscar.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            cboCategoria.SelectedIndex = -1;
        }

        // Actualizar un producto existente
        private void btnActualizar_Click(object sender, EventArgs e) {

            if(!validarCampos(txtCodigo.Text, txtNombre.Text, txtPrecio.Text, txtStock.Text)) {
                MessageBox.Show("Error: Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!Decimal.TryParse(txtPrecio.Text, out Decimal precio)) {
                MessageBox.Show("Error: El precio no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!Int32.TryParse(txtStock.Text, out Int32 stock)) {
                MessageBox.Show("Error: El stock no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cboCategoria.SelectedIndex == -1) {
                MessageBox.Show("Error: Debe seleccionar una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Producto productoBuscado = null;
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;

            if (verificarExisteCodigo(codigo)) {
                productoBuscado = RepositorioDatos.BuscarProducto(codigo);
                productoBuscado.Nombre = nombre;
                productoBuscado.PrecioUnitario = precio;
                productoBuscado.Stock = stock;
                productoBuscado.IdCategoria = RepositorioDatos.Categorias[cboCategoria.SelectedIndex].IdCategoria;

                cargarProductos(listaVisibleEnTabla()); // Actualizar la tabla con los productos filtrados
                limpiarCampos(); // Limpiar los campos después de la actualización
                MessageBox.Show("Actualizacion Exitosa", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Mostrar mensaje de éxito

            }
            else {
                MessageBox.Show("Codigo No Existente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e) {

        }

        // Limpiar los campos de texto y el ComboBox al hacer clic en el botón "Limpiar"
        private void btnLimpiar_Click(object sender, EventArgs e) {
            limpiarCampos();
        }

        // Filtrar los productos en el DataGridView según el texto ingresado en el TextBox de búsqueda
        private void txtBuscar_TextChanged(object sender, EventArgs e) {
            cargarProductos(listaVisibleEnTabla()); // Cargar los productos filtrados en el DataGridView
            
        }

        // Filtrar los productos por código o nombre que contengan el texto ingresado (ignorando mayúsculas y minúsculas)
        private List<Producto> listaVisibleEnTabla() {
            List<Producto> pr = null;
            string texto = txtBuscar.Text.Trim();

            if (String.IsNullOrWhiteSpace(texto)) {
                pr = RepositorioDatos.Productos;
            }
            else {

                // filtrar los productos por código o nombre que contengan el texto ingresado (ignorando mayúsculas y minúsculas)
                pr = RepositorioDatos.Productos.Where(p => p.Codigo.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
                    || p.Nombre.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            // devuelve la lista de productos filtrada
            return pr;

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

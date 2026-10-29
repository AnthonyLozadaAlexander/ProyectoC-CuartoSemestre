using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ejercicio1_InventarioTienda.Modelos;

namespace Ejercicio1_InventarioTienda.Formularios {
    public class FormInventario : Form {
        // Lista con el tipo base: guarda Dispositivos y Accesorios por polimorfismo.
        private List<Producto> inventario = new List<Producto>();

        private ComboBox cmbTipo;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private NumericUpDown nudPrecioBase;
        private NumericUpDown nudCantidad;
        private NumericUpDown nudCostoGarantia;
        private Label lblCostoGarantia;
        private Button btnAgregar;
        private Button btnMostrarInventario;
        private DataGridView dgvInventario;
        private Label lblTotalInventario;

        public FormInventario() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            this.Text = "Ejercicio 1 - Inventario de Tienda de Electrónica";
            this.ClientSize = new Size(720, 520);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9F);
            this.Load += FormInventario_Load;

            var lblTipo = new Label { Text = "Tipo de producto:", Location = new Point(20, 20), AutoSize = true };
            cmbTipo = new ComboBox {
                Location = new Point(160, 17),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTipo.Items.Add("Dispositivo (garantía extendida)");
            cmbTipo.Items.Add("Accesorio");
            cmbTipo.SelectedIndex = 0;
            cmbTipo.SelectedIndexChanged += CmbTipo_SelectedIndexChanged;

            var lblCodigo = new Label { Text = "Código:", Location = new Point(20, 55), AutoSize = true };
            txtCodigo = new TextBox { Location = new Point(160, 52), Width = 200 };

            var lblNombre = new Label { Text = "Nombre:", Location = new Point(20, 90), AutoSize = true };
            txtNombre = new TextBox { Location = new Point(160, 87), Width = 200 };

            var lblPrecioBase = new Label { Text = "Precio base:", Location = new Point(20, 125), AutoSize = true };
            nudPrecioBase = new NumericUpDown {
                Location = new Point(160, 122),
                Width = 200,
                DecimalPlaces = 2,
                Maximum = 999999,
                Minimum = 0
            };

            var lblCantidad = new Label { Text = "Cantidad en stock:", Location = new Point(20, 160), AutoSize = true };
            nudCantidad = new NumericUpDown {
                Location = new Point(160, 157),
                Width = 200,
                DecimalPlaces = 0,
                Maximum = 100000,
                Minimum = 0
            };

            lblCostoGarantia = new Label { Text = "Costo garantía extendida:", Location = new Point(20, 195), AutoSize = true };
            nudCostoGarantia = new NumericUpDown {
                Location = new Point(160, 192),
                Width = 200,
                DecimalPlaces = 2,
                Maximum = 999999,
                Minimum = 0
            };

            btnAgregar = new Button {
                Text = "Agregar producto",
                Location = new Point(160, 235),
                Width = 200,
                Height = 32
            };
            btnAgregar.Click += BtnAgregar_Click;

            btnMostrarInventario = new Button {
                Text = "Mostrar inventario",
                Location = new Point(380, 235),
                Width = 200,
                Height = 32
            };
            btnMostrarInventario.Click += BtnMostrarInventario_Click;

            dgvInventario = new DataGridView {
                Location = new Point(20, 285),
                Size = new Size(680, 170),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            lblTotalInventario = new Label {
                Text = "Valor total del inventario: $0.00",
                Location = new Point(20, 470),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom
            };

            this.Controls.AddRange(new Control[] {
                lblTipo, cmbTipo,
                lblCodigo, txtCodigo,
                lblNombre, txtNombre,
                lblPrecioBase, nudPrecioBase,
                lblCantidad, nudCantidad,
                lblCostoGarantia, nudCostoGarantia,
                btnAgregar, btnMostrarInventario,
                dgvInventario, lblTotalInventario
            });
        }

        // Precarga de productos en el evento Load usando referencias del tipo base.
        private void FormInventario_Load(object sender, EventArgs e) {
            Producto p1 = new Dispositivo("DIS-001", "Laptop Lenovo 15\"", 18500m, 5, 950m);
            Producto p2 = new Dispositivo("DIS-002", "Smart TV 55\"", 12000m, 3, 600m);
            Producto p3 = new Accesorio("ACC-001", "Mouse inalámbrico", 350m, 20);
            Producto p4 = new Accesorio("ACC-002", "Cable HDMI 2m", 180m, 35);

            inventario.Add(p1);
            inventario.Add(p2);
            inventario.Add(p3);
            inventario.Add(p4);

            ConfigurarColumnas();
            MostrarInventario();
        }

        private void ConfigurarColumnas() {
            dgvInventario.Columns.Clear();
            dgvInventario.Columns.Add("Codigo", "Código");
            dgvInventario.Columns.Add("Nombre", "Nombre");
            dgvInventario.Columns.Add("Tipo", "Tipo");
            dgvInventario.Columns.Add("PrecioVenta", "Precio de venta");
            dgvInventario.Columns.Add("Cantidad", "Cantidad");
            dgvInventario.Columns.Add("Subtotal", "Subtotal");
            dgvInventario.Columns["PrecioVenta"].DefaultCellStyle.Format = "C2";
            dgvInventario.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
            dgvInventario.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInventario.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        // Habilita/deshabilita el campo de garantía según el tipo seleccionado.
        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e) {
            bool esDispositivo = cmbTipo.SelectedIndex == 0;
            nudCostoGarantia.Enabled = esDispositivo;
            lblCostoGarantia.Enabled = esDispositivo;
            if (!esDispositivo) {
                nudCostoGarantia.Value = 0;
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e) {
            // Validacion: campos vacios.
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) || string.IsNullOrWhiteSpace(txtNombre.Text)) {
                MessageBox.Show("Debe completar el código y el nombre del producto.",
                    "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validacion: precios negativos (NumericUpDown ya evita negativos, se revalida por seguridad).
            if (nudPrecioBase.Value < 0 || nudCostoGarantia.Value < 0) {
                MessageBox.Show("El precio base y el costo de garantía no pueden ser negativos.",
                    "Precio inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validacion: cantidad mayor a cero.
            if (nudCantidad.Value <= 0) {
                MessageBox.Show("La cantidad en stock debe ser mayor a cero.",
                    "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string codigo = txtCodigo.Text.Trim();
            foreach (Producto existente in inventario) {
                if (existente.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase)) {
                    MessageBox.Show("Ya existe un producto con ese código.",
                        "Código duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Se declara la referencia con el tipo base y se instancia la subclase correcta.
            decimal precioBase = nudPrecioBase.Value;
            int cantidad = (int)nudCantidad.Value;
            Producto nuevoProducto;

            if (cmbTipo.SelectedIndex == 0) {
                nuevoProducto = new Dispositivo(codigo, txtNombre.Text.Trim(), precioBase, cantidad, nudCostoGarantia.Value);
            } else {
                nuevoProducto = new Accesorio(codigo, txtNombre.Text.Trim(), precioBase, cantidad);
            }

            inventario.Add(nuevoProducto);

            MessageBox.Show(nuevoProducto.MostrarInformacion(),
                "Producto agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarCampos();
            MostrarInventario();
        }

        private void BtnMostrarInventario_Click(object sender, EventArgs e) {
            MostrarInventario();
        }

        // Recorre la lista con el tipo base e invoca el metodo polimorfico.
        private void MostrarInventario() {
            dgvInventario.Rows.Clear();
            decimal valorTotal = 0m;

            foreach (Producto producto in inventario) {
                decimal precioVenta = producto.CalcularPrecioVenta(); // llamada polimorfica
                decimal subtotal = producto.CalcularSubtotal();
                valorTotal += subtotal;

                dgvInventario.Rows.Add(
                    producto.Codigo,
                    producto.Nombre,
                    producto.ObtenerTipo(),
                    precioVenta,
                    producto.CantidadStock,
                    subtotal);
            }

            lblTotalInventario.Text = "Valor total del inventario: " + valorTotal.ToString("C");

            if (inventario.Count == 0) {
                MessageBox.Show("El inventario está vacío.", "Inventario",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LimpiarCampos() {
            txtCodigo.Clear();
            txtNombre.Clear();
            nudPrecioBase.Value = 0;
            nudCantidad.Value = 1;
            nudCostoGarantia.Value = 0;
            cmbTipo.SelectedIndex = 0;
            txtCodigo.Focus();
        }
    }
}

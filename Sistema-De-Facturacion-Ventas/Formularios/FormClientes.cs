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

namespace Sistema_De_Facturacion_Ventas.Formularios {
    public partial class FormClientes : Form {
        public FormClientes() {
            InitializeComponent();
            CenterToScreen();
            configurarTabla();
            cargarClientesTabla();
        }
        private void configurarTabla()
        {
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
        }

        private void cargarClientesTabla()
        {
            cargarClientes(RepositorioDatos.Clientes);
        }

        private void cargarClientes(List<Cliente> clientes)
        {
            dgvClientes.Rows.Clear();
            foreach (Cliente c in clientes)
            {
                agregarClienteTabla(c);
            }
        }

        private void agregarClienteTabla(Cliente c)
        {
            dgvClientes.Rows.Add(c.CedulaRuc, c.Nombres, c.Apellidos, c.Direccion, c.Telefono, c.Email);
        }

        private bool validarCampos(string cedula, string nombres, string apellidos)
        {
            return !String.IsNullOrWhiteSpace(cedula)
                && !String.IsNullOrWhiteSpace(nombres)
                && !String.IsNullOrWhiteSpace(apellidos);
        }

        private bool validarEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) return true;
            return email.Contains("@") && email.Contains(".");
        }

        private bool verificarDuplicadoCedula(string cedula)
        {
            return RepositorioDatos.Clientes.Any(c => c.CedulaRuc.Equals(cedula, StringComparison.OrdinalIgnoreCase));
        }
        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarCampos(txtCedula.Text, txtNombres.Text, txtApellidos.Text))
            {
                MessageBox.Show("Cédula, Nombres y Apellidos son obligatorios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validarEmail(txtEmail.Text))
            {
                MessageBox.Show("El email no tiene un formato válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cedula = txtCedula.Text.Trim();
            if (verificarDuplicadoCedula(cedula))
            {
                MessageBox.Show("Ya existe un cliente con esa cédula/RUC.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente nuevo = new Cliente(cedula, txtNombres.Text.Trim(), txtApellidos.Text.Trim(),
                txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), txtEmail.Text.Trim());
            RepositorioDatos.Clientes.Add(nuevo);

            agregarClienteTabla(nuevo);
            limpiarCampos();
            MessageBox.Show("Cliente registrado correctamente.", "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione un cliente de la tabla para modificar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validarCampos(txtCedula.Text, txtNombres.Text, txtApellidos.Text))
            {
                MessageBox.Show("Cédula, Nombres y Apellidos son obligatorios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!validarEmail(txtEmail.Text))
            {
                MessageBox.Show("El email no tiene un formato válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente cliente = RepositorioDatos.BuscarCliente(txtCedula.Text.Trim());
            if (cliente == null)
            {
                MessageBox.Show("El cliente no existe.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult consulta = MessageBox.Show(
                "¿Está seguro de modificar el cliente " + cliente.NombreCompleto + "?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (consulta == DialogResult.Yes)
            {
                cliente.Nombres = txtNombres.Text.Trim();
                cliente.Apellidos = txtApellidos.Text.Trim();
                cliente.Direccion = txtDireccion.Text.Trim();
                cliente.Telefono = txtTelefono.Text.Trim();
                cliente.Email = txtEmail.Text.Trim();

                cargarClientes(listaVisibleEnTabla());
                limpiarCampos();
                MessageBox.Show("Cliente actualizado correctamente.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MessageBox.Show("Seleccione o busque el cliente a eliminar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cliente cliente = RepositorioDatos.BuscarCliente(txtCedula.Text.Trim());
            if (cliente == null)
            {
                MessageBox.Show("El cliente no existe.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult consulta = MessageBox.Show(
                "¿Está seguro de eliminar a " + cliente.NombreCompleto + "?",
                "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (consulta == DialogResult.Yes)
            {
                RepositorioDatos.Clientes.Remove(cliente);
                cargarClientes(listaVisibleEnTabla());
                limpiarCampos();
                MessageBox.Show("Cliente eliminado correctamente.", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            txtCedula.Focus();
        }
        private void limpiarCampos()
        {
            txtCedula.Clear();
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtBuscar.Clear();
            cargarClientesTabla();
        }


        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignorar clics en el encabezado o fuera de filas
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvClientes.Rows[e.RowIndex];
            txtCedula.Text = fila.Cells[0].Value?.ToString();
            txtNombres.Text = fila.Cells[1].Value?.ToString();
            txtApellidos.Text = fila.Cells[2].Value?.ToString();
            txtDireccion.Text = fila.Cells[3].Value?.ToString();
            txtTelefono.Text = fila.Cells[4].Value?.ToString();
            txtEmail.Text = fila.Cells[5].Value?.ToString();
        }


        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarClientes(listaVisibleEnTabla());
        }

        private List<Cliente> listaVisibleEnTabla()
        {
            string texto = txtBuscar.Text.Trim();

            if (String.IsNullOrWhiteSpace(texto))
            {
                return RepositorioDatos.Clientes;
            }

            return RepositorioDatos.Clientes
                .Where(c => c.CedulaRuc.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
                         || c.Nombres.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0
                         || c.Apellidos.IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Trim();

            if (String.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show("Escribe una cédula, nombre o apellido para buscar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBuscar.Focus();
                return;
            }

            List<Cliente> resultados = listaVisibleEnTabla();

            if (resultados.Count == 0)
            {
                MessageBox.Show("No se encontraron clientes para: " + texto, "Sin resultados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            cargarClientes(resultados);
        }
    }
}

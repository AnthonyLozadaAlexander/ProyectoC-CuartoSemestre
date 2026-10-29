using Sistema_De_Facturacion_Ventas.Datos;
using Sistema_De_Facturacion_Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_De_Facturacion_Ventas.Formularios
{
    public partial class FormClientes : Form
    {

        public FormClientes()
        {
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


        private bool esSoloDigitos(string texto)
        {
            return !String.IsNullOrEmpty(texto) && texto.All(char.IsDigit);
        }

        
        private bool esSoloLetras(string texto)
        {
            texto = texto.Trim();
            return texto.Length > 0 && texto.All(c => char.IsLetter(c) || c == ' ');
        }


        private int calcularDigitoVerificador(string primerosNueve)
        {
            int[] coeficientes = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int suma = 0;

            for (int i = 0; i < 9; i++)
            {
                int producto = coeficientes[i] * Int32.Parse(primerosNueve[i].ToString());
                if (producto >= 10)
                {
                    producto = (producto / 10) + (producto % 10);
                }
                suma += producto;
            }

            int resultado = 10 - (suma % 10);
            return resultado == 10 ? 0 : resultado;
        }

        private bool validarCedulaEcuatoriana(string cedula)
        {
            if (!esSoloDigitos(cedula) || cedula.Length != 10) return false;

            if (!Int32.TryParse(cedula.Substring(0, 2), out int provincia) || provincia < 1 || provincia > 24) return false;

            if (Int32.Parse(cedula[2].ToString()) > 5) return false;

            return calcularDigitoVerificador(cedula.Substring(0, 9)) == Int32.Parse(cedula[9].ToString());
        }


        private bool validarTelefonoEcuatoriano(string telefono)
        {
            return esSoloDigitos(telefono) && telefono.Length == 10 && telefono.StartsWith("09");
        }

        private bool validarEmail(string email)
        {
            if (String.IsNullOrWhiteSpace(email)) return true;
            return email.Contains("@") && email.Contains(".") &&
                   !email.Contains(" ") &&
                   !email.StartsWith("@") && !email.EndsWith("@") &&
                   !email.StartsWith(".") && !email.EndsWith(".") &&
                   email.IndexOf("@") == email.LastIndexOf("@");
        }

        private bool validarCampos(string cedula, string nombres, string apellidos)
        {
            return !String.IsNullOrWhiteSpace(cedula)
                && !String.IsNullOrWhiteSpace(nombres)
                && !String.IsNullOrWhiteSpace(apellidos);
        }


        private bool verificarDuplicadoCedula(string cedula)
        {
            return RepositorioDatos.Clientes.Any(c => c.CedulaRuc.Equals(cedula, StringComparison.OrdinalIgnoreCase));
        }

        private bool verificarDuplicadoTelefono(string telefono)
        {
            if (String.IsNullOrWhiteSpace(telefono)) return false;
            return RepositorioDatos.Clientes.Any(c => c.Telefono.Equals(telefono, StringComparison.OrdinalIgnoreCase));
        }


        private bool validarFormulario(bool esRegistro)
        {
            string cedula = txtCedula.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (!validarCampos(cedula, nombres, apellidos))
            {
                MessageBox.Show("Cédula, Nombres y Apellidos son obligatorios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedula.Focus();
                return false;
            }

            if (!esSoloLetras(nombres) || !esSoloLetras(apellidos))
            {
                MessageBox.Show("Nombres y Apellidos solo pueden contener letras y espacios.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNombres.Focus();
                return false;
            }

            if (!esSoloDigitos(cedula))
            {
                MessageBox.Show("La cédula/RUC solo puede contener números.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedula.Focus();
                return false;
            }

            if (cedula.Length != 10)
            {
                MessageBox.Show("La cédula debe tener exactamente 10 dígitos.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedula.Focus();
                return false;
            }

            if (!validarCedulaEcuatoriana(cedula))
            {
                MessageBox.Show("La cédula no es válida según el algoritmo ecuatoriano (Módulo 10).", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedula.Focus();
                return false;
            }

            if (esRegistro && verificarDuplicadoCedula(cedula))
            {
                MessageBox.Show("Ya existe un cliente con esa cédula/RUC.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCedula.Focus();
                return false;
            }

            if (!validarTelefonoEcuatoriano(telefono))
            {
                MessageBox.Show("El teléfono debe tener 10 dígitos y comenzar con 09.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTelefono.Focus();
                return false;
            }

            if (verificarDuplicadoTelefono(telefono))
            {
                Cliente dueno = RepositorioDatos.Clientes.FirstOrDefault(c => c.Telefono == telefono);
                bool esElMismo = !esRegistro && dueno != null && dueno.CedulaRuc == cedula;
                if (!esElMismo)
                {
                    MessageBox.Show("Ese teléfono ya está registrado por otro cliente: " + dueno.NombreCompleto,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefono.Focus();
                    return false;
                }
            }

            if (!validarEmail(email))
            {
                MessageBox.Show("El email no tiene un formato válido.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarFormulario(esRegistro: true)) return;

            Cliente nuevo = new Cliente(txtCedula.Text.Trim(), txtNombres.Text.Trim(), txtApellidos.Text.Trim(),
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

            if (!validarFormulario(esRegistro: false)) return;

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

        

        private void FormClientes_Load(object sender, EventArgs e)
        {
        }
    }
}
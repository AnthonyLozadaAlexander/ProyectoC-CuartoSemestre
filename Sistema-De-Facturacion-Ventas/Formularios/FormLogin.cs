using Sistema_De_Facturacion_Ventas.Datos;
using Sistema_De_Facturacion_Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_De_Facturacion_Ventas {
    public partial class FormLogin : Form {
        public FormLogin() {
            InitializeComponent();
            CenterToScreen();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblError.Visible = false;
            txtUsuario.Focus();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void MostrarError(String text)
        {
            lblError.Text=text;
            lblError.Visible = true;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string clave = txtPassword.Text;

            if (usuario == "" || clave == "")
            {
                MostrarError("Complete usuario y contraseña.");
                return;
            }

            try
            {
                Usuario encontrado = RepositorioDatos.Usuarios
                    .FirstOrDefault(x => x.Username == usuario && x.Password == clave);

                if (encontrado == null)
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                    return;
                }

                Sesion.UsuarioActual = encontrado;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo validar el acceso: " + ex.Message);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Sesion.Cerrar();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void lblError_Click(object sender, EventArgs e) {

        }
    }
}

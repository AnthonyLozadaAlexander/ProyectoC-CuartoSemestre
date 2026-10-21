using Sistema_De_Facturacion_Ventas.Datos;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Sistema_De_Facturacion_Ventas.Formularios {
    public partial class FormMenuPrincipal : Form {
        public FormMenuPrincipal() {
            InitializeComponent();
            this.ControlBox = false; // Oculta los botones de minimizar, maximizar y cerrar.
        }        

        // Actualiza la fecha y hora cada vez que el Timer cumple un segundo.
        private void tmrReloj_Tick(object sender, EventArgs e) {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        // PÚBLICO: los demás formularios lo llaman después de emitir o anular una factura.
        public void ActualizarDashboard() {
            if (this.IsDisposed) return;

            txtProductos.Text = RepositorioDatos.Productos.Count.ToString();
            txtClientes.Text = RepositorioDatos.Clientes.Count.ToString();

            decimal ventasHoy = RepositorioDatos.Facturas
                .Where(f => f.Estado == "Activa" && f.FechaEmision.Date == DateTime.Today)
                .Sum(f => f.Total);

            txtVentas.Text = "$ " + ventasHoy.ToString("N2");
        }

        // Abre un formulario hijo dentro del MDI. Si ya está abierto, solo lo activa.
        private void AbrirFormulario<T>() where T : Form, new() {
            // 1) ¿Ya existe una ventana de este tipo? Entonces no se duplica.
            foreach (Form hijo in this.MdiChildren) {
                if (hijo is T) {
                    if (hijo.WindowState == FormWindowState.Minimized)
                        hijo.WindowState = FormWindowState.Normal;

                    hijo.Activate();
                    return;
                }
            }

            try {
                // 2) No existe: se crea, se le asigna el contenedor MDI y se muestra.
                T nuevo = new T();
                nuevo.MdiParent = this;
                nuevo.WindowState = FormWindowState.Maximized;
                nuevo.FormClosed += Hijo_FormClosed;
                nuevo.Show();

                // Las tarjetas del dashboard se ocultan para que no tapen la ventana hija.
                MostrarDashboard(false);
            }
            catch (Exception ex) {
                MessageBox.Show("No se pudo abrir el formulario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Cuando se cierra una ventana hija se recalculan las métricas.
        private void Hijo_FormClosed(object sender, FormClosedEventArgs e) {
            ActualizarDashboard();

            // Se comprueba si queda alguna otra ventana hija abierta.
            bool quedanVentanas = false;
            foreach (Form hijo in this.MdiChildren) {
                if (hijo != sender && !hijo.IsDisposed) {
                    quedanVentanas = true;
                    break;
                }
            }

            // Si ya no queda ninguna, se vuelve a mostrar el dashboard.
            if (!quedanVentanas)
                MostrarDashboard(true);
        }

        // Muestra u oculta las tarjetas informativas del menú.
        private void MostrarDashboard(bool visible) {
            lblDashboard.Visible = visible;
            pnlCardProductos.Visible = visible;
            pnlCardClientes.Visible = visible;
            pnlCardVentas.Visible = visible;
            txtUsuario.Visible = visible;
            txtRol.Visible = visible;
            txtFecha.Visible = visible;
            lblUsuario.Visible = visible;
            lblRol.Visible = visible;
            lblFecha.Visible = visible;
        }

        // ---------- Eventos del menú ----------

        private void msFacturacion_Click(object sender, EventArgs e) {
            AbrirFormulario<FormFacturacion>();
        }

        private void msProductos_Click(object sender, EventArgs e) {
            AbrirFormulario<FormProductos>();
        }

        private void msClientes_Click(object sender, EventArgs e) {
            AbrirFormulario<FormClientes>();
        }

        private void msHistorial_Click(object sender, EventArgs e) {
            AbrirFormulario<FormHistorialFacturas>();
        }

        private void msSalir_Click(object sender, EventArgs e) {
            DialogResult consult =  MessageBox.Show("¿Desea cerrar la sesión y salir del sistema?",
                "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (consult == DialogResult.Yes) {
                Sesion.Cerrar();          // Limpia el usuario autenticado.
                Application.Exit();       // Cierra la aplicación completa.
            }
        }

        // Se ejecuta una sola vez, al abrir el menú después de un login correcto.
        private void FormMenuPrincipal_Load_1(object sender, EventArgs e) {
            // Protección por si alguien abre este formulario sin pasar por el login.
            if (Sesion.UsuarioActual == null) {
                MessageBox.Show("No hay una sesión activa. Debe iniciar sesión primero.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Color de fondo del MDI (el área donde se abren los formularios hijos).
            foreach (Control c in this.Controls) {
                if(c is MdiClient) {
                    c.BackColor = Color.White;
                }
            }

            // Datos del usuario autenticado.
            txtUsuario.Text = Sesion.UsuarioActual.NombreCompleto;
            txtRol.Text = Sesion.UsuarioActual.Rol;

            // Permisos: el Cajero no puede administrar el inventario.
            msProductos.Enabled = Sesion.EsAdministrador;

            // Reloj en vivo: cada 1000 ms (1 segundo) dispara tmrReloj_Tick.
            tmrReloj.Interval = 1000;
            tmrReloj.Start();
            tmrReloj_Tick(null, EventArgs.Empty); // Muestra la hora de inmediato, sin esperar 1 s.

            ActualizarDashboard();
        }

        private void lblDashboard_Click(object sender, EventArgs e) {

        }
    }
}

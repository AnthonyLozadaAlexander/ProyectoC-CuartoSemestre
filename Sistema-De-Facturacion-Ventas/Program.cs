using Sistema_De_Facturacion_Ventas.Formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_De_Facturacion_Ventas {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Muestra el formulario de inicio de sesión antes de mostrar el formulario principal.
            using (FormLogin login = new FormLogin()) {
                // ShowDialog bloquea aquí hasta que el login devuelva OK o Cancel.
                if (login.ShowDialog() != DialogResult.OK) {
                    return; // El usuario canceló o cerró: no se abre el menú.
                }
            }

            Application.Run(new FormMenuPrincipal()); // Solo se llega aquí si el login devolvió OK.
        }
    }
}

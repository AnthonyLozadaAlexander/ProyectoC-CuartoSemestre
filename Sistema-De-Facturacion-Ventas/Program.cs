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

            // Muestra el formulario de inicio de sesión antes de mostrar el formulario principal
            using (FormLogin login = new FormLogin()) {
                if(login.DialogResult != DialogResult.OK) { // si el usuario no inicia sesión correctamente, se cierra la aplicación
                    return;
                }
            }
            
            Application.Run(new FormMenuPrincipal()); // Inicia la aplicación con el formulario principal después de que el usuario haya iniciado sesión correctamente
        }
    }
}

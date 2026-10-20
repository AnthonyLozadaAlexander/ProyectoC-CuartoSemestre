using Sistema_De_Facturacion_Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_Facturacion_Ventas.Datos {
    public class Sesion {
        public static Usuario UsuarioActual { get; set; }

        public static bool EsAdministrador =>
            UsuarioActual != null && UsuarioActual.Rol == "Administrador";

        public static void Cerrar() {
            UsuarioActual = null;
        }

    }
}

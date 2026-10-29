using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_Facturacion_Ventas.Modelos {
    public class Cliente {
        public string CedulaRuc { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Cliente() { }

        public Cliente(string cedulaRuc, string nombres, string apellidos,
                       string direccion, string telefono, string email) {
            CedulaRuc = cedulaRuc;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
        }

        public string NombreCompleto => Nombres + " " + Apellidos;
    }
}

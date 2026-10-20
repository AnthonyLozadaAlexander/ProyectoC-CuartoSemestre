using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_Facturacion_Ventas.Modelos {
    public class Usuario {
        public string Username { get; set; }
        public string Password { get; set; }
        public string NombreCompleto { get; set; }
        public string Rol { get; set; }   // "Administrador" o "Cajero"

        public Usuario() { }

        public Usuario(string username, string password, string nombreCompleto, string rol) {
            Username = username;
            Password = password;
            NombreCompleto = nombreCompleto;
            Rol = rol;
        }

        }
    }

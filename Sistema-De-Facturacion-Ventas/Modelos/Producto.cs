using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_Facturacion_Ventas.Modelos {
    public class Producto {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; set; }
        public int IdCategoria { get; set; }

        public Producto() {

        }

        public Producto(string codigo, string nombre, decimal precioUnitario, int stock, int idCategoria) {
            Codigo = codigo;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
            Stock = stock;
            IdCategoria = idCategoria;
        }

        public bool ValidarStock(int cantidad) {
            return cantidad > 0 && Stock >= cantidad;
        }
        public void DecrementarStock(int cantidad) {
            if (!ValidarStock(cantidad))
                throw new InvalidOperationException("Stock insuficiente para " + Nombre);
            Stock -= cantidad;
        }

        public void IncrementarStock(int cantidad) {
            if (cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero.");
            Stock += cantidad;
        }

        // Para que un ComboBox muestre codigo y nombre
        public override string ToString() => Codigo + " - " + Nombre;
    }
}

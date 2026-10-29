using System;

namespace Ejercicio1_InventarioTienda.Modelos {
    // Clase base concreta: contiene los atributos y metodos comunes a todos los productos.
    // Implementacion por defecto de CalcularPrecioVenta() que las subclases pueden sobrescribir.
    public class Producto {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioBase { get; set; }
        public int CantidadStock { get; set; }

        public Producto() {
        }

        public Producto(string codigo, string nombre, decimal precioBase, int cantidadStock) {
            Codigo = codigo;
            Nombre = nombre;
            PrecioBase = precioBase;
            CantidadStock = cantidadStock;
        }

        // Metodo polimorfico con implementacion por defecto.
        // Por defecto el precio de venta es igual al precio base (sin recargos).
        public virtual decimal CalcularPrecioVenta() {
            return PrecioBase;
        }

        // Nombre del tipo de producto (las subclases lo sobrescriben para el DataGridView).
        public virtual string ObtenerTipo() {
            return "Producto";
        }

        // Muestra la informacion del producto usando el metodo polimorfico.
        public virtual string MostrarInformacion() {
            return "Codigo: " + Codigo
                 + " | Nombre: " + Nombre
                 + " | Tipo: " + ObtenerTipo()
                 + " | Precio base: " + PrecioBase.ToString("C")
                 + " | Precio de venta: " + CalcularPrecioVenta().ToString("C")
                 + " | Stock: " + CantidadStock;
        }

        // Subtotal para el inventario: precio de venta * cantidad.
        public decimal CalcularSubtotal() {
            return CalcularPrecioVenta() * CantidadStock;
        }

        public override string ToString() {
            return Codigo + " - " + Nombre;
        }
    }
}

namespace Ejercicio1_InventarioTienda.Modelos {
    // Accesorio: no tiene recargos, hereda la implementacion por defecto de la clase base.
    public class Accesorio : Producto {
        public Accesorio() {
        }

        public Accesorio(string codigo, string nombre, decimal precioBase, int cantidadStock)
            : base(codigo, nombre, precioBase, cantidadStock) {
        }

        // No sobrescribe CalcularPrecioVenta(): el precio de venta es igual al precio base.
        public override string ObtenerTipo() {
            return "Accesorio";
        }
    }
}

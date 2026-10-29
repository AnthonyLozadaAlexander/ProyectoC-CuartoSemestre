namespace Ejercicio1_InventarioTienda.Modelos {
    // Dispositivo con garantia extendida: al precio base se le suma el costo fijo de la garantia.
    public class Dispositivo : Producto {
        public decimal CostoGarantiaExtendida { get; set; }

        public Dispositivo() {
        }

        public Dispositivo(string codigo, string nombre, decimal precioBase, int cantidadStock, decimal costoGarantiaExtendida)
            : base(codigo, nombre, precioBase, cantidadStock) {
            CostoGarantiaExtendida = costoGarantiaExtendida;
        }

        // Sobrescribe la implementacion de la clase base: precio base + costo de la garantia.
        public override decimal CalcularPrecioVenta() {
            return PrecioBase + CostoGarantiaExtendida;
        }

        public override string ObtenerTipo() {
            return "Dispositivo";
        }

        public override string MostrarInformacion() {
            return base.MostrarInformacion() + " | Garantia extendida: " + CostoGarantiaExtendida.ToString("C");
        }
    }
}

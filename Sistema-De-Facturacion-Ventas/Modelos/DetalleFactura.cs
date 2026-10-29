using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_Facturacion_Ventas.Modelos {
    public class DetalleFactura {
        public int IdDetalle { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public DetalleFactura() { }

        public DetalleFactura(int idDetalle, string codigoProducto, string nombreProducto,
                              decimal precioUnitario, int cantidad) {
            IdDetalle = idDetalle;
            CodigoProducto = codigoProducto;
            NombreProducto = nombreProducto;
            PrecioUnitario = precioUnitario;
            Cantidad = cantidad;
        }

        public decimal SubtotalLinea => Cantidad * PrecioUnitario;

    }
}

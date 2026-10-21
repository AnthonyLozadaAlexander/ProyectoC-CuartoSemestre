using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_Facturacion_Ventas.Modelos {
    public class Factura {
        public string NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public Cliente ClienteAsociado { get; set; }
        public List<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();
        public decimal Subtotal { get; set; }
        public decimal PorcentajeIva { get; set; } = 15m;
        public decimal ValorIva { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = "Activa";

        public Factura() { }

        // Constructor que inicializa la factura con un número, un cliente y un porcentaje de IVA
        public Factura(string numeroFactura, Cliente cliente, decimal porcentajeIva) {
            NumeroFactura = numeroFactura;
            FechaEmision = DateTime.Now;
            ClienteAsociado = cliente;
            PorcentajeIva = porcentajeIva;
            Estado = "Activa";
        }

        // Agrega un detalle a la factura. Si el producto ya existe, se suma la cantidad.
        public void AgregarDetalle(DetalleFactura detalle) {
            if (detalle == null) throw new ArgumentNullException("detalle");

            DetalleFactura existente = Detalles
                .FirstOrDefault(d => d.CodigoProducto == detalle.CodigoProducto);

            if (existente != null) {
                existente.Cantidad += detalle.Cantidad;
            }
            else {
                detalle.IdDetalle = Detalles.Count == 0 ? 1 : Detalles.Max(d => d.IdDetalle) + 1;
                Detalles.Add(detalle);
            }
            CalcularTotales();
        }

        // Remueve un detalle de la factura por su IdDetalle
        public void RemoverDetalle(int idDetalle) {
            DetalleFactura detalle = Detalles.FirstOrDefault(d => d.IdDetalle == idDetalle);
            if (detalle != null) {
                Detalles.Remove(detalle);
                CalcularTotales();
            }
        }

        // Calcula el subtotal, el valor del IVA y el total de la factura
        public void CalcularTotales() {
            // Calcula el subtotal sumando los subtotales de cada detalle
            Subtotal = Detalles.Sum(d => d.SubtotalLinea);

            // Calcula el valor del IVA aplicando el porcentaje al subtotal
            ValorIva = Math.Round(Subtotal * (PorcentajeIva / 100m), 2);

            // Calcula el total sumando el subtotal y el valor del IVA
            Total = Subtotal + ValorIva;
        }

    }
}

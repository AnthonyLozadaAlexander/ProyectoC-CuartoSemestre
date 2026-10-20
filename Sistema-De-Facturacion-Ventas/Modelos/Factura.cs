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

        public Factura(string numeroFactura, Cliente cliente, decimal porcentajeIva) {
            NumeroFactura = numeroFactura;
            FechaEmision = DateTime.Now;
            ClienteAsociado = cliente;
            PorcentajeIva = porcentajeIva;
            Estado = "Activa";
        }

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

        public void RemoverDetalle(int idDetalle) {
            DetalleFactura detalle = Detalles.FirstOrDefault(d => d.IdDetalle == idDetalle);
            if (detalle != null) {
                Detalles.Remove(detalle);
                CalcularTotales();
            }
        }

        public void CalcularTotales() {
            Subtotal = Detalles.Sum(d => d.SubtotalLinea);
            ValorIva = Math.Round(Subtotal * (PorcentajeIva / 100m), 2);
            Total = Subtotal + ValorIva;
        }

    }
}

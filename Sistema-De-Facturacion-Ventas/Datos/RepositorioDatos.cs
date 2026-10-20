using Sistema_De_Facturacion_Ventas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_De_Facturacion_Ventas.Datos {
     public class RepositorioDatos {
        public const decimal IvaPorDefecto = 15m;

        public static List<Categoria> Categorias { get; } = new List<Categoria>();
        public static List<Cliente> Clientes { get; } = new List<Cliente>();
        public static List<Producto> Productos { get; } = new List<Producto>();
        public static List<Factura> Facturas { get; } = new List<Factura>();
        public static List<Usuario> Usuarios { get; } = new List<Usuario>();

        static RepositorioDatos() {
            // Categorias
            Categorias.Add(new Categoria(1, "Electrónica", "Dispositivos y accesorios"));
            Categorias.Add(new Categoria(2, "Víveres", "Productos de consumo básico"));
            Categorias.Add(new Categoria(3, "Papelería", "Útiles y oficina"));

            // Productos (P002 con stock critico a proposito, para probar la alerta)
            Productos.Add(new Producto("P001", "Mouse inalámbrico", 12.50m, 20, 1));
            Productos.Add(new Producto("P002", "Arroz 1kg", 1.20m, 3, 2));
            Productos.Add(new Producto("P003", "Teclado mecánico", 45.00m, 8, 1));
            Productos.Add(new Producto("P004", "Aceite 1L", 3.50m, 30, 2));
            Productos.Add(new Producto("P005", "Cuaderno universitario", 2.25m, 50, 3));
            Productos.Add(new Producto("P006", "Audífonos", 18.00m, 12, 1));

            // Clientes
            Clientes.Add(new Cliente("0912345678", "Ana", "Pérez", "Av. 9 de Octubre", "0991234567", "ana@mail.com"));
            Clientes.Add(new Cliente("0923456789", "Luis", "Mora", "Calle 10 y Rumichaca", "0987654321", "luis@mail.com"));
            Clientes.Add(new Cliente("0934567890", "Marta", "Ruiz", "Cdla. Kennedy", "0976543210", "marta@mail.com"));

            // Usuarios
            Usuarios.Add(new Usuario("admin", "admin123", "Administrador del Sistema", "Administrador"));
            Usuarios.Add(new Usuario("cajero", "cajero123", "Cajero de Turno", "Cajero"));

            // Una factura de ejemplo para que Historial y Dashboard tengan datos desde el inicio
            Factura ejemplo = new Factura(GenerarNumeroFactura(), Clientes[0], IvaPorDefecto);
            ejemplo.AgregarDetalle(new DetalleFactura(0, "P001", "Mouse inalámbrico", 12.50m, 2));
            ejemplo.AgregarDetalle(new DetalleFactura(0, "P003", "Teclado mecánico", 45.00m, 1));
            RegistrarFactura(ejemplo);
        }

        // ---------- Consultas ----------

        public static Cliente BuscarCliente(string cedulaRuc) {
            return Clientes.FirstOrDefault(c => c.CedulaRuc == cedulaRuc);
        }

        public static Producto BuscarProducto(string codigo) {
            return Productos.FirstOrDefault(p =>
                string.Equals(p.Codigo, codigo, StringComparison.OrdinalIgnoreCase));
        }

        public static Factura BuscarFactura(string numeroFactura) {
            return Facturas.FirstOrDefault(f => f.NumeroFactura == numeroFactura);
        }

        public static Categoria BuscarCategoria(int idCategoria) {
            return Categorias.FirstOrDefault(c => c.IdCategoria == idCategoria);
        }

        // ---------- Facturación ----------

        public static string GenerarNumeroFactura() {
            return "FAC-" + (Facturas.Count + 1).ToString("D4");
        }

        // Valida stock, lo descuenta y guarda la factura. Lanza InvalidOperationException si algo falla.
        public static void RegistrarFactura(Factura factura) {
            if (factura == null) throw new ArgumentNullException("factura");
            if (factura.Detalles.Count == 0)
                throw new InvalidOperationException("La factura no tiene productos.");

            // 1) Validar TODO antes de descontar nada
            foreach (DetalleFactura d in factura.Detalles) {
                Producto p = BuscarProducto(d.CodigoProducto);
                if (p == null || !p.ValidarStock(d.Cantidad))
                    throw new InvalidOperationException("Stock insuficiente para " + d.NombreProducto);
            }

            // 2) Descontar
            foreach (DetalleFactura d in factura.Detalles)
                BuscarProducto(d.CodigoProducto).DecrementarStock(d.Cantidad);

            factura.CalcularTotales();
            factura.Estado = "Activa";
            Facturas.Add(factura);
        }

        // Marca la factura como anulada y devuelve el stock. Lanza InvalidOperationException si ya estaba anulada.
        public static void AnularFactura(string numeroFactura) {
            Factura f = BuscarFactura(numeroFactura);
            if (f == null)
                throw new InvalidOperationException("La factura no existe.");
            if (f.Estado == "Anulada")
                throw new InvalidOperationException("La factura ya está anulada.");

            foreach (DetalleFactura d in f.Detalles) {
                Producto p = BuscarProducto(d.CodigoProducto);
                if (p != null) p.IncrementarStock(d.Cantidad);
            }
            f.Estado = "Anulada";
        }

    }
}

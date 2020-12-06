using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP4
{
    /// <summary>
    /// clase 25. Métodos de Extensión.
    /// Esta clase agrega un método a la clase Factura.
    /// </summary>
    public static class FacturaExtension
    {
        /// <summary>
        /// Realiza un string customizado a partir de un objeto Factura.
        /// </summary>
        /// <param name="f">objeto Factura</param>
        /// <returns>string customizado</returns>
        public static string CustomPrintFactura (this Factura f)
        {
            StringBuilder strBld = new StringBuilder("-----FACTURA-----")
                .AppendLine()
                .AppendLine($"Tipo: {f.TipoFactura}")
                .AppendLine($"Fecha: {f.Fecha}")
                .AppendLine($"Cliente:\n\tDNI: {f.Cliente.DNI}\n\tNombre: {f.Cliente.Nombre}")
                .AppendLine($"Vendedor:\n\tDNI: {f.Vendedor.DNI}\n\tNombre: {f.Vendedor.Nombre}")
                .AppendLine("Productos:");

            foreach (Producto p in f.Productos.LProductos)
            {
                strBld.AppendLine($"\tID: {p.ID}\n\tNombre: {p.Nombre}\n\tPrecio: {p.Precio}\n\tTipo: {p.Tipo}\n\tCantidad: {p.Cantidad}");
            }
            strBld.AppendLine("-----------------");
            return strBld.ToString();
        }
    }
}

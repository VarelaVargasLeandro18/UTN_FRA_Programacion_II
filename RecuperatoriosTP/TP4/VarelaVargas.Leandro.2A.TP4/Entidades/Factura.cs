using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase 23. Hilos.
    /// Clase 19. Archivos y Serialización.
    /// Esta clase contendrá toda la información para la generación de una factura.
    /// Permitirá Serialización y creación de archivos de texto.
    /// </summary>
    [Serializable]
    public class Factura
    {
        private char tipoFactura;
        private Vendedor vendedor;
        private Cliente cliente;
        private DateTime fecha;
        private Productos<Producto> productos;

        public Factura()
        {
            this.fecha = DateTime.Now;
        }

        #region Propiedades
        public char TipoFactura
        {
            get { return this.tipoFactura; }
            set { this.tipoFactura = value; }
        }

        public Vendedor Vendedor
        {
            get { return this.vendedor; }
            set { this.vendedor = value; }
        }

        public Cliente Cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }

        public DateTime Fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

        public Productos<Producto> Productos
        {
            get { return this.productos; }
            set { this.productos = value; }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Clase 23. Hilos.
        /// Invoca un hilo que guardará la factura como un Txt.
        /// </summary>
        public void GuardarComoTxt()
        {
            Thread threadGuardarFactura = new Thread(this.privadoGuardarComoTxt);
            threadGuardarFactura.Start();
        }

        /// <summary>
        /// Clase 23. Hilos.
        /// Invoca un hilo que serializará la factura en formato Xml.
        /// </summary>
        public void GuardarComoXml()
        {
            Thread threadSerializarFactura = new Thread(this.privadoGuardarComoXml);
            threadSerializarFactura.Start();
        }

        /// <summary>
        /// Clase 17. Archivos y Serialización.
        /// Guardará la factura en la carpeta "Documentos" del usuario, cuyo nombre será "Factura" seguido de la fecha de Emisión de la factura
        /// </summary>
        private void privadoGuardarComoTxt()
        {
            string nombreArchivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + $"Factura {this.fecha.ToString("dd_MM_yyyy HH_mm_ss")}.txt";
            using (StreamWriter writer = File.CreateText(nombreArchivo))
            {
                try
                {
                    writer.Write(this.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Clase 17. Archivos y Serialización.
        /// Guardará la factura en la carpeta "Documentos" del usuario, cuyo nombre será "Factura" seguido de la fecha de Emisión de la factura en formato Xml
        /// </summary>
        private void privadoGuardarComoXml()
        {
            string nombreArchivo = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + $"Factura {this.fecha.ToString("dd_MM_yyyy HH_mm_ss")}.xml";
            
            using ( StreamWriter writer = File.CreateText(nombreArchivo) )
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Factura));
                    serializer.Serialize(writer, this);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder($"FACTURA TIPO {this.tipoFactura}\n")
                .AppendLine("Fecha:" + this.fecha.ToString("G"))
                .AppendLine(this.productos.ToString())
                .AppendLine(this.cliente.ToString())
                .AppendLine(this.vendedor.ToString());
            return strBuilder.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Permitirá agregar Productos a una Factura.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Factura operator +(Factura f, Producto p)
        {
            Factura ret = copyData(f);

            bool operacionExitosa = ret.Productos + p;

            return ret;
        }

        /// <summary>
        /// Permitirá eliminar Productos a una Factura.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Factura operator -(Factura f, Producto p)
        {
            Factura ret = copyData(f);

            if (!ret.Productos.LProductos.Contains(p))
                ret.Productos.LProductos.Add(p);

            return ret;
        }

        /// <summary>
        /// Permitirá copiar de forma segura los datos de una factura a otra.
        /// Evita usar el operador '='
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        private static Factura copyData (Factura f)
        {
            Factura ret = new Factura();
            ret.Cliente = new Cliente();
            ret.Vendedor = new Vendedor();
            ret.Productos = new Productos<Producto>();

            ret.Cliente.DNI = f.Cliente.DNI;
            ret.Cliente.Nombre = f.Cliente.Nombre;

            ret.Vendedor.DNI = f.Cliente.DNI;
            ret.Vendedor.Nombre = f.Vendedor.Nombre;

            foreach (Producto prod in f.Productos.LProductos)
                ret.Productos.LProductos.Add(prod);

            return ret;
        }
        #endregion

    }
}

using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{

    /// <summary>
    /// Clase para creación de archivos XML.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T>
    {

        /// <summary>
        /// Guarda un archivo en formato XML.
        /// </summary>
        /// <param name="archivo">Path del archivo.</param>
        /// <param name="datos">Objeto a guardar.</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool ret = false;

            try
            {
                using (XmlTextWriter xmlWriter = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer((typeof(T)));
                    serializer.Serialize(xmlWriter, datos);
                    ret = true;
                }
            }
            catch ( Exception ex )
            {
                throw new ArchivosException(ex);
            }

            return ret;
        }

        /// <summary>
        /// Deserializa un archivo XML y crea un objeto.
        /// </summary>
        /// <param name="archivo">Path del archivo.</param>
        /// <param name="datos">Objeto a crear.</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool ret = false;

            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer((typeof(T)));
                    datos = (T)serializer.Deserialize(reader);
                    ret = true;
                }
            }
            catch ( Exception ex )
            {
                throw new ArchivosException(ex);
            }

            return ret;
        }
    }
}

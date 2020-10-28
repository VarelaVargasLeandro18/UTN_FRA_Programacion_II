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
    public class Xml<T> : IArchivo<T>
    {
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

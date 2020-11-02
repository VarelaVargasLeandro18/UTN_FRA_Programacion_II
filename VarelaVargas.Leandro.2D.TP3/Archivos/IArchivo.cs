using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{

    /// <summary>
    /// Interfaz de creación de Archivos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IArchivo <T>
    {

        /// <summary>
        /// Permitirá guardar un archivo en el path deseado.
        /// </summary>
        /// <param name="archivo">Path del archivo.</param>
        /// <param name="datos">Datos a guardas</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Permitirá leer un archivo del path deseado.
        /// </summary>
        /// <param name="archivo">Path del archivo.</param>
        /// <param name="datos">Tipo de objeto a leer.</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);

    }
}

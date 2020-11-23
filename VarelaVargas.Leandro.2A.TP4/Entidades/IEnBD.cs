using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IEnBD
    {
        /// <summary>
        /// Método donde se dará la actualización de los atributos de las clases.
        /// </summary>
        /// <param name="NombreTabla">Nombre de la Tabla donde se obtendrán los datos.</param>
        void actualizarMedianteBD(string NombreTabla);
    }
}

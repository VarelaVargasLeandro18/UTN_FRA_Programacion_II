using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesEntidades
{

    /// <summary>
    /// Clase 15. Exceptions.
    /// Esta exception se lanzará en caso de que los datos de la base de Datos de Personas no puedan ser obtenidos.
    /// </summary>
    public class ExceptionErrorActualizacionPersonas : Exception
    {
        private static string mensaje = "Error al actualizar Personas. Los datos no pudieron ser obtenidos.";

        public ExceptionErrorActualizacionPersonas(Exception innerException)
            : base(mensaje, innerException)
        { }

        public ExceptionErrorActualizacionPersonas(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}

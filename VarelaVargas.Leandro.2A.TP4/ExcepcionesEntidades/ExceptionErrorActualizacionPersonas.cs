using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesEntidades
{
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

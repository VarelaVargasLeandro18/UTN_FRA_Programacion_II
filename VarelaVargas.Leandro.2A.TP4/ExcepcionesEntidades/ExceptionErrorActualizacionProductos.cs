using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcepcionesEntidades
{
    public class ExceptionErrorActualizacionProductos : Exception
    {
        private static string mensaje = "Error al actualizar Productos. No pudieron obtenerse los datos.";

        public ExceptionErrorActualizacionProductos(Exception innerException)
            : base(mensaje, innerException)
        { }

        public ExceptionErrorActualizacionProductos(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

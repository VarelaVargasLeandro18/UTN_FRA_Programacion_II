using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {

        private static string Msg = "No hay profesores disponibles para esta materia.";

        public SinProfesorException ()
            : base (Msg)
        { }

        public SinProfesorException(string msg)
            :base (msg)
        { }

        public SinProfesorException (Exception innerException)
            : base ( Msg, innerException )
        { }

        public SinProfesorException (string msg, Exception innerException)
            : base (msg, innerException)
        { }

    }
}

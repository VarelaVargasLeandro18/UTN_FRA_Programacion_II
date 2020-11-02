using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        private static string Msg = "Este alumno ya se encuentra inscripto.";

        public AlumnoRepetidoException()
            : base ( Msg )
        { }

        public AlumnoRepetidoException(Exception innerException)
            : base ( Msg, innerException )
        { }

        public AlumnoRepetidoException(string msg, Exception innerException)
            : base (msg, innerException)
        { }

    }
}

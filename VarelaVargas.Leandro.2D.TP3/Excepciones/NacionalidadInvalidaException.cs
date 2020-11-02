using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        private static string Msg = "La nacionalidad no se condice con el número de DNI.";

        public NacionalidadInvalidaException()
            : base(Msg)
        { }

        public NacionalidadInvalidaException(string msg)
            : base (msg)
        { }

        public NacionalidadInvalidaException(Exception innerException)
            : base (Msg, innerException)
        { }

        public NacionalidadInvalidaException(string msg, Exception innerException)
            : base (msg, innerException)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private static string Msg = "Formato de DNI Inválido. Procure utilizar únicamente 8 cifras.";

        public DniInvalidoException()
            : base(Msg)
        { }

        public DniInvalidoException(Exception e)
            : base(Msg, e)
        { }

        public DniInvalidoException(string message)
            : base(message)
        { }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        { }

    }
}

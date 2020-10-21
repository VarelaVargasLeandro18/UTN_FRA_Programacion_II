using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {

        public DniInvalidoException()
            : base("Formato de DNI Inválido. Procure utilizar únicamente 8 números del 0 al 9.")
        { }

        public DniInvalidoException(Exception e)
            : base("DNI Inválido", e)
        { }

        public DniInvalidoException(string message)
            : base(message)
        { }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        { }

    }
}

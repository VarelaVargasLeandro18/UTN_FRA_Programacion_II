using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {

        public ArchivosException()
            : base ("No se ha podido crear el archivo.")
        {}

        public ArchivosException ( string message )
            : base ( message )
        {}

        public ArchivosException(Exception innerException)
            : base("No se ha podido crear el archivo.", innerException)
        {}

    }
}

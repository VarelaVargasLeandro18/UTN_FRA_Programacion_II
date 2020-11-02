using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        private static string Msg = "No se ha podido crear el archivo.";

        public ArchivosException()
            : base (Msg)
        {}

        public ArchivosException ( string msg )
            : base ( msg )
        {}

        public ArchivosException(Exception innerException)
            :base (Msg, innerException)
        { }

        public ArchivosException( string msg, Exception innerException)
            : base(msg, innerException)
        {}

    }
}

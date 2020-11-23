using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Factura
    {
        private Thread threadGuardarFactura;

        public Factura ()
        {}

        private void GuardarComoTxt ()
        {
            using (StreamWriter writer = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\" + $"{0}.txt"  ) )
            {

            }
        }

    }
}

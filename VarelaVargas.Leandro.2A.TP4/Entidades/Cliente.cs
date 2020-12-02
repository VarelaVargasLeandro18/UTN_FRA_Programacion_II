using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona
    {
        public Cliente()
        { }

        public Cliente (Persona p)
            : base (p.DNI, p.Nombre)
        {}

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder("CLIENTE\n");
            strBuilder.AppendLine(base.ToString());

            return strBuilder.ToString();
        }

    }
}

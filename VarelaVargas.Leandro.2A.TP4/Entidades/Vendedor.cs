using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vendedor : Persona
    {
        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder(base.ToString());
            strBuilder.AppendLine("Vendedor");

            return strBuilder.ToString();
        }
    }
}

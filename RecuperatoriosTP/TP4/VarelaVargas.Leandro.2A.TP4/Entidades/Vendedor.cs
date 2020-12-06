using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Vendedor extiende de Persona.
    /// </summary>
    public class Vendedor : Persona
    {
        public Vendedor()
        { }

        public Vendedor(Persona p)
            : base(p.DNI, p.Nombre)
        { }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder("VENDEDOR\n");
            strBuilder.AppendLine(base.ToString());

            return strBuilder.ToString();
        }
    }
}

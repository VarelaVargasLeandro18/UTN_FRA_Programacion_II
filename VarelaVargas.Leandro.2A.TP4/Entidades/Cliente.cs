using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase Cliente extiende de Persona
    /// </summary>
    public class Cliente : Persona
    {
        #region Constructores
        public Cliente()
        { }

        public Cliente (Persona p)
            : base (p.DNI, p.Nombre)
        {}
        #endregion

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder("CLIENTE\n");
            strBuilder.AppendLine(base.ToString());

            return strBuilder.ToString();
        }

    }
}

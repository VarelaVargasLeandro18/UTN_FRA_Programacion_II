using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Esta clase es un Tipo de Producto
    /// </summary>
    public class Comida : Producto
    {
        public override string Tipo
        {
            get { return "Comida"; }
        }
    }
}

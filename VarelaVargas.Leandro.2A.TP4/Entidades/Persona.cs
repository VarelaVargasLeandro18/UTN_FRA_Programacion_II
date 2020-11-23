using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona
    {
        private int dni;
        private string nombre;

        #region Propiedades
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        #endregion

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder($"DNI: {this.dni}\n")
                .AppendLine($"Nombre: {this.nombre}");

            return strBuilder.ToString();
        }

    }
}

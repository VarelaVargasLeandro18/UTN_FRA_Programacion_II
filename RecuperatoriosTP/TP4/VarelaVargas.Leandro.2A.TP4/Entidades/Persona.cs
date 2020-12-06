using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Esta clase contenerá los datos de una persona.
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Vendedor))]
    [XmlInclude(typeof(Cliente))]
    public class Persona
    {
        private int dni;
        private string nombre;

        #region Constructores
        public Persona()
        { }

        public Persona (int dni, string nombre)
        {
            this.dni = dni;
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        public int DNI
        {
            get { return this.dni; }
            set { this.dni = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                Regex soloLetras = new Regex(@"[\w ]+");

                if (soloLetras.IsMatch(value))
                    this.nombre = value;
            }
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

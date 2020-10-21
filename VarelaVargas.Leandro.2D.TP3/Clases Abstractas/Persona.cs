using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Persona
    {

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Campos
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                Regex regEx = new Regex("[\\w\\ ]+");
                Match matcher = regEx.Match(value);

                if (matcher.Success)
                    this.nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                Regex regEx = new Regex("[\\w\\ ]+");
                Match matcher = regEx.Match(value);

                if (matcher.Success)
                    this.apellido = value;
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }

            set
            {
                this.nacionalidad = value;
            }
        }


        #endregion

    }
}

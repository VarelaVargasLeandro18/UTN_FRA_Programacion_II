using System.Text;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{

    /// <summary>
    /// Universitario abstracto, hereda de Persona.
    /// </summary>
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        public Universitario()
            :base()
        {}

        public Universitario (int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Devuelve los Datos del Universitario.
        /// </summary>
        /// <returns>Datos del Universitario.</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder retStrBld = new StringBuilder(base.ToString())
                .Append("\nLEGAJO NÚMERO: ")
                .Append(this.legajo)
                .AppendLine();

            return retStrBld.ToString();
        }

        protected abstract string ParticiparEnClase();
        #endregion

        #region Métodos - Override
        /// <summary>
        /// Comprueba que el objeto pasado sea del Tipo Universitario y comprueba que los legajos coincidan.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return !(obj is null) 
                && obj.GetType() == this.GetType()
                && ((Universitario)obj).legajo == this.legajo;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba que los objetos no sean nulos y por consiguiente utiliza el método Equals.
        /// </summary>
        /// <param name="pg1">Operando Uno.</param>
        /// <param name="pg2">Operando Dos.</param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return !(pg1 is null) && !(pg2 is null) && pg1.Equals(pg2);
        }

        /// <summary>
        /// Devuelve el valor contrario de la operación "=="
        /// </summary>
        /// <param name="pg1">Operando Uno.</param>
        /// <param name="pg2">Operando Dos.</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}

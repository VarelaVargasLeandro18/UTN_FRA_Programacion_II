using Excepciones;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{

    /// <summary>
    /// Persona abstracta.
    /// </summary>
    public abstract class Persona
    {
        /// <summary>
        /// Nacionalidades que puede tomar una persona
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Campos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Apellido. Obtiene y Settea el Apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }

            set
            {
                try
                {
                    this.apellido = this.ValidarNombreApellido(value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Propiedad DNI. Obtiene y Settea el DNI como un Int. Realiza Validaciones pertinentes.
        /// Devuelve NacionalidadInvalidaException y DniInvalidoException.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            
            set
            {
                try
                {
                    this.dni = this.ValidarDni(this.Nacionalidad, value.ToString());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Propiedad Nombre. Obtiene y Settea el Nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }

            set
            {
                try
                {
                    this.nombre = this.ValidarNombreApellido(value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Propiedad Nacionalidad. Obtiene y Settea la Nacionalidad de la Persona.
        /// </summary>
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

        /// <summary>
        /// Propiedad StringToDNI. Obtiene y Settea el DNI como un String. Realiza Validaciones pertinentes.
        /// Devuelve NacionalidadInvalidaException y DniInvalidoException.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {
                    this.dni = this.ValidarDni(this.Nacionalidad, value);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        #endregion

        #region Constructor
        public Persona()
        { }

        public Persona ( string nombre, string apellido, ENacionalidad nacionalidad )
        {
            try
            {
                this.Nombre = nombre;
                this.Apellido = apellido;
                this.Nacionalidad = nacionalidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Persona ( string nombre, string apellido, int dni, ENacionalidad nacionalidad )
            : this ( nombre, apellido, nacionalidad )
        {
            try
            {
                this.DNI = dni;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, int.Parse(dni), nacionalidad)
        { }
        #endregion

        #region Metodos
        /// <summary>
        /// Valida que el DNI dado de la persona se corresponda con su nacionalidad.
        /// Devuelve NacionalidadInvalidaException en caso de que el DNI no se corresponda con la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI a evaluar.</param>
        /// <returns>Retorna el mismo DNI.</returns>
        private int ValidarDni (ENacionalidad nacionalidad, int dato)
        {
            int ret;

            if (nacionalidad == ENacionalidad.Argentino && (dato >= 1 && dato <= 89999999))
                ret = dato;
            else if (nacionalidad == ENacionalidad.Extranjero && (dato >= 90000000 && dato <= 99999999))
                ret = dato;
            else
                throw new NacionalidadInvalidaException();

            return ret;
        }

        /// <summary>
        /// Valida que el formato del DNI dado sea correcto y posteriormente que su nacionalidad se corresponda con el tipo de DNI.
        /// Devuelve DniInvalidoException en caso de que el formato no sea correcto (no tenga 8 números). 
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la Persona.</param>
        /// <param name="dato">DNI a evaluar.</param>
        /// <returns>Retorna el mismo DNI en formato Int.</returns>
        private int ValidarDni (ENacionalidad nacionalidad, string dato)
        {
            Regex regexFormato = new Regex("^([\\d]{8})$");
            Match matcherFormato = regexFormato.Match(dato);
            string ret;

            if (matcherFormato.Success)
                ret = dato;
            else
                throw new DniInvalidoException();
            
            return this.ValidarDni(nacionalidad, int.Parse(ret));
        }

        /// <summary>
        /// Valida que el Nombre y Apellido de una persona
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido (string dato)
        {
            Regex regexNomApe = new Regex("[\\w\\ ]+");
            Match matcherNomApe = regexNomApe.Match(dato);
            string ret = null;

            if (matcherNomApe.Success)
                ret = dato;

            return ret;
        }
        #endregion

        #region Metodos - Override
        /// <summary>
        /// Devuelve los datos de la Persona como un String.
        /// </summary>
        /// <returns>Datos de la Persona.</returns>
        public override string ToString()
        {
            StringBuilder toStr = new StringBuilder();

            toStr.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
            toStr.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");

            return toStr.ToString();
        }
        #endregion

    }
}

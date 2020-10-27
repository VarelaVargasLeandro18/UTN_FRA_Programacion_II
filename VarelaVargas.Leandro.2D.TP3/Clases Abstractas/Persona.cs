using Excepciones;
using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {

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

using EntidadesAbstractas;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    /// <summary>
    /// Implementación de Clase Abstracta Universitario.
    /// </summary>
    public class Alumno : Universitario
    {
        
        /// <summary>
        /// Estados de Cuenta del alumno.
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region Campos
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores
        public Alumno()
            : base()
        { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this (id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos - Override

        /// <summary>
        /// Devuelve los Datos del Alumno en formato String.
        /// </summary>
        /// <returns>Datos del Alumno.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retStrBld = new StringBuilder(base.MostrarDatos())
                .Append("\nESTADO DE CUENTA: ")
                .AppendLine($"{this.estadoCuenta}")
                .AppendLine(this.ParticiparEnClase());

            return retStrBld.ToString();
        }

        /// <summary>
        /// Devuelve la clase que toma el Alumno.
        /// </summary>
        /// <returns>"TOMA CLASE DE: " y Clase.</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma}";
        }

        /// <summary>
        /// Hace públicos los datos del Alumno en formato String.
        /// </summary>
        /// <returns>Datos del Alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Comprueba que el alumno no sea 'null' y que además el alumno tome la clase especificada.
        /// </summary>
        /// <param name="a">Alumno a evaluar clase.</param>
        /// <param name="clase">Clase a comprobar que el alumno tome.</param>
        /// <returns>True si toma la clase. False si no la toma.</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return !(a is null) && a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        /// <summary>
        /// Devuelve el valor contrario a la operacion "==".
        /// </summary>
        /// <param name="a">Alumno a evaluar que NO tome la clase.</param>
        /// <param name="clase">Clase a evaluar que NO tome el Alumno.</param>
        /// <returns>True si el Alumno NO toma la clase especificada. Flase caso contrario.</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion

    }
}

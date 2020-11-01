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
    public class Alumno : Universitario
    {
        
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
        protected override string MostrarDatos()
        {
            StringBuilder retStrBld = new StringBuilder(base.MostrarDatos())
                .Append("\nESTADO DE CUENTA: ")
                .AppendLine($"{this.estadoCuenta}")
                .AppendLine(this.ParticiparEnClase());

            return retStrBld.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma}";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Alumno a, EClases clase)
        {
            return !(a is null) && a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }

        public static bool operator !=(Alumno a, EClases clase)
        {
            return a.claseQueToma != clase;
        }
        #endregion

    }
}

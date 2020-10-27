using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
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

        #region Metodos
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

        #region Metodos - Override
        public override bool Equals(object obj)
        {
            bool sameType = obj.GetType() == this.GetType();
            Console.WriteLine(this.GetType());
            return sameType && ((Universitario)obj).legajo == this.legajo;
        }
        #endregion

        #region Operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}

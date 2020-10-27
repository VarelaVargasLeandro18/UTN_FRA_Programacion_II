using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {

        #region Campos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        static Profesor()
        {
            Profesor.random = new Random();
        }

        private Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            Profesor aux = new Profesor();
            this.clasesDelDia = aux.clasesDelDia;
            aux = null;
        }
        #endregion

        #region Metodos
        private void _randomClases()
        {
            int claseUno = Profesor.random.Next(0, 3);
            int claseDos = Profesor.random.Next(0, 3);

            this.clasesDelDia.Enqueue( ((EClases)claseUno) );
            this.clasesDelDia.Enqueue( ((EClases)claseDos) );
        }
        #endregion

        #region Metodos - Override
        protected override string MostrarDatos()
        {
            StringBuilder retStrBuilder = new StringBuilder(base.MostrarDatos())
                .AppendLine(this.ParticiparEnClase());

            return retStrBuilder.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder retStrBld = new StringBuilder("CLASES DEL DÍA\n");

            foreach (EClases clase in this.clasesDelDia)
                retStrBld.AppendLine(clase.ToString());

            return retStrBld.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Profesor i, EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}

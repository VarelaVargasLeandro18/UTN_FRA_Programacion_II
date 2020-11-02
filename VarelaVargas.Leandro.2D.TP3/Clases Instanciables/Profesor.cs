using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{

    /// <summary>
    /// Implementación de la Clase abstracta Universitario.
    /// No heredable.
    /// </summary>
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

        public Profesor()
        {
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Le asigna dos clases aleatorias al profesor.
        /// </summary>
        private void _randomClases()
        {
            int claseUno = Profesor.random.Next(0, 4);
            int claseDos = Profesor.random.Next(0, 4);

            this.clasesDelDia.Enqueue( ((EClases)claseUno) );
            this.clasesDelDia.Enqueue( ((EClases)claseDos) );
        }
        #endregion

        #region Métodos - Override

        /// <summary>
        /// Devuelve los Datos del profesor en formato string.
        /// </summary>
        /// <returns>Datos del Profesor.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder retStrBuilder = new StringBuilder(base.MostrarDatos())
                .AppendLine(this.ParticiparEnClase());

            return retStrBuilder.ToString();
        }

        /// <summary>
        /// Devuelve las 2 clases en las que enseña el profesor.
        /// </summary>
        /// <returns>"CLASES DEL DÍA\n" y las dos clases que toma.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder retStrBld = new StringBuilder("CLASES DEL DÍA\n");

            foreach (EClases clase in this.clasesDelDia)
                retStrBld.AppendLine(clase.ToString());

            return retStrBld.ToString();
        }

        /// <summary>
        /// Hace públicos los datos del Profesor.
        /// </summary>
        /// <returns>Datos del Profesor en formato string.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Comprueba que un Profesor de una clase.
        /// </summary>
        /// <param name="i">Profesor que se comprobará que dá una clase.</param>
        /// <param name="clase">Clase que se comprobará que el profesor dá.</param>
        /// <returns>True si el profesor dá la clase. Calso contrario false.</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            return i.clasesDelDia.Contains(clase);
        }

        /// <summary>
        /// Comprueba que un profesor NO dé una clase.
        /// </summary>
        /// <param name="i">Profesor que se comprobará que NO dé la clase.</param>
        /// <param name="clase">Clase que se comprobará que NO dé el Profesor.</param>
        /// <returns>Valor contrario de la operación "=="</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}

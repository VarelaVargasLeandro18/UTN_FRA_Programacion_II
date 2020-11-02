using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Clases_Instanciables.Universidad;

namespace Clases_Instanciables
{
    public class Jornada
    {

        #region Campos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructores
        private Jornada ()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Alumnos. Obtiene y Settea la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = value;
            }
        }
        
        /// <summary>
        /// Propiedad Clase. Obtiene y Settea la clase a la que corresponde la jornada.
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad Instructor. Obtiene y Settea el instructor de la Jornadad que dará la clase.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Método de Clase que Guarda los datos devueltos por un ToString de una Jornada en Jornada.txt.
        /// </summary>
        /// <param name="jornada">Jornada a guardar Datos.</param>
        /// <returns>Devuelve True si puede guardar la jornada. Caso contrario pasa una ArchivosException.</returns>
        public static bool Guardar ( Jornada jornada )
        {
            try
            {
                new Texto()
                    .Guardar("Jornada.txt", jornada.ToString());
            }
            catch ( Exception ex )
            {
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// Lee los datos del un archivo guardado como Jornada.txt
        /// </summary>
        /// <returns>Devuelve los datos del Archivo</returns>
        public static string Leer()
        {
            try
            {
                string datos = null;

                new Texto ()
                    .Leer("Jornada.txt", out datos);

                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Métodos - Override

        /// <summary>
        /// Devuelve los datos de la Jornada en formato string.
        /// </summary>
        /// <returns>Datos de la Jornada.</returns>
        public override string ToString()
        {
            StringBuilder retStrBld = new StringBuilder("JORNADA:\n")
                .AppendLine($"CLASE DE {this.Clase} POR {this.Instructor}")
                .AppendLine("ALUMNOS:");

            foreach (Alumno alumno in this.Alumnos)
            {
                retStrBld.AppendLine($"{alumno}");
            }

            return retStrBld.ToString();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Comprueba que un alumno pertenezca a una jornada.
        /// </summary>
        /// <param name="j">Jornada que se comprobará que contenga al alumno.</param>
        /// <param name="a">Alumno que se comprobará que esté en la jornada.</param>
        /// <returns></returns>
        public static bool operator ==( Jornada j, Alumno a )
        {
            return !(j is null) && !(a is null) && j.Alumnos.Contains(a);
        }

        /// <summary>
        /// Comprueba que un alumno NO pertenezca una jornada.
        /// </summary>
        /// <param name="j">Jornada donde se comprobará que el alumno NO pertenece.</param>
        /// <param name="a">Alumno que se comprobará que NO esté en la jornada.</param>
        /// <returns></returns>
        public static bool operator !=( Jornada j, Alumno a )
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega (en caso no contenerlo) un Alumno a una Jornada.
        /// </summary>
        /// <param name="j">Jornada donde se agregará el Alumno.</param>
        /// <param name="a">Alumno que se agregará a la jornada.</param>
        /// <returns>True si pudo agregarse el alumno. False en caso contrario.</returns>
        public static bool operator +( Jornada j, Alumno a )
        {
            bool ret = false;

            if (j != a)
            {
                j.alumnos.Add(a);
                ret = true;
            }

            return ret;
        }
        #endregion

    }
}

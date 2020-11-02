using Archivos;
using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{

    /// <summary>
    /// Clase Universidad. Contendrá Alumnos, Jornadas y Profesores que participan en ella.
    /// </summary>
    public class Universidad
    {

        /// <summary>
        /// Clases que da la Universidad.
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        #region Campos
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        #endregion

        #region Constructor
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad Alumnos. Obtiene y Settea la lista de Alumnos que pertenecen a la Universidad.
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
        /// Propiedad Instructores. Obtiene y Settea la lista de Profesores que pertenecen a la Universidad.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }

            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad Jornadas. Obtiene y Settea la lista de Jornadas que tiene la Universidad como Programa.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }

            set
            {
                this.jornadas = value;
            }
        }

        #region Indexador

        /// <summary>
        /// Indexador Jornada. Devuelve una Jornada que se encuentra en la posición especificada de la lista de Jornadas.
        /// </summary>
        /// <param name="i">Index de jornada.</param>
        /// <returns>Devuelve la Jornada.</returns>
        public Jornada this[int i]
        {

            get
            {
                return this.jornadas[i];
            }

            set
            {
                if (i >= 0 && i < this.jornadas.Count)
                    this.jornadas[i] = value;
            }

        }
        #endregion

        #endregion

        #region Métodos
        /// <summary>
        /// Guarda los datos de un objeto tipo Unversidad.
        /// </summary>
        /// <param name="uni"Universidad cuyos datos se quieren guardar.</param>
        /// <returns>True si pudo leer los datos. Caso contrario false.</returns>
        public static bool Guardar ( Universidad uni )
        {
            try
            {
                return new Xml<Universidad>()
                    .Guardar("Universidad.xml", uni);
            }
            catch ( Exception ex )
            {
                throw ex;
            }

        }

        /// <summary>
        /// Lee de un archivo XML ubicado en bin, un objeto de tipo Universidad y lo devuelve.
        /// </summary>
        /// <returns>La Universidad leída.</returns>
        public static Universidad Leer ()
        {
            Universidad uni = null;

            try
            {
                new Xml<Universidad>()
                    .Leer("Universidad.xml", out uni);
            }
            catch ( Exception ex )
            {
                throw ex;
            }

            return uni;
        }
        
        /// <summary>
        /// Muestra los datos de un Objeto tipo Universidad.
        /// </summary>
        /// <param name="uni">Universidad cuyos datos quieren mostrarse.</param>
        /// <returns>String con los datos de la Universidad.</returns>
        private static string MostrarDatos ( Universidad uni )
        {
            StringBuilder retStrBld = new StringBuilder()
                .AppendLine("<-------------------------------------------------->");

            foreach (Jornada jornada in uni.jornadas)
                retStrBld.AppendLine($"{jornada}");

            retStrBld.AppendLine("<-------------------------------------------------->");

            return retStrBld.ToString();
        }
        #endregion

        #region Métodos - Override
        /// <summary>
        /// Hace públicos los datos de la Universidad.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores

        #region Universidad - Alumno

        /// <summary>
        /// Comprobará que un Alumno pertenezca a una Universidad.
        /// </summary>
        /// <param name="g">Universidad en la que se comprobará que pertenezca el alumno especificado.</param>
        /// <param name="a">Alumno que se comprobará que exista en la Universidad.</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }

        /// <summary>
        /// Comprobará que un Alumno NO pertenezca a una Universidad.
        /// </summary>
        /// <param name="g">Universidad donde se comprobará que el Alumno NO exista.</param>
        /// <param name="a">Alumno que se comprobará que NO exista en una Universidad.</param>
        /// <returns>True si el Alumno no existe. Caso contrario False.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        
        /// <summary>
        /// Crea una copia de la Universidad 'u' y le agrega un alumno (de ser posible).
        /// </summary>
        /// <param name="u">Universidad que se copiará.</param>
        /// <param name="a">Alumno a agregar.</param>
        /// <returns>Nueva Universidad con el alumno agregado.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            Universidad ret = new Universidad();

            ret.alumnos = new List<Alumno>(u.alumnos);
            ret.jornadas = new List<Jornada>(u.jornadas);
            ret.profesores = new List<Profesor>(u.profesores);

            if (ret != a)
                ret.alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return ret;
        }
        #endregion

        #region Universidad - Profesor

        /// <summary>
        /// Comprueba que un profesor pertenezca a una Universidad.
        /// </summary>
        /// <param name="g">La Universidad donde se comprobará que el profesor pertenece.</param>
        /// <param name="i">Profesor que se comprobará que pertenezca a la Universidad.</param>
        /// <returns>True si pertenece. False si no pertenece.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.profesores.Contains(i);
        }

        /// <summary>
        /// Comprueba que un profesor NO pertenezca a una Universidad.
        /// </summary>
        /// <param name="g">Universidad donde se comprobará que el profesor NO pertenece.</param>
        /// <param name="i">Profesor que se comprobará que NO forma parte de la Universidad.</param>
        /// <returns>True si NO pertenece. False si sí.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Copia una Universidad y devuelvé otra con un profesor cargado (en caso de que no lo contenga).
        /// </summary>
        /// <param name="u">Universidad a la que se agregará el profesor.</param>
        /// <param name="i">Profesor a agregar en la Universidad.</param>
        /// <returns>Copia de la Universidad 'u' con un nuevo profesor.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            Universidad ret = new Universidad();

            ret.alumnos = new List<Alumno>(u.alumnos);
            ret.jornadas = new List<Jornada>(u.jornadas);
            ret.profesores = new List<Profesor>(u.profesores);

            if (ret != i)
                ret.profesores.Add(i);

            return ret;
        }
        #endregion

        #region Universidad - EClases

        /// <summary>
        /// Busca un profesor que dé la clase dentro de una Universidad.
        /// </summary>
        /// <param name="u">Universidad donde se buscará la clase.</param>
        /// <param name="clase">Clase que debe dar el profesor.</param>
        /// <returns>Profesor que dá la clase.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor ret = null;

            foreach ( Profesor prof in u.profesores )
            {
                if (prof == clase)
                {
                    ret = prof;
                    break;
                }
            }

            if (ret is null)
                throw new SinProfesorException("No hay profesor disponible para la clase: " + clase);

            return ret;
        }

        /// <summary>
        /// Busca el primero profesor que no dé la clase dentro de una Universidad.
        /// </summary>
        /// <param name="u">Universidad donde se buscará un profesor que no dé la clase.</param>
        /// <param name="clase">Clase que no debe dar un profesor.</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor ret = null;

            foreach ( Profesor prof in u.profesores )
            {
                if ( prof != clase )
                {
                    ret = prof;
                    break;
                }
            }

            return ret;
        }
        
        /// <summary>
        /// Crea una nueva jornada con un profesor que dé la clase especificada y una lista de alumnos que tomen dicha clase.
        /// Por consiguiente se creará una copia de la universidad 'g' con la Jornada agregada.
        /// </summary>
        /// <param name="g">Universidad que se copiará.</param>
        /// <param name="clase">Clase que se buscará que los profesores y alumnos tomen.</param>
        /// <returns>Devuelve una Universidad con la jornada creada. Si no se puede crear la jornada devuelve una copia de 'g'</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Universidad ret = null;
            try
            {
                ret = new Universidad();
                Jornada jornadaNueva = new Jornada ( clase, g == clase ) ;

                ret.alumnos = new List<Alumno>(g.alumnos);
                ret.profesores = new List<Profesor>(g.profesores);
                ret.jornadas = new List<Jornada>(g.jornadas);

                foreach ( Alumno alumno in g.alumnos )
                {
                    if (alumno == clase)
                        jornadaNueva.Alumnos.Add(alumno);
                }

                ret.jornadas.Add(jornadaNueva);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        #endregion

        #endregion

    }
}

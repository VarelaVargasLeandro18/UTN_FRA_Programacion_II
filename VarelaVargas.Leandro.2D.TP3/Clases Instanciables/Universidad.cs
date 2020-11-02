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
    public class Universidad
    {

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
        public static bool operator ==(Universidad g, Alumno a)
        {
            return g.Alumnos.Contains(a);
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
            
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
        public static bool operator ==(Universidad g, Profesor i)
        {
            return g.profesores.Contains(i);
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

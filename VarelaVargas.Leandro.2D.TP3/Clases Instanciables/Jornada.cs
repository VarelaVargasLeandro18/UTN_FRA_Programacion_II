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
        public static bool operator ==( Jornada j, Alumno a )
        {
            return !(j is null) && !(a is null) && j.Alumnos.Contains(a);
        }

        public static bool operator !=( Jornada j, Alumno a )
        {
            return !(j == a);
        }

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

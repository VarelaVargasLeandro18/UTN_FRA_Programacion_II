using ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase 21 y 22. SQL.
    /// Clase 18 Interfaces.
    /// Esta clase contendrá una lista de personas y podrá obtener datos de la BD.
    /// </summary>
    public class Personas : IEnBD
    {
        private List<Persona> lpersonas;

        public Personas()
        {
            this.lpersonas = new List<Persona>();
        }

        #region Métodos
        /// <summary>
        /// Devuelve los DNI de las personas en forma de lista.
        /// </summary>
        /// <returns>DNIs de Personas.</returns>
        public List<int> obtenerDNIs ()
        {
            List<int> DNIs = new List<int>();

            foreach (Persona persona in this.lpersonas)
                DNIs.Add(persona.DNI);
            
            return DNIs;
        }

        /// <summary>
        /// Obtiene el nombre de la persona cuyo DNI coincida.
        /// En caso de que no exista devuelve null.
        /// </summary>
        /// <param name="DNI"></param>
        /// <returns></returns>
        public string obtenerNombre (int DNI)
        {
            Persona ret = this.obtenerPersona(DNI);
            string Nombre = null;

            if (!(ret is null))
                Nombre = ret.Nombre;

            return Nombre;
        }

        /// <summary>
        /// Obtiene a la persona con el DNI requerido.
        /// </summary>
        /// <param name="DNI"></param>
        /// <returns></returns>
        public Persona obtenerPersona (int DNI)
        {
            Persona ret = null;

            foreach (Persona persona in this.lpersonas)
            {
                if (persona.DNI == DNI)
                {
                    ret = persona;
                    break;
                }
            }

            return ret;
        }

        /// <summary>
        /// Clase 18. Interfaces.
        /// Obtiene todas las personas que se encuentren en la Tabla especificada.
        /// </summary>
        /// <param name="NombreTabla"></param>
        public void actualizarMedianteBD(string NombreTabla)
        {
            SqlConnection conn = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                this.lpersonas = new List<Persona>();

                conn = new SqlConnection(Properties.Settings.Default.BDConn);
                string Comando = "SELECT * FROM " + NombreTabla + ";";
                Persona paraAgregarALaLista;
                command = new SqlCommand(Comando, conn);
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    paraAgregarALaLista = new Persona();
                    paraAgregarALaLista.DNI = (int)reader["DNI"];
                    paraAgregarALaLista.Nombre = (string)reader["Nombre"];
                    this.lpersonas.Add(paraAgregarALaLista);
                }

            }
            catch (SqlException ex)
            { 
                throw new ExceptionErrorActualizacionPersonas(ex);
            }
            finally
            {
                if (!(conn is null) && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("PERSONAS:\n");

            foreach (Persona persona in this.lpersonas)
                stringBuilder.AppendLine(persona.ToString());

            return stringBuilder.ToString();
        }
        #endregion

    }
}

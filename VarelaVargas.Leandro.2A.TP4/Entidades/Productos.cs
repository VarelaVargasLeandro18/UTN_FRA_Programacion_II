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
    public class Productos<T> : IEnBD where T : Producto
    {
        private List<T> lproductos;

        #region Métodos
        /// <summary>
        /// Develve en forma de Lista de enteros los IDs de los productos.
        /// </summary>
        /// <returns>IDs de los productos.</returns>
        public List<int> obtenerIDs()
        {
            List<int> IDs = new List<int>();

            foreach (T prod in this.lproductos)
                IDs.Add (prod.ID);

            return IDs;
        }

        /// <summary>
        /// Obtiene el nombre del producto cuyo id coincida con el proporcionado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Nombre del producto.</returns>
        public string obtenerNombre(int id)
        {
            string ret = null;

            foreach (T prod in this.lproductos)
            {
                if (prod.ID == id)
                {
                    ret = prod.Nombre;
                    break;
                }
            }

            return ret;
        }

        public void actualizarMedianteBD(string NombreTabla)
        {
            SqlConnection conn = null;
            SqlCommand command = null;
            SqlDataReader reader = null;

            try
            {
                this.lproductos = new List<T>();

                conn = new SqlConnection(Properties.Settings.Default.BDConn);
                string Comando = "SELECT * FROM " + NombreTabla;
                Producto paraAgregarALaLista;
                command = new SqlCommand(Comando, conn);
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (typeof(T) == typeof(Comida) && reader["Tipo"].Equals("Comida"))
                    {
                        paraAgregarALaLista = new Comida();
                        this.lproductos.Add((T)paraAgregarALaLista);
                    }
                    else if (typeof(T) == typeof(Limpieza) && reader["Tipo"].Equals("Limpieza"))
                    {
                        paraAgregarALaLista = new Limpieza();
                        this.lproductos.Add((T)paraAgregarALaLista);
                    }
                    else
                        paraAgregarALaLista = null;

                    if ( !(paraAgregarALaLista is null) )
                    {
                        paraAgregarALaLista.ID = (int)reader["id"];
                        paraAgregarALaLista.Nombre = (string)reader["Nombre"];
                        paraAgregarALaLista.Precio = float.Parse(reader["Precio"].ToString());
                    }

                }

            }
            catch (SqlException ex)
            {
                throw new ExceptionErrorActualizacionProductos (ex);
            }
            finally
            {
                if (!(conn is null) && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        #endregion
    }
}

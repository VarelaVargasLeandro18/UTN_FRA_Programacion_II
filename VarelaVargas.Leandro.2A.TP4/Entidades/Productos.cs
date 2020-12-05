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
    /// Clase 21 y 22. SQL
    /// Clase 17. Generics.
    /// Clase 18. Interfaces.
    /// En esta clase se almacenará una lista de Productos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class Productos<T> : IEnBD where T : Producto
    {
        private List<T> lproductos;

        #region Necesario para Serializar
        public Productos()
        {
            this.lproductos = new List<T>();
        }

        public List<T> LProductos
        {
            get { return this.lproductos; }
            set { this.lproductos = value; }
        }
        #endregion

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

        /// <summary>
        /// Obtiene un producto en la lista por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T obtenerProducto(int id)
        {
            T prod = null;

            foreach (T producto in this.lproductos)
            {
                if (producto.ID == id)
                {
                    prod = producto;
                    break;
                }
            }

            return prod;
        }

        /// <summary>
        /// Clase 18. Interfaces.
        /// Obtiene la lista de productos en Stock de la tabla.
        /// </summary>
        /// <param name="NombreTabla"></param>
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

        public override string ToString()
        {
            float precioTotal = 0;
            StringBuilder strBuilder = new StringBuilder("PRODUCTOS:\n");

            foreach (Producto p in this.lproductos)
            {
                precioTotal += p.Cantidad * p.Precio;
                strBuilder.AppendLine(p.ToString());
            }

            strBuilder.AppendLine("TOTAL: " + precioTotal);

            return strBuilder.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agrega un producto.
        /// </summary>
        /// <param name="ps"></param>
        /// <param name="p"></param>
        /// <returns>'True' si la operación es exitosa. 'False' caso contrario.</returns>
        public static bool operator +(Productos<T> ps, Producto p)
        {
            bool ret = !(ps.LProductos.Contains(p)) && !(p is null);

            try
            {
                if (ret)
                    ps.LProductos.Add((T)p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ret;
        }

        /// <summary>
        /// Elimina un producto.
        /// </summary>
        /// <param name="ps"></param>
        /// <param name="p"></param>
        /// <returns>'True' si la operación es exitosa. 'False' caso contrario.</returns>
        public static bool operator -(Productos<T>ps, Producto p)
        {
            bool ret = ps.LProductos.Contains(p);

            try
            {
                if (ret)
                    ps.LProductos.Remove((T)p);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return ret;
        }
        #endregion

    }
}

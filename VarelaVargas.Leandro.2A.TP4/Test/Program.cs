using Entidades;
using ExcepcionesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Coleccion De Personas
            Console.WriteLine("Creando colección personas...");
            Personas coleccionPersonas = new Personas();
            Console.WriteLine("Colección personas creada.");

            Persona p = new Persona(5940381, "Charly Cocía");
            Persona pnull = null;

            Cliente clienteUno = new Cliente();
            clienteUno.DNI = 54938209;
            clienteUno.Nombre = "ClienteUno";

            Vendedor vendedorUno = new Vendedor(p);

            Console.WriteLine("Agregando una persona con valor 'null'");
            if (!(coleccionPersonas + pnull))
                Console.WriteLine("No se puede agregar una persona null.");
            
            Console.WriteLine("\n\n");
            
            Console.WriteLine("Agregando: " + clienteUno.ToString());
            if (coleccionPersonas + clienteUno)
                Console.WriteLine("Agregado");
            
            Console.WriteLine("\n\n");
            
            Console.WriteLine("Agregando: " + vendedorUno.ToString());
            if (coleccionPersonas + vendedorUno)
                Console.WriteLine("Agregado");

            Console.WriteLine("\n\n");

            Console.WriteLine("Quitando: " + vendedorUno.ToString());
            if (coleccionPersonas - vendedorUno)
                Console.WriteLine("Quitado");

            Console.WriteLine("Trayendo Clientes de la BD.");
            
            try
            {
                Console.WriteLine("\nCon tabla incorrecta...");
                coleccionPersonas.actualizarMedianteBD("Nombre que no existe");
            }
            catch (ExceptionErrorActualizacionPersonas ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            try
            {
                Console.WriteLine("\nCon tabla correcta.");
                coleccionPersonas.actualizarMedianteBD("Vendedores");
                Console.WriteLine(coleccionPersonas.ToString());
            }
            catch (ExceptionErrorActualizacionPersonas ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Colección de Productos.
            //Creación de Productos.
            Console.WriteLine("Creando colección de Productos de Limpieza...");
            Productos<Limpieza> productosDeLimpieza = new Productos<Limpieza>();
            Console.WriteLine("Colección de productos de Limpieza creada.");
            Console.WriteLine("Creando colección de Productos de Comida...");
            Productos<Comida> productosDeComida = new Productos<Comida>();
            Console.WriteLine("Colección de prodcutos de Comida creada.");

            Producto productoLimpieza = new Limpieza();
            productoLimpieza.ID = 60;
            productoLimpieza.Nombre = "Ayudín";
            productoLimpieza.Precio = (float)54.6;

            Producto productoComida = new Comida();
            productoComida.ID = 450;
            productoComida.Nombre = "Cangreburger";
            productoComida.Precio = (float)549.4;

            Console.Write("Agregando: " + productoLimpieza.ToString());
            if (productosDeLimpieza + productoLimpieza)
                Console.WriteLine("Agregado");

            Console.WriteLine("\n\n");

            Console.WriteLine("Intentando agregar " + productoLimpieza.ToString() + "en lista de productos de Comida");
            try
            {
                if (productosDeComida + productoLimpieza)
                    Console.WriteLine("Esto no va a suceder");
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n\n");

            Console.Write("Agregando: " + productoComida.ToString());
            if (productosDeComida + productoComida)
                Console.WriteLine("Agregado");

            Console.WriteLine("\n\n");

            Console.Write("Quitando: " + productoComida.ToString());
            if (productosDeComida - productoComida)
                Console.WriteLine("Quitado");

            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Trayendo Productos de Comida de la BD.");

            try
            {
                Console.WriteLine("\nCon tabla incorrecta...");
                productosDeComida.actualizarMedianteBD("Nombre que no existe");
            }
            catch (ExceptionErrorActualizacionProductos ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            try
            {
                Console.WriteLine("\nCon tabla correcta.");
                productosDeComida.actualizarMedianteBD("Productos");
                Console.WriteLine(productosDeComida.ToString());
            }
            catch (ExceptionErrorActualizacionProductos ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Trayendo Productos de Limpieza de la BD.");

            try
            {
                Console.WriteLine("\nCon tabla incorrecta...");
                productosDeLimpieza.actualizarMedianteBD("Nombre que no existe");
            }
            catch (ExceptionErrorActualizacionProductos ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            try
            {
                Console.WriteLine("\nCon tabla correcta.");
                productosDeLimpieza.actualizarMedianteBD("Productos");
                Console.WriteLine(productosDeLimpieza.ToString());
            }
            catch (ExceptionErrorActualizacionProductos ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine("Enter para continuar...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region Creación de Factura
            #endregion

        }
    }
}

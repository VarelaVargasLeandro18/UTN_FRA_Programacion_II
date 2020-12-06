using System;
using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTestSistemaDeVenta
    {
        /// <summary>
        /// Test para comprobar si se agrega correctamente una personas a una lista de personas.
        /// </summary>
        [TestMethod]
        public void TestAgregarPersona()
        {
            int DNIVendedor = 43958302;

            Vendedor vend = new Vendedor();
            vend.DNI = DNIVendedor;
            vend.Nombre = "Gerardo Retazo";
            Personas vendedores = new Personas();

            Assert.IsTrue(vendedores + vend);
            Assert.AreEqual(vend, vendedores.obtenerPersona(DNIVendedor));
        }

        /// <summary>
        /// Test para comprobar que se lanza la exception "ExceptionErrorActualzacionPersonas";
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ExcepcionesEntidades.ExceptionErrorActualizacionPersonas))]
        public void TestExceptionActualizacionProductos()
        {
            Personas clientes = new Personas();

            clientes.actualizarMedianteBD("No existe esta tabla");
        }

        /// <summary>
        /// Test para comprobar que se actualiza correctamente una lista de productos con la BD.
        /// SE NECESITA POR LO MENOS 1 DATO DE TIPO "Comida" DE LA BASE DE DATOS.
        /// </summary>
        [TestMethod]
        public void TestActualizacionMedianteBD()
        {
            Productos<Comida> productos = new Productos<Comida>();
            
            productos.actualizarMedianteBD("Productos");

            Assert.IsInstanceOfType(productos.LProductos[0], typeof(Comida));
        }

    }
}

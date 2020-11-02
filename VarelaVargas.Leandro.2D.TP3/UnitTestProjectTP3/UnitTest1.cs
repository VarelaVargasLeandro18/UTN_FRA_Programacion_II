using System;
using System.Collections;
using Clases_Instanciables;
using EntidadesAbstractas;
using Excepciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectTP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SeInstanciaUnaColeccion()
        {
            Universidad uniPrueba = new Universidad();

            Assert.IsInstanceOfType(uniPrueba.Instructores, typeof(ICollection));
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void DevuelveUnaNacionalidadInvalidException()
        {
            Alumno alumnoPrueba = new Alumno(0, "AA", "AA", "99999999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
        }

        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void DevuelveUnaDniInvalidaException()
        {
            Alumno alumnoPrueba = new Alumno(0, "AA", "AA", "4305", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestionBancariaAppNS;

namespace gestionBancariaTest
{
    [TestClass]
    public class GestionBancariaTests
    {
        //LSF1DAWY
        [TestMethod]
        // unit test code [TestMethod]
        public void validarReintegro()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 250;
            double saldoEsperado = 750;
            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
            "Se produjo un error al realizar el reintegro, saldo incorrecto.");
        }

        //LSF1DAWY
        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        // unit test code [TestMethod]
        public void validarReintegroNoValido()
        {
            //LSF1DAWY
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 1250;
            double saldoEsperado = saldoInicial - reintegro;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarReintegro(reintegro);
                Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo incorrecto.");
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message,
               GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }
        [TestMethod]
       

        public void realizarIngresoValido()
        {
            //LSF1DAWY
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = 250;
            double saldoEsperado = 1250;
            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarIngreso(ingreso);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
            "Se produjo un error al realizar el ingreso, saldo incorrecto.");
        }

        [TestMethod]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void realizarIngresoNoValido()
        {
            //LSF1DAWY
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double ingreso = -250;
            double saldoEsperado = saldoInicial + ingreso;
            GestionBancariaApp miApp = new GestionBancariaApp(saldoInicial);
            try
            {
                miApp.realizarIngreso(ingreso);
                Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo incorrecto.");
            }
            catch (ArgumentOutOfRangeException exception)
            {
                // assert
                StringAssert.Contains(exception.Message,
                GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
        }

        [TestMethod]
        

        public void realizarReintegroNoValido()
        {
            //LSF1DAWY
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro  = -250;
           double saldoEsperado = saldoInicial - reintegro;
            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);
            // Método a probar
            try
            {
                miApp.realizarReintegro(reintegro);
                Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
               "Se produjo un error al realizar el ingreso, saldo incorrecto.");
            }
            catch (ArgumentOutOfRangeException exc)
            {
                // assert
                StringAssert.Contains(exc.Message,
               GestionBancariaApp.ERR_CANTIDAD_NO_VALIDA);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");

        }

        [TestMethod]
       

        public void realizarReintegroNoValido2()
        {
            //LSF1DAWY
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 2100;
            double saldoEsperado = saldoInicial - reintegro;
            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);
            // Método a probar
            try
            {
                miApp.realizarReintegro(reintegro);
                Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
                "Se produjo un error al realizar el ingreso, saldo incorrecto.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // assert
                StringAssert.Contains(ex.Message,
               GestionBancariaApp.ERR_SALDO_INSUFICIENTE);
                return;
            }
            Assert.Fail("Error. Se debía haber producido una excepción.");
          
        }

        [TestMethod]
       

        public void realizarReintegroValido()
        {
            // preparación del caso de prueba
            double saldoInicial = 1000;
            double reintegro = 100;
            double saldoEsperado = 900;
            GestionBancariaApp miApp = new
            GestionBancariaApp(saldoInicial);
            // Método a probar
            miApp.realizarReintegro(reintegro);
            Assert.AreEqual(saldoEsperado, miApp.obtenerSaldo(), 0.001,
            "Se produjo un error al realizar el reintegro, saldo incorrecto.");

        }

    }
}

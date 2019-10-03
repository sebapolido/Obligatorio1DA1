using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de EnrollmentTest
    /// </summary>
    [TestClass]
    public class EnrollmentTest
    {
        public EnrollmentTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        IEnrollment enrollment;
        IEnrollment enrollmentEmpty;

        [TestCleanup]
        public void testClean()
        {
            enrollment = null;
            enrollmentEmpty = null;

        }

        [TestInitialize]
        public void testInit()
        {
            enrollmentEmpty = new Enrollment();
            enrollment = new Enrollment("SBN", 4849);
        }

        [TestMethod]
        public void CreateEmptyEnrollmentLetters()
        {
            Assert.AreEqual("", enrollmentEmpty.lettersOfEnrollment);
        }

        [TestMethod]
        public void CreateEmptyEnrollmentNumbers()
        {
            Assert.AreEqual(0, enrollmentEmpty.numbersOfEnrollment);
        }

        [TestMethod]
        public void CreateEnrollmentLetters()
        {
            Assert.AreEqual("SBN", enrollment.lettersOfEnrollment);
        }

        [TestMethod]
        public void CreateEnrollmentNumbers()
        {
            Assert.AreEqual(4849, enrollment.numbersOfEnrollment);
        }

        [TestMethod]
        public void ValidateNotEquals()
        {
            Assert.AreEqual(false, enrollment.Equals(new Enrollment("SDS", 4322)));
        }

        [TestMethod]
        public void ValidateNotEqualsNumbers()
        {
            Assert.AreEqual(false, enrollment.Equals(new Enrollment("SBN", 4322)));
        }

        [TestMethod]
        public void ValidateNotEqualsLetters()
        {
            Assert.AreEqual(false, enrollment.Equals(new Enrollment("SDS", 4849)));
        }

        [TestMethod]
        public void ValidateEquals()
        {
            Assert.AreEqual(true, enrollment.Equals(new Enrollment("SBN", 4849)));
        }
    }
}

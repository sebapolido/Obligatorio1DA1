﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de PurchaseTest
    /// </summary>
    [TestClass]
    public class PurchaseTest
    {
        public PurchaseTest()
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

        IPurchase purchase;
        IPurchase purchaseEmpty;
        IEnrollment enrollment;

        [TestCleanup]
        public void testClean()
        {
            purchase = null;
            purchaseEmpty = null;
            enrollment = null;

        }

        [TestInitialize]
        public void testInit()
        {
            enrollment = new Enrollment("sbn", 4848);
            purchaseEmpty = new Purchase();
            purchase = new Purchase(enrollment, 30, DateTime.Now);
        }

        [TestMethod]
        public void CreateEmptyPurchaseTimeOfPurchase()
        {
            Assert.AreEqual(0, purchaseEmpty.timeOfPurchase);
        }

        [TestMethod]
        public void CreateEmptyPurchaseEnrollment()
        {
            Assert.AreEqual(null, purchaseEmpty.enrollmentOfPurchase);
        }

        public void CreatePurchaseEnrollment()
        {
            Assert.AreEqual(enrollment, purchase.enrollmentOfPurchase);
        }

        public void CreatePurchaseTime()
        {
            Assert.AreEqual(30, purchase.enrollmentOfPurchase);
        }

        public void CreatePurchaseDate()
        {
            Assert.AreEqual(DateTime.Now, purchase.enrollmentOfPurchase);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    /// <summary>
    /// Descripción resumida de AccountTest
    /// </summary>
    [TestClass]
    public class AccountTest
    {
        public AccountTest()
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


        [TestMethod]
        public void CreateEmptyAccountBalance()
        {
            Account account = new Account();
            Assert.AreEqual(0, account.balance);
        }

        [TestMethod]
        public void CreateEmptyAccountMobile()
        {
            Account account = new Account();
            Assert.AreEqual("", account.mobile);
        }

        [TestMethod]
        public void CreateAccountBalance()
        {
            Account account = new Account(0, "099366931");
            Assert.AreEqual(0, account.balance);
        }

        [TestMethod]
        public void CreateAccountMobile()
        {
            Account account = new Account(0, "099366931");
            Assert.AreEqual("099366931", account.mobile);
        }

        [TestMethod]
        public void AddInvalidBalanceTest()
        {
            Account account = new Account(0,"099366931");
            account.AddBalance(-25);
            Assert.AreEqual(0, account.balance);
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceInZeroTest()
        {
            Account account = new Account(0, "099366931");
            account.AddBalance(25);
            Assert.AreEqual(25, account.balance);
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceTest()
        {
            Account account = new Account(25, "099366931");
            account.AddBalance(22);
            Assert.AreEqual(47, account.balance);
        }
    }
}

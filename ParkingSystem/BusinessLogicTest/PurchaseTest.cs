using System;
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
        Purchase purchase;
        Purchase purchaseEmpty;
        Enrollment enrollment;
        public PurchaseTest()
        {

        }


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
            DateTime date = new DateTime(2019,10,8,15,10,0);
            purchase = new Purchase(enrollment, 30, date);
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

        [TestMethod]
        public void CreatePurchaseEnrollment()
        {
            Assert.AreEqual(enrollment, purchase.enrollmentOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseTime()
        {
            Assert.AreEqual(30, purchase.timeOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseDate()
        {
            DateTime date = new DateTime(2019, 10, 8, 15, 10, 0);
            Assert.AreEqual(date, purchase.dateOfPurchase);
        }
    }
}

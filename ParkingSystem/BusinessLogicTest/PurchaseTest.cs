using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class PurchaseTest
    {
        Purchase purchase;
        Purchase purchaseEmpty;
        Enrollment enrollment;
        Account account;

        public PurchaseTest()
        {

        }

        [TestCleanup]
        public void TestClean()
        {
            purchase = null;
            purchaseEmpty = null;
            enrollment = null;
            account = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            enrollment = new Enrollment("sbn", 4848);
            purchaseEmpty = new Purchase();
            DateTime date = new DateTime(2019,10,8,15,10,0);
            account = new Account(25, "099366931", new CountryHandler("Uruguay", 1));
            purchase = new Purchase(enrollment, 30, date, account);
        }

        [TestMethod]
        public void CreateEmptyPurchaseTimeOfPurchase()
        {
            Assert.AreEqual(0, purchaseEmpty.TimeOfPurchase);
        }

        [TestMethod]
        public void CreateEmptyPurchaseEnrollment()
        {
            Assert.AreEqual(null, purchaseEmpty.EnrollmentOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseEnrollment()
        {
            Assert.AreEqual(enrollment, purchase.EnrollmentOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseTime()
        {
            Assert.AreEqual(30, purchase.TimeOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseDate()
        {
            DateTime date = new DateTime(2019, 10, 8, 15, 10, 0);
            Assert.AreEqual(date, purchase.DateOfPurchase);
        }
    }
}

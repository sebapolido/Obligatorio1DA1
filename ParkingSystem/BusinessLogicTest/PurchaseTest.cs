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
        Purchase Purchase;
        Purchase PurchaseEmpty;
        Enrollment Enrollment;
        Account Account;

        public PurchaseTest()
        {

        }

        [TestCleanup]
        public void TestClean()
        {
            Purchase = null;
            PurchaseEmpty = null;
            Enrollment = null;
            Account = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Enrollment = new Enrollment("sbn", 4848);
            PurchaseEmpty = new Purchase();
            DateTime Date = new DateTime(2019,10,8,15,10,0);
            Account = new Account(25, "099366931", new CountryHandler("Uruguay", 1));
            Purchase = new Purchase(Enrollment, 30, Date, Account);
        }

        [TestMethod]
        public void CreateEmptyPurchaseTimeOfPurchase()
        {
            Assert.AreEqual(0, PurchaseEmpty.TimeOfPurchase);
        }

        [TestMethod]
        public void CreateEmptyPurchaseEnrollment()
        {
            Assert.AreEqual(null, PurchaseEmpty.EnrollmentOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseEnrollment()
        {
            Assert.AreEqual(Enrollment, Purchase.EnrollmentOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseTime()
        {
            Assert.AreEqual(30, Purchase.TimeOfPurchase);
        }

        [TestMethod]
        public void CreatePurchaseDate()
        {
            DateTime Date = new DateTime(2019, 10, 8, 15, 10, 0);
            Assert.AreEqual(Date, Purchase.DateOfPurchase);
        }
    }
}

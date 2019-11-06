using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class AccountTest
    {
        Account account;
        Account accountEmpty;
        CountryHandler country;

        [TestCleanup]
        public void TestClean()
        {
            account = null;
            accountEmpty = null;
            country = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            country = new CountryHandler("Uruguay", 1);
            accountEmpty = new Account();
            account = new Account(0, "099366931", country);
        }

        [TestMethod]
        public void CreateEmptyAccountBalance()
        {
            Assert.AreEqual(0, accountEmpty.Balance);
        }

        [TestMethod]
        public void CreateEmptyAccountMobile()
        {
            Assert.AreEqual("", accountEmpty.Mobile);
        }

        [TestMethod]
        public void CreateAccountBalance()
        {
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void CreateAccountMobile()
        {
            Assert.AreEqual("099366931", account.Mobile);
        }

        [TestMethod]
        public void ValidateToString()
        {
            Assert.AreEqual("099366931", account.ToString());
        }
    }
}

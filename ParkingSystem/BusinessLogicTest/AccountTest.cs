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
        Account Account;
        Account AccountEmpty;
        CountryHandler Country;

        [TestCleanup]
        public void TestClean()
        {
            Account = null;
            AccountEmpty = null;
            Country = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Country = new CountryHandler("Uruguay", 1);
            AccountEmpty = new Account();
            Account = new Account(0, "099366931", Country);
        }

        [TestMethod]
        public void CreateEmptyAccountBalance()
        {
            Assert.AreEqual(0, AccountEmpty.Balance);
        }

        [TestMethod]
        public void CreateEmptyAccountMobile()
        {
            Assert.AreEqual("", AccountEmpty.Mobile);
        }

        [TestMethod]
        public void CreateAccountBalance()
        {
            Assert.AreEqual(0, Account.Balance);
        }

        [TestMethod]
        public void CreateAccountMobile()
        {
            Assert.AreEqual("099366931", Account.Mobile);
        }

        [TestMethod]
        public void ValidateToString()
        {
            Assert.AreEqual("099366931", Account.ToString());
        }
    }
}

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
        public void testClean()
        {
            account = null;
            accountEmpty = null;
            country = null;

        }

        [TestInitialize]
        public void testInit()
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
        public void AddInvalidBalanceTest()
        {
            account.AddBalance(-25);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceInZeroTest()
        {
            account.AddBalance(25);
            Assert.AreEqual(25, account.Balance);
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceTest()
        {
            account.AddBalance(22);
            account.AddBalance(25);
            Assert.AreEqual(47, account.Balance);
        }

        [TestMethod]
        public void SubstractInvalidBalanceTest()
        {
            account.SubstractBalance(-25);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void SubstractBalanceWithBalanceInZeroTest()
        {
            account.SubstractBalance(25);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void SubstractBalanceMoreThanTheAccountBalance()
        {
            account.AddBalance(20);
            account.SubstractBalance(25);
            Assert.AreEqual(20, account.Balance);
        }

        [TestMethod]
        public void SubstracTheSameBalanceInTheAccount()
        {
            account.AddBalance(22);
            account.SubstractBalance(22);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void SubstracBalanceInTheAccount()
        {
            account.AddBalance(22);
            account.SubstractBalance(12);
            Assert.AreEqual(10, account.Balance);
        }
    }
}

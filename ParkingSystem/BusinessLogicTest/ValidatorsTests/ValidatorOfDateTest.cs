using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorOfDateTest
    {
        ValidatorOfDate Validator;
        Enrollment Enrollment;
        Account Account;
        DateTime DateCheck;

        [TestCleanup]
        public void TestClean()
        {
            Validator = null;
            Enrollment = null;
            Account = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Validator = new ValidatorOfDate();
            Enrollment = new Enrollment("sbn", 4849);
            Account = new Account(0, "099366931", new CountryHandler("Uruguay",1));
            DateCheck = DateTime.Now;
        }

        [TestMethod]
        public void ValidateHourEmpty()
        {
            DateTime Date = new DateTime();
            Assert.AreEqual(false, Validator.ValidateValidHour(Date));
        }

        [TestMethod]
        public void ValidateTimeHourLessThanTen()
        {
            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 9, 0, 0);
            Assert.AreEqual(false, Validator.ValidateValidHour(Date));
        }

        [TestMethod]
        public void ValidateTimeHourMoreThanSixteen()
        {
            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 21, 0, 0);
            Assert.AreEqual(false, Validator.ValidateValidHour(Date));
        }

        [TestMethod]
        public void ValidateHourSixteen()
        {
            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 18, 0, 0);
            Assert.AreEqual(false, Validator.ValidateValidHour(Date));
        }

        [TestMethod]
        public void ValidateDateTimeNow()
        {
            DateTime Date = DateTime.Now;
            Assert.AreEqual(true, Validator.ValidateTimeThatHasPassed(Date));
        }

        [TestMethod]
        public void ValidateDateTimeNowMoreMinutes()
        {
            DateTime Date = DateTime.Now;
            Date.AddMinutes(10);
            Assert.AreEqual(true, Validator.ValidateTimeThatHasPassed(Date));
        }

        [TestMethod]
        public void ValidateDateTimeNowMoreHours()
        {
            DateTime Date = DateTime.Now;
            Date.AddHours(1);
            Assert.AreEqual(true, Validator.ValidateTimeThatHasPassed(Date));
        }

        [TestMethod]
        public void ValidateDateTimeNowLessHours()
        {
            DateTime Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month
                , DateTime.Now.Day, DateTime.Now.Hour - 1, DateTime.Now.Minute, DateTime.Now.Second);
            Assert.AreEqual(false, Validator.ValidateTimeThatHasPassed(Date));
        }

        [TestMethod]
        public void ValidateCheckDateTheSameDate()
        {
            Assert.AreEqual(true, Validator.CheckDateWithTimeOfPurchase(DateTime.Now, new Purchase(Enrollment, 30, DateTime.Now, Account)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInTime()
        {
            DateCheck = DateCheck.AddMinutes(15);
            Assert.AreEqual(true, Validator.CheckDateWithTimeOfPurchase(DateCheck, new Purchase(Enrollment, 30, DateTime.Now, Account)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInALimitTime()
        {
            DateCheck = DateCheck.AddMinutes(30);
            Assert.AreEqual(true, Validator.CheckDateWithTimeOfPurchase(DateCheck, new Purchase(Enrollment, 30, DateTime.Now, Account)));
        }

        [TestMethod]
        public void ValidateCheckDateDateOutOfBounds()
        {
            DateCheck = DateCheck.AddMinutes(40);
            Assert.AreEqual(false, Validator.CheckDateWithTimeOfPurchase(DateCheck, new Purchase(Enrollment, 30, DateTime.Now, Account)));
        }
    }
}

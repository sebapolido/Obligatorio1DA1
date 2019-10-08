using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorOfDateTest
    {
        ValidatorOfDate validator;

        [TestCleanup]
        public void testClean()
        {
            validator = null;

        }

        [TestInitialize]
        public void testInit()
        {
            validator = new ValidatorOfDate();
        }

        [TestMethod]
        public void ValidateHourEmpty()
        {
            DateTime date = new DateTime();
            Assert.AreEqual(false, validator.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateTimeHourLessThanTen()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 9, 0, 0);
            Assert.AreEqual(false, validator.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateTimeHourMoreThanSixteen()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 21, 0, 0);
            Assert.AreEqual(false, validator.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateHourSixteen()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 18, 0, 0);
            Assert.AreEqual(false, validator.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateDateTimeNow()
        {
            DateTime date = DateTime.Now;
            Assert.AreEqual(true, validator.ValidateTimeThatHasPassed(date));
        }

        [TestMethod]
        public void ValidateDateTimeNowMoreMinutes()
        {
            DateTime date = DateTime.Now;
            date.AddMinutes(10);
            Assert.AreEqual(true, validator.ValidateTimeThatHasPassed(date));
        }

        [TestMethod]
        public void ValidateDateTimeNowMoreHours()
        {
            DateTime date = DateTime.Now;
            date.AddHours(1);
            Assert.AreEqual(true, validator.ValidateTimeThatHasPassed(date));
        }

        [TestMethod]
        public void ValidateDateTimeNowLessHours()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month
                , DateTime.Now.Day, DateTime.Now.Hour - 1, DateTime.Now.Minute, DateTime.Now.Second);
            Assert.AreEqual(false, validator.ValidateTimeThatHasPassed(date));
        }

        [TestMethod]
        public void ValidateCheckDateTheSameDate()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            Assert.AreEqual(true, validator.CheckDateWithTimeOfPurchase(DateTime.Now, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInTime()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(15);
            Assert.AreEqual(true, validator.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInALimitTime()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(30);
            Assert.AreEqual(true, validator.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateOutOfBounds()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(40);
            Assert.AreEqual(false, validator.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }
    }
}

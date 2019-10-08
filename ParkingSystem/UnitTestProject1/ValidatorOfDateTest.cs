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
        public void ValidateCheckDateTheSameDate()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            Assert.AreEqual(true, validator.CheckDateWithTimeOfPurchase(DateTime.Now, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInTime()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(15);
            Assert.AreEqual(true, validator.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInALimitTime()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(30);
            Assert.AreEqual(true, validator.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateOutOfBounds()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(40);
            Assert.AreEqual(false, validator.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }
    }
}

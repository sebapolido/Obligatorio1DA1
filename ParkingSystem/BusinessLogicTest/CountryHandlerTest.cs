using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace BusinessLogicTest
{
    [TestClass]
    public class CountryHandlerTest
    {
        CountryHandler Uruguay;
        CountryHandler Argentina;

        [TestCleanup]
        public void TestClean()
        {
            Uruguay = null;
            Argentina = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Uruguay = new CountryHandler("Uruguay", 1);
            Argentina = new CountryHandler("Argentina", 1);
            Uruguay.SetValidators(new ValidatorOfPhoneInUruguay(), new ValidatorOfMessageInUruguay());
            Argentina.SetValidators(new ValidatorOfPhoneInArgentina(), new ValidatorOfMessageInArgentina());
        }

        [TestMethod]
        public void ValidateEmptyConstructor()
        {
            CountryHandler brasil = new CountryHandler();
            Assert.AreEqual(null, brasil.ValidatorOfPhone);
        }

        [TestMethod]
        public void ValidateIsEmptyByCountryArgentina()
        {            
            Assert.AreEqual(true, Argentina.ValidateIsEmptyByCountry(""));
        }

        [TestMethod]
        public void ValidateIsEmptyByCountryUruguay()
        {
            Assert.AreEqual(true, Uruguay.ValidateIsEmptyByCountry(""));
        }

        [TestMethod]
        public void ValidateIsNumericByCountryArgentina()
        {
            Assert.AreEqual(true, Argentina.ValidateIsNumericByCountry("02323223"));
        }

        [TestMethod]
        public void ValidateIsNumericByCountryUruguay()
        {
            Assert.AreEqual(true, Uruguay.ValidateIsNumericByCountry("099355932"));
        }

        [TestMethod]
        public void ValidateFormatNumberByCountryArgentina()
        {
            string TextOfPhone = "1234567";
            Assert.AreEqual(true, Argentina.ValidateFormatNumberByCountry(ref TextOfPhone));
        }

        [TestMethod]
        public void ValidateFormatNumberByCountryUruguay()
        {
            string TextOfPhone = "099366931";
            Assert.AreEqual(true, Uruguay.ValidateFormatNumberByCountry(ref TextOfPhone));
        }

        [TestMethod]
        public void ValidateMessageDataByCountryArgentina()
        {
            string Message = "SBN2323 11:00 60";
            Assert.AreEqual(true, Argentina.ValidateMessageDataByCountry(Message));
        }

        [TestMethod]
        public void ValidateMessageDataByCountryUruguay()
        {
            string Message = "SBN4949 30";
            Assert.AreEqual(true, Uruguay.ValidateMessageDataByCountry(Message));
        }

        [TestMethod]
        public void ValidateWroteHourAndMinutesByCountryArgentina()
        {
            string[] Line = new string[] { " ","11:21", "60" };
            Assert.AreEqual(true, Argentina.WroteHourAndMinutesByCountry(Line));
        }

        [TestMethod]
        public void ValidateWroteAndMinutesByCountryUruguay()
        {
            string[] Line = new string[] { " ", "60", "11:21" };
            Assert.AreEqual(true, Uruguay.WroteHourAndMinutesByCountry(Line));
        }

        [TestMethod]
        public void ValidateAssignHourByCountryArgentina()
        {
            string[] Line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(11, Argentina.AssignHourByCountry(Line));
        }

        [TestMethod]
        public void ValidateAssignHourByCountryUruguay()
        {
            string[] Line = new string[] { " ", "60", "13:21" };
            Assert.AreEqual(13, Uruguay.AssignHourByCountry(Line));
        }

        [TestMethod]
        public void ValidateAssignMinutesByCountryArgentina()
        {
            string[] Line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(21, Argentina.AssignMinutesByCountry(Line));
        }

        [TestMethod]
        public void ValidateAssignMinutesByCountryUruguay()
        {
            string[] Line = new string[] { " ", "60", "13:45" };
            Assert.AreEqual(45, Uruguay.AssignMinutesByCountry(Line));
        }

        [TestMethod]
        public void ValidateAssignTimeByCountryArgentina()
        {
            string[] Line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(60, Argentina.AssignTimeByCountry(Line));
        }

        [TestMethod]
        public void ValidateAssignTimeWhitoutHourAndMinutesByCountryArgentina()
        {
            string[] Line = new string[] { " ", "34" };
            Assert.AreEqual(34, Argentina.AssignTimeByCountry(Line));
        }

        [TestMethod]
        public void ValidateAssignTimeByCountryUruguay()
        {
            string[] Line = new string[] { " ", "30", "13:21" };
            Assert.AreEqual(30, Uruguay.AssignTimeByCountry(Line));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseByCountryArgentina()
        {
            Assert.AreEqual(true, Argentina.ValidateTimeOfPurchaseByCountry(30));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseByCountryUruguay()
        {
            Assert.AreEqual(true, Uruguay.ValidateTimeOfPurchaseByCountry(30));
        }

        [TestMethod]
        public void ValidateLengthOfMessageByCountryArgentina()
        {
            Assert.AreEqual(true, Argentina.IsLengthOfMessageCorrectByCountry(10));
        }

        [TestMethod]
        public void ValidateLengthOfMessageByCountryUruguay()
        {
            Assert.AreEqual(true, Uruguay.IsLengthOfMessageCorrectByCountry(10));
        }

        [TestMethod]
        public void ValidateCalculateTimeOfPurchaseByCountryArgentina()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, Argentina.CalculateFinalTimeOfPurchaseByCountry(60, DateOfPurchase));
        }

        [TestMethod]
        public void ValidateCalculateTimeOfPurchaseByCountryUruguay()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                         DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, Uruguay.CalculateFinalTimeOfPurchaseByCountry(60, DateOfPurchase));
        }
    }
}

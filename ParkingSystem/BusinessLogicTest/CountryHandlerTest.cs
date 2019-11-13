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
        CountryHandler uruguay;
        CountryHandler argentina;

        [TestCleanup]
        public void TestClean()
        {
            uruguay = null;
            argentina = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            uruguay = new CountryHandler("Uruguay", 1);
            argentina = new CountryHandler("Argentina", 1);
            uruguay.SetValidators(new ValidatorOfPhoneInUruguay(), new ValidatorOfMessageInUruguay());
            argentina.SetValidators(new ValidatorOfPhoneInArgentina(), new ValidatorOfMessageInArgentina());
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
            Assert.AreEqual(true, argentina.ValidateIsEmptyByCountry(""));
        }

        [TestMethod]
        public void ValidateIsEmptyByCountryUruguay()
        {
            Assert.AreEqual(true, uruguay.ValidateIsEmptyByCountry(""));
        }

        [TestMethod]
        public void ValidateIsNumericByCountryArgentina()
        {
            Assert.AreEqual(true, argentina.ValidateIsNumericByCountry("02323223"));
        }

        [TestMethod]
        public void ValidateIsNumericByCountryUruguay()
        {
            Assert.AreEqual(true, uruguay.ValidateIsNumericByCountry("099355932"));
        }

        [TestMethod]
        public void ValidateFormatNumberByCountryArgentina()
        {
            string textOfPhone = "1234567";
            Assert.AreEqual(true, argentina.ValidateFormatNumberByCountry(ref textOfPhone));
        }

        [TestMethod]
        public void ValidateFormatNumberByCountryUruguay()
        {
            string textOfPhone = "099366931";
            Assert.AreEqual(true, uruguay.ValidateFormatNumberByCountry(ref textOfPhone));
        }

        [TestMethod]
        public void ValidateMessageDataByCountryArgentina()
        {
            string message = "SBN2323 11:00 60";
            Assert.AreEqual(true, argentina.ValidateMessageDataByCountry(message));
        }

        [TestMethod]
        public void ValidateMessageDataByCountryUruguay()
        {
            string message = "SBN4949 30";
            Assert.AreEqual(true, uruguay.ValidateMessageDataByCountry(message));
        }

        [TestMethod]
        public void ValidateWroteHourAndMinutesByCountryArgentina()
        {
            string[] line = new string[] { " ","11:21", "60" };
            Assert.AreEqual(true, argentina.WroteHourAndMinutesByCountry(line));
        }

        [TestMethod]
        public void ValidateWroteAndMinutesByCountryUruguay()
        {
            string[] line = new string[] { " ", "60", "11:21" };
            Assert.AreEqual(true, uruguay.WroteHourAndMinutesByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignHourByCountryArgentina()
        {
            string[] line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(11, argentina.AssignHourByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignHourByCountryUruguay()
        {
            string[] line = new string[] { " ", "60", "13:21" };
            Assert.AreEqual(13, uruguay.AssignHourByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignMinutesByCountryArgentina()
        {
            string[] line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(21, argentina.AssignMinutesByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignMinutesByCountryUruguay()
        {
            string[] line = new string[] { " ", "60", "13:45" };
            Assert.AreEqual(45, uruguay.AssignMinutesByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignTimeByCountryArgentina()
        {
            string[] line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(60, argentina.AssignTimeByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignTimeWhitoutHourAndMinutesByCountryArgentina()
        {
            string[] line = new string[] { " ", "34" };
            Assert.AreEqual(34, argentina.AssignTimeByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignTimeByCountryUruguay()
        {
            string[] line = new string[] { " ", "30", "13:21" };
            Assert.AreEqual(30, uruguay.AssignTimeByCountry(line));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseByCountryArgentina()
        {
            Assert.AreEqual(true, argentina.ValidateTimeOfPurchaseByCountry(30));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseByCountryUruguay()
        {
            Assert.AreEqual(true, uruguay.ValidateTimeOfPurchaseByCountry(30));
        }

        [TestMethod]
        public void ValidateLengthOfMessageByCountryArgentina()
        {
            Assert.AreEqual(true, argentina.IsLengthOfMessageCorrectByCountry(10));
        }

        [TestMethod]
        public void ValidateLengthOfMessageByCountryUruguay()
        {
            Assert.AreEqual(true, uruguay.IsLengthOfMessageCorrectByCountry(10));
        }

        [TestMethod]
        public void ValidateCalculateTimeOfPurchaseByCountryArgentina()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, argentina.CalculateFinalTimeOfPurchaseByCountry(60, dateOfPurchse));
        }

        [TestMethod]
        public void ValidateCalculateTimeOfPurchaseByCountryUruguay()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                         DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, uruguay.CalculateFinalTimeOfPurchaseByCountry(60, dateOfPurchse));
        }
    }
}

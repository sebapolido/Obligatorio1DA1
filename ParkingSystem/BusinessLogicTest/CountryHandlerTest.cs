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
        Country uruguay;
        Country argentina;
        CountryHandler countryHandler;

        [TestCleanup]
        public void testClean()
        {
            countryHandler = null;
            uruguay = null;
            argentina = null;
        }

        [TestInitialize]
        public void testInit()
        {
            uruguay = new Country("Uruguay", 1);
            argentina = new Country("Argentina", 2);
        }

        [TestMethod]
        public void ValidateIsEmptyByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            Assert.AreEqual(true, countryHandler.ValidateIsEmptyByCountry(""));
        }

        [TestMethod]
        public void ValidateIsEmptyByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            Assert.AreEqual(true, countryHandler.ValidateIsEmptyByCountry(""));
        }

        [TestMethod]
        public void ValidateIsNumericByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            Assert.AreEqual(true, countryHandler.ValidateIsNumericByCountry("02323223"));
        }

        [TestMethod]
        public void ValidateIsNumericByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            Assert.AreEqual(true, countryHandler.ValidateIsNumericByCountry("099355932"));
        }

        [TestMethod]
        public void ValidateFormatNumberByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            string textOfPhone = "1234567";
            Assert.AreEqual(true, countryHandler.ValidateFormatNumberByCountry(ref textOfPhone));
        }

        [TestMethod]
        public void ValidateFormatNumberByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            string textOfPhone = "099366931";
            Assert.AreEqual(true, countryHandler.ValidateFormatNumberByCountry(ref textOfPhone));
        }

        [TestMethod]
        public void ValidateMessageDataByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            string message = " 60";
            Assert.AreEqual(true, countryHandler.ValidateMessageDataByCountry(message));
        }

        [TestMethod]
        public void ValidateMessageDataByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            string message = "SBN4949 30";
            Assert.AreEqual(true, countryHandler.ValidateMessageDataByCountry(message));
        }

        [TestMethod]
        public void ValidateWroteHourAndMinutesByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            string[] line = new string[] { " ","11:21", "60" };
            Assert.AreEqual(true, countryHandler.WroteHourAndMinutesByCountry(line));
        }

        [TestMethod]
        public void ValidateWroteAndMinutesByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            string[] line = new string[] { " ", "60", "11:21" };
            Assert.AreEqual(true, countryHandler.WroteHourAndMinutesByCountry(line));
        }

        [TestMethod]
        public void ValidateAssignHourByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            string[] line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(11, countryHandler.AssignHour(line));
        }

        [TestMethod]
        public void ValidateAssignHourByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            string[] line = new string[] { " ", "60", "13:21" };
            Assert.AreEqual(13, countryHandler.AssignHour(line));
        }

        [TestMethod]
        public void ValidateAssignMinutesByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            string[] line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(21, countryHandler.AssignMinutes(line));
        }

        [TestMethod]
        public void ValidateAssignMinutesByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            string[] line = new string[] { " ", "60", "13:45" };
            Assert.AreEqual(45, countryHandler.AssignMinutes(line));
        }

        [TestMethod]
        public void ValidateAssignTimeByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            string[] line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(60, countryHandler.AssignTime(line));
        }

        [TestMethod]
        public void ValidateAssignTimeWhitoutHourAndMinutesByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            string[] line = new string[] { " ", "34" };
            Assert.AreEqual(34, countryHandler.AssignTime(line));
        }

        [TestMethod]
        public void ValidateAssignTimeByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            string[] line = new string[] { " ", "30", "13:21" };
            Assert.AreEqual(30, countryHandler.AssignTime(line));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            Assert.AreEqual(true, countryHandler.ValidateTimeOfPurchaseByCountry(30));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            Assert.AreEqual(true, countryHandler.ValidateTimeOfPurchaseByCountry(30));
        }

        [TestMethod]
        public void ValidateLengthOfMessageByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            Assert.AreEqual(true, countryHandler.IsLengthOfMessageCorrectByCountry(10));
        }

        [TestMethod]
        public void ValidateLengthOfMessageByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            Assert.AreEqual(true, countryHandler.IsLengthOfMessageCorrectByCountry(10));
        }

        [TestMethod]
        public void ValidateCalculateTimeOfPurchaseByCountryArgentina()
        {
            countryHandler = new CountryHandler(argentina);
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, countryHandler.CalculateFinalTimeOfPurchaseByCountry(60, dateOfPurchse));
        }

        [TestMethod]
        public void ValidateCalculateTimeOfPurchaseByCountryUruguay()
        {
            countryHandler = new CountryHandler(uruguay);
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                         DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, countryHandler.CalculateFinalTimeOfPurchaseByCountry(60, dateOfPurchse));
        }
    }
}

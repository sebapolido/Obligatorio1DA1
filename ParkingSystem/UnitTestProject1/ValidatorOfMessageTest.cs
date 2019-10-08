using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorOfMessageTest
    {
        ValidatorOfMessage validator;
        
        [TestCleanup]
        public void testClean()
        {
            validator = null;

        }

        [TestInitialize]
        public void testInit()
        {
            validator = new ValidatorOfMessage();
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentIncorrectLessTanEigth()
        {
            Assert.AreEqual(false, validator.IsLengthOfMessageCorrect(7));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentIncorrectMoreTanTwenty()
        {
            Assert.AreEqual(false, validator.IsLengthOfMessageCorrect(23));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentCorrect()
        {
            Assert.AreEqual(true, validator.IsLengthOfMessageCorrect(15));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentMinimumLimitCorrect()
        {
            Assert.AreEqual(true, validator.IsLengthOfMessageCorrect(9));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentMaximumLimitCorrect()
        {
            Assert.AreEqual(true, validator.IsLengthOfMessageCorrect(19));
        }



        [TestMethod]
        public void ValidateWroteTimeNotWroteTime()
        {
            string[] line = new string[] { " ", "60" };
            Assert.AreEqual(false, validator.WroteTime(line));
        }

        [TestMethod]
        public void ValidateWroteTimeInvalidWroteTime()
        {
            string[] line = new string[] { " ", "60", "1021:213321" };
            Assert.AreEqual(false, validator.WroteTime(line));
        }

        [TestMethod]
        public void ValidateWroteTimeValidWroteTime()
        {
            string[] line = new string[] { " ", "60", "11:21" };
            Assert.AreEqual(true, validator.WroteTime(line));
        }

        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessageOnlySpace()
        {
            string[] line = new string[] { " " };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfRestOfMessage(line));
        }

        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessageMoreLength()
        {
            string[] line = new string[] { " ", "test", "60", "1021:213321" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfRestOfMessage(line));
        }

        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessageValidFormat()
        {
            string[] line = new string[] { " ", "60" };
            Assert.AreEqual(true, validator.IsCorrectSeparationOfRestOfMessage(line));
        }

        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessage()
        {
            string[] line = new string[] { " ", "60", "11:21" };
            Assert.AreEqual(true, validator.IsCorrectSeparationOfRestOfMessage(line));
        }

        [TestMethod]
        public void ValidateMinutesEmpty()
        {
            string line =  " " ;
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWhitMoreInput()
        {
            string line = " 60 10:30 50 43 d";
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWhitBadFormatInHour()
        {
            string line = " 60 2132:30";
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWhitOnlyTime()
        {
            string line = " 60";
            Assert.AreEqual(true, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWhitValidTimeHourAndMinutes()
        {
            string line = " 60 12:30";
            Assert.AreEqual(true, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWithBadFormatInMinutes()
        {
            string line = " 60 12:3032";
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWithStringInTime()
        {
            string line = " ads 12:32";
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWithBadFormatInHours()
        {
            string line = " 60 12:30:32";
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWithStringInHour()
        {
            string line = " 60 ab:32";
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateMinutesWithStringInMinutes()
        {
            string line = " 60 12:sf";
            Assert.AreEqual(false, validator.ValidateMinutes(line));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseZero()
        {
            Assert.AreEqual(false, validator.ValideTimeOfPurchase(0));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseNegativeNumber()
        {
            Assert.AreEqual(false, validator.ValideTimeOfPurchase(-23));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseNotMultipleOfThirty()
        {
            Assert.AreEqual(false, validator.ValideTimeOfPurchase(23));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseMultipleOfThirty()
        {
            Assert.AreEqual(true, validator.ValideTimeOfPurchase(60));
        }


        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseEmpty()
        {
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(0, 0, 0));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTimeEmpty()
        {
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(0, 10, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseHourEmpty()
        {
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(30, 0, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseMinutesEmpty()
        {
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(30, 20, 0));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseLessThanTen()
        {
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(30, 9, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseMoreThanSixteen()
        {
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(30, 19, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseMinutesMoreOfSixty()
        {
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(30, 10, 70));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteWithMinutes()
        {
            Assert.AreEqual(60, validator.CalculateFinalTimeOfPurchase(60, 12, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutes()
        {
            Assert.AreEqual(20, validator.CalculateFinalTimeOfPurchase(60, 17, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutesAndOneHour()
        {
            Assert.AreEqual(80, validator.CalculateFinalTimeOfPurchase(90, 16, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForMinutesAndOneHour()
        {
            Assert.AreEqual(60, validator.CalculateFinalTimeOfPurchase(60, 16, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForALotOfHours()
        {
            Assert.AreEqual(330, validator.CalculateFinalTimeOfPurchase(3000, 12, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForALotOfHours()
        {
            Assert.AreEqual(300, validator.CalculateFinalTimeOfPurchase(300, 12, 30));
        }

    }
}

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
            Assert.AreEqual(false, validator.WroteHourAndMinutes(line));
        }

        [TestMethod]
        public void ValidateWroteTimeInvalidWroteTime()
        {
            string[] line = new string[] { " ", "60", "1021:213321" };
            Assert.AreEqual(false, validator.WroteHourAndMinutes(line));
        }

        [TestMethod]
        public void ValidateWroteTimeValidWroteTime()
        {
            string[] line = new string[] { " ", "60", "11:21" };
            Assert.AreEqual(true, validator.WroteHourAndMinutes(line));
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
        public void ValidateMessageEmpty()
        {
            string line =  " " ;
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWhitMoreInput()
        {
            string line = " 60 10:30 50 43 d";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWhitBadFormatInHour()
        {
            string line = " 60 2132:30";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWhitOnlyTime()
        {
            string line = " 60";
            Assert.AreEqual(true, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWhitValidTimeHourAndMinutes()
        {
            string line = " 60 12:30";
            Assert.AreEqual(true, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInMinutes()
        {
            string line = " 60 12:3032";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInTime()
        {
            string line = " ads 12:32";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInHours()
        {
            string line = " 60 12:30:32";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInHour()
        {
            string line = " 60 ab:32";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInMinutes()
        {
            string line = " 60 12:sf";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
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
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            Assert.AreEqual(0, validator.CalculateFinalTimeOfPurchase(0, dateOfPurchse));
        }
        
        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteWithMinutes()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 12, 40, 0);
            Assert.AreEqual(60, validator.CalculateFinalTimeOfPurchase(60, dateOfPurchse));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutes()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 17, 40, 0);
            Assert.AreEqual(20, validator.CalculateFinalTimeOfPurchase(60, dateOfPurchse));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutesAndOneHour()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(80, validator.CalculateFinalTimeOfPurchase(90, dateOfPurchse));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForMinutesAndOneHour()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, validator.CalculateFinalTimeOfPurchase(60, dateOfPurchse));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForALotOfHours()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 12, 30, 0);
            Assert.AreEqual(330, validator.CalculateFinalTimeOfPurchase(3000, dateOfPurchse));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForALotOfHours()
        {
            DateTime dateOfPurchse = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 12, 30, 0);
            Assert.AreEqual(300, validator.CalculateFinalTimeOfPurchase(300, dateOfPurchse));
        }

    }
}

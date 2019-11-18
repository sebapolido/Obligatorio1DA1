using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorOfMessageTest
    {
        ValidatorOfMessage Validator;
        
        [TestCleanup]
        public void TestClean()
        {
            Validator = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Validator = new ValidatorOfMessageInUruguay();
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentIncorrectLessTanEigth()
        {
            Assert.AreEqual(false, Validator.IsLengthOfMessageCorrect(7));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentIncorrectMoreTanTwenty()
        {
            Assert.AreEqual(false, Validator.IsLengthOfMessageCorrect(23));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentCorrect()
        {
            Assert.AreEqual(true, Validator.IsLengthOfMessageCorrect(15));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentMinimumLimitCorrect()
        {
            Assert.AreEqual(true, Validator.IsLengthOfMessageCorrect(9));
        }

        [TestMethod]
        public void ValidateLengthOfEnrollmentMaximumLimitCorrect()
        {
            Assert.AreEqual(true, Validator.IsLengthOfMessageCorrect(19));
        }
        
        
        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessageOnlySpace()
        {
            string[] Line = new string[] { " " };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfRestOfMessage(Line));
        }

        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessageMoreLength()
        {
            string[] Line = new string[] { " ", "test", "60", "1021:213321" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfRestOfMessage(Line));
        }

        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessageValidFormat()
        {
            string[] Line = new string[] { " ", "60" };
            Assert.AreEqual(true, Validator.IsCorrectSeparationOfRestOfMessage(Line));
        }

        [TestMethod]
        public void ValidateIsCorrectSeparationOfRestOfMessage()
        {
            string[] Line = new string[] { " ", "60", "11:21" };
            Assert.AreEqual(true, Validator.IsCorrectSeparationOfRestOfMessage(Line));
        }        

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseEmpty()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            Assert.AreEqual(0, Validator.CalculateFinalTimeOfPurchase(0, DateOfPurchase));
        }
        
        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteWithMinutes()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 12, 40, 0);
            Assert.AreEqual(60, Validator.CalculateFinalTimeOfPurchase(60, DateOfPurchase));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutes()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 17, 40, 0);
            Assert.AreEqual(20, Validator.CalculateFinalTimeOfPurchase(60, DateOfPurchase));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutesAndOneHour()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(80, Validator.CalculateFinalTimeOfPurchase(90, DateOfPurchase));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForMinutesAndOneHour()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 16, 40, 0);
            Assert.AreEqual(60, Validator.CalculateFinalTimeOfPurchase(60, DateOfPurchase));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForALotOfHours()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 12, 30, 0);
            Assert.AreEqual(330, Validator.CalculateFinalTimeOfPurchase(3000, DateOfPurchase));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForALotOfHours()
        {
            DateTime DateOfPurchase = new DateTime(DateTime.Now.Year,
                        DateTime.Now.Month, DateTime.Now.Day, 12, 30, 0);
            Assert.AreEqual(300, Validator.CalculateFinalTimeOfPurchase(300, DateOfPurchase));
        }

    }
}

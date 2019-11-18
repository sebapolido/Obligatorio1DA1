using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace BusinessLogicTest
{
    [TestClass]
    public class ValidatorOfMessageInArgentinaTest
    {
        ValidatorOfMessageInArgentina Validator;

        [TestCleanup]
        public void TestClean()
        {
            Validator = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Validator = new ValidatorOfMessageInArgentina();
        }

        [TestMethod]
        public void ValidateWroteTimeNotWroteTime()
        {
            string[] Line = new string[] { " ", "60" };
            Assert.AreEqual(false, Validator.WroteHourAndMinutes(Line));
        }

        [TestMethod]
        public void ValidateWroteTimeInvalidWroteTime()
        {
            string[] Line = new string[] { " ", "1021:213321", "60"};
            Assert.AreEqual(false, Validator.WroteHourAndMinutes(Line));
        }

        [TestMethod]
        public void ValidateWroteTimeValidWroteTime()
        {
            string[] Line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(true, Validator.WroteHourAndMinutes(Line));
        }

        [TestMethod]
        public void ValidateMessageEmpty()
        {
            string Line = " ";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWhitMoreInput()
        {
            string Line = " 60 50 10:30 43 d";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWhitBadFormatInHour()
        {
            string Line = " 60 2132:30";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWhitOnlyTime()
        {
            string Line = " 60";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWhitValidTimeHourAndMinutes()
        {
            string Line = " 12:30 60";
            Assert.AreEqual(true, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInMinutes()
        {
            string Line = " 12:3032 60";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInTime()
        {
            string Line = " 12:32 TIME";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInHours()
        {
            string Line = " 12:30:32 60";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInHour()
        {
            string Line = " ab:32 60";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInMinutes()
        {
            string Line = " 12:sf 60";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseZero()
        {
            Assert.AreEqual(false, Validator.ValideTimeOfPurchase(0));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseNegativeNumber()
        {
            Assert.AreEqual(false, Validator.ValideTimeOfPurchase(-23));
        }

        [TestMethod]
        public void ValidateTimeOfPurchasePositiveNumber()
        {
            Assert.AreEqual(true, Validator.ValideTimeOfPurchase(23));
        }
    }
}
       

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
        ValidatorOfMessageInArgentina validator;

        [TestCleanup]
        public void testClean()
        {
            validator = null;
        }

        [TestInitialize]
        public void testInit()
        {
            validator = new ValidatorOfMessageInArgentina();
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
            string[] line = new string[] { " ", "1021:213321", "60"};
            Assert.AreEqual(false, validator.WroteHourAndMinutes(line));
        }

        [TestMethod]
        public void ValidateWroteTimeValidWroteTime()
        {
            string[] line = new string[] { " ", "11:21", "60" };
            Assert.AreEqual(true, validator.WroteHourAndMinutes(line));
        }

        [TestMethod]
        public void ValidateMessageEmpty()
        {
            string line = " ";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWhitMoreInput()
        {
            string line = " 60 50 10:30 43 d";
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
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWhitValidTimeHourAndMinutes()
        {
            string line = " 12:30 60";
            Assert.AreEqual(true, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInMinutes()
        {
            string line = " 12:3032 60";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInTime()
        {
            string line = " 12:32 TIME";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInHours()
        {
            string line = " 12:30:32 60";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInHour()
        {
            string line = " ab:32 60";
            Assert.AreEqual(false, validator.ValidateMessageData(line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInMinutes()
        {
            string line = " 12:sf 60";
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
        public void ValidateTimeOfPurchasePositiveNumber()
        {
            Assert.AreEqual(true, validator.ValideTimeOfPurchase(23));
        }
    }
}
       

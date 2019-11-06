using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace BusinessLogicTest
{
    [TestClass]
    public class ValidatorOfMessageInUruguayTest
    {
        ValidatorOfMessageInUruguay validator;

        [TestCleanup]
        public void TestClean()
        {
            validator = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            validator = new ValidatorOfMessageInUruguay();
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
        public void ValidateMessageEmpty()
        {
            string line = " ";
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

    }
}

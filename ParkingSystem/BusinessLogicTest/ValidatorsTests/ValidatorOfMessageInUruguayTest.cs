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
        ValidatorOfMessageInUruguay Validator;

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
        public void ValidateWroteTimeNotWroteTime()
        {
            string[] Line = new string[] { " ", "60" };
            Assert.AreEqual(false, Validator.WroteHourAndMinutes(Line));
        }

        [TestMethod]
        public void ValidateWroteTimeInvalidWroteTime()
        {
            string[] Line = new string[] { " ", "60", "1021:213321" };
            Assert.AreEqual(false, Validator.WroteHourAndMinutes(Line));
        }

        [TestMethod]
        public void ValidateWroteTimeValidWroteTime()
        {
            string[] Line = new string[] { " ", "60", "11:21" };
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
            string Line = " 60 10:30 50 43 d";
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
            Assert.AreEqual(true, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWhitValidTimeHourAndMinutes()
        {
            string Line = " 60 12:30";
            Assert.AreEqual(true, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInMinutes()
        {
            string Line = " 60 12:3032";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInTime()
        {
            string Line = " ads 12:32";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithBadFormatInHours()
        {
            string Line = " 60 12:30:32";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInHour()
        {
            string Line = " 60 ab:32";
            Assert.AreEqual(false, Validator.ValidateMessageData(Line));
        }

        [TestMethod]
        public void ValidateMessageWithStringInMinutes()
        {
            string Line = " 60 12:sf";
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
        public void ValidateTimeOfPurchaseNotMultipleOfThirty()
        {
            Assert.AreEqual(false, Validator.ValideTimeOfPurchase(23));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseMultipleOfThirty()
        {
            Assert.AreEqual(true, Validator.ValideTimeOfPurchase(60));
        }
    }
}

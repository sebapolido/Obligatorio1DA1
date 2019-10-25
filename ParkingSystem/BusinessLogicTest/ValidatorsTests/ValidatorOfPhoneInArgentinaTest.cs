using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace BusinessLogicTest
{
    [TestClass]
    public class ValidatorOfPhoneInArgentinaTest
    {
        ValidatorOfPhoneInArgentina validator;

        [TestCleanup]
        public void testClean()
        {
            validator = null;
        }

        [TestInitialize]
        public void testInit()
        {
            validator = new ValidatorOfPhoneInArgentina();
        }
        
        [TestMethod]
        public void ValidateLengthNumberLessThanNecessary()
        {
            string input = "09934";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberGreaterThanNecessary()
        {
            string input = "09923132234";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthSixNumbers()
        {
            string input = "123456";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthSevenNumbers()
        {
            string input = "1234567";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthEigthNumbers()
        {
            string input = "12345678";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthSixNumbersWhitScripts()
        {
            string input = "12-34-56";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthSevenNumbersWithScripts()
        {
            string input = "12-3456-7";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthEigthNumbersWhitScripts()
        {
            string input = "12-345-6-78";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberWhitScriptInFirstCharacter()
        {
            string input = "-12345567";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberWhitScriptInLastCharacter()
        {
            string input = "0992-234-";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }
    }
}

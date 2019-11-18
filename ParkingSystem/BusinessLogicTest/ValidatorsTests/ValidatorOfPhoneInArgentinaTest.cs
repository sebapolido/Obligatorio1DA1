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
        ValidatorOfPhoneInArgentina Validator;

        [TestCleanup]
        public void TestClean()
        {
            Validator = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Validator = new ValidatorOfPhoneInArgentina();
        }
        
        [TestMethod]
        public void ValidateLengthNumberLessThanNecessary()
        {
            string Input = "09934";
            Assert.AreEqual(false, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthNumberGreaterThanNecessary()
        {
            string Input = "09923132234";
            Assert.AreEqual(false, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthSixNumbers()
        {
            string Input = "123456";
            Assert.AreEqual(true, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthSevenNumbers()
        {
            string Input = "1234567";
            Assert.AreEqual(true, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthEigthNumbers()
        {
            string Input = "12345678";
            Assert.AreEqual(true, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthSixNumbersWhitScripts()
        {
            string Input = "12-34-56";
            Assert.AreEqual(true, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthSevenNumbersWithScripts()
        {
            string Input = "12-3456-7";
            Assert.AreEqual(true, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthEigthNumbersWhitScripts()
        {
            string Input = "12-345-6-78";
            Assert.AreEqual(true, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthNumberWhitScriptInFirstCharacter()
        {
            string Input = "-12345567";
            Assert.AreEqual(false, Validator.ValidateFormatNumber(ref Input));
        }

        [TestMethod]
        public void ValidateLengthNumberWhitScriptInLastCharacter()
        {
            string Input = "0992-234-";
            Assert.AreEqual(false, Validator.ValidateFormatNumber(ref Input));
        }
    }
}

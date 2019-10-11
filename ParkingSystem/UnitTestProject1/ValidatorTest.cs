using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorTest
    {
        Validator validator;


        [TestCleanup]
        public void testClean()
        {
            validator = null;

        }

        [TestInitialize]
        public void testInit()
        {
            validator = new Validator();
        }

        [TestMethod]
        public void ValidateIsNumericEmpty()
        {
            Assert.AreEqual(false, validator.ValidateIsNumeric(""));
        }

        [TestMethod]
        public void ValidateIsNumericWithOneLetter()
        {
            Assert.AreEqual(false, validator.ValidateIsNumeric("t"));
        }

        [TestMethod]
        public void ValidateIsNumericWithOneNumber()
        {
            Assert.AreEqual(true, validator.ValidateIsNumeric("1"));
        }

        [TestMethod]
        public void ValidateIsNumericWithDecimalNumber()
        {
            Assert.AreEqual(false, validator.ValidateIsNumeric("2,4"));
        }

        [TestMethod]
        public void ValidateIsNumericWithLettersAndNumbers()
        {
            Assert.AreEqual(false, validator.ValidateIsNumeric("t2e3s4t"));
        }

        [TestMethod]
        public void ValidatePhoneIsNumeric()
        {
            Assert.AreEqual(true, validator.ValidateIsNumeric("099366931"));
        }

        [TestMethod]
        public void ValidateIsNumericWithOnlyLetters()
        {
            Assert.AreEqual(false, validator.ValidateIsNumeric("test"));
        }

        [TestMethod]
        public void ValidateIsEmpty()
        {
            Assert.AreEqual(true, validator.ValidateIsEmpty(""));
        }

        [TestMethod]
        public void ValidateIsNotEmpty()
        {
            Assert.AreEqual(false, validator.ValidateIsEmpty("test"));
        }
    }
}

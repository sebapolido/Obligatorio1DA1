using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace BusinessLogicTest
{
    [TestClass]
    public class ValidatorOfPhoneInUruguayTest
    {
        ValidatorOfPhoneInUruguay validator;

        [TestCleanup]
        public void testClean()
        {
            validator = null;
        }

        [TestInitialize]
        public void testInit()
        {
            validator = new ValidatorOfPhoneInUruguay();
        }

        [TestMethod]
        public void ValidateLengthNumberEmpty()
        {
            string input = "";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberLetters()
        {
            string input = "ASDFGHJKL";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberLessThanEight()
        {
            string input = "09934";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberGreaterTanNine()
        {
            string input = "09923132234";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberNotFirstZeroInALengthOfNine()
        {
            string input = "299366931";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberNotSecondNineInALengthOfNine()
        {
            string input = "029366931";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberNotFirstNineInALengthOfEight()
        {
            string input = "29366931";
            Assert.AreEqual(false, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateCorrectLengthNumberWithLengthOfNine()
        {
            string input = "099366931";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }

        [TestMethod]
        public void ValidateCorrectLengthNumberWithLengthOfEigth()
        {
            string input = "99366931";
            Assert.AreEqual(true, validator.ValidateFormatNumber(ref input));
        }
    }
}

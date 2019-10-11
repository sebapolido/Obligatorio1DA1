using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorOfPhoneTest
    {
        ValidatorOfPhone validator;

        [TestCleanup]
        public void testClean()
        {
            validator = null;
        }

        [TestInitialize]
        public void testInit()
        {
            validator = new ValidatorOfPhone();
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

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfNineEmpty()
        {
            string input = "";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfNine(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfNineLessThanNine()
        {
            string input = "09324";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfNine(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfNineMoreThanNine()
        {
            string input = "09323434344";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfNine(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfNineBadFirstNumber()
        {
            string input = "199366931";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfNine(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfNineBadSecondNumber()
        {
            string input = "019366931";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfNine(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfNineGoodNumber()
        {
            string input = "099366931";
            Assert.AreEqual(true, validator.IsFormatOfLengthOfNine(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfEigthEmpty()
        {
            string input = "";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfEigth(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfEigthLessThanEigth()
        {
            string input = "9324";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfEigth(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfEigthMoreThanEigth()
        {
            string input = "9323434344";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfEigth(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfEigthBadFirstNumber()
        {
            string input = "89366931";
            Assert.AreEqual(false, validator.IsFormatOfLengthOfEigth(input));
        }

        [TestMethod]
        public void ValidateFormatNumberOfLengthOfEigthGoodNumber()
        {
            string input = "99366931";
            Assert.AreEqual(true, validator.IsFormatOfLengthOfEigth(input));
        }
    }
}

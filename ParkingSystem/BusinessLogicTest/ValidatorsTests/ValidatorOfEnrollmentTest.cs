using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorOfEnrollmentTest
    {
        ValidatorOfEnrollment Validator;

        [TestCleanup]
        public void TestClean()
        {
            Validator = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Validator = new ValidatorOfEnrollment();
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineZeroLessThanThree()
        {
            string[] Line = new string[] { "SV", "2343", "60" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineZeroMoreThanThree()
        {
            string[] Line = new string[] { "SDSV", "2343", "60" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineOneLessThanFour()
        {
            string[] Line = new string[] { "SDV", "243" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineOneMoreThanFour()
        {
            string[] Line = new string[] { "SDV", "24323" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceOnlyLetters()
        {
            string[] Line = new string[] { "SDV" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceOnlyNumbers()
        {
            string[] Line = new string[] { "2433" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineCorrectLine()
        {
            string[] Line = new string[] { "SDV", "2433" };
            Assert.AreEqual(true, Validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineLessLetters()
        {
            string[] Line = new string[] { "SD2433" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineLessNumbers()
        {
            string[] Line = new string[] { "SDD433" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineMoreLetters()
        {
            string[] Line = new string[] { "SDDS2433" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineMoreNumbers()
        {
            string[] Line = new string[] { "SDD22433" };
            Assert.AreEqual(false, Validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(Line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceCorrectLine()
        {
            string[] Line = new string[] { "SDS2433" };
            Assert.AreEqual(true, Validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(Line));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmpty()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment(""));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmptyLetters()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmptyNumbers()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLettersInNumbersAndNumbersInLettersWhitoutSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("323FGKR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLettersInNumbersAndNumbersInLettersWhitSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("323 FGKR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessLettersWithoutSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJ2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessLettersWithSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJ 2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreLettersWithoutSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJGF2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreLettersWithSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJJT 2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersWithoutSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GDJG242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersWithSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJG 242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersWithoutSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJG24342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersWithSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJG 34242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersAndLettersWithoutSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GG422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersAndLettersWithSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJ 422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersAndLettersWithoutSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJGN33422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersAndLettersWithSpace()
        {
            Assert.AreEqual(false, Validator.ValidateFormatOfEnrollment("GJGF 43422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentWithoutSpace()
        {
            Assert.AreEqual(true, Validator.ValidateFormatOfEnrollment("GJG3422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentWithSpace()
        {
            Assert.AreEqual(true, Validator.ValidateFormatOfEnrollment("GJG 3422"));
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ValidatorOfEnrollmentTest
    {
        ValidatorOfEnrollment validator;

        [TestCleanup]
        public void TestClean()
        {
            validator = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            validator = new ValidatorOfEnrollment();
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineZeroLessThanThree()
        {
            string[] line = new string[] { "SV", "2343", "60" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineZeroMoreThanThree()
        {
            string[] line = new string[] { "SDSV", "2343", "60" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineOneLessThanFour()
        {
            string[] line = new string[] { "SDV", "243" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineOneMoreThanFour()
        {
            string[] line = new string[] { "SDV", "24323" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceOnlyLetters()
        {
            string[] line = new string[] { "SDV" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceOnlyNumbers()
        {
            string[] line = new string[] { "2433" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithSpaceLineCorrectLine()
        {
            string[] line = new string[] { "SDV", "2433" };
            Assert.AreEqual(true, validator.IsCorrectSeparationOfEnrollmentMessageWithSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineLessLetters()
        {
            string[] line = new string[] { "SD2433" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineLessNumbers()
        {
            string[] line = new string[] { "SDD433" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineMoreLetters()
        {
            string[] line = new string[] { "SDDS2433" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceIncorrectLineMoreNumbers()
        {
            string[] line = new string[] { "SDD22433" };
            Assert.AreEqual(false, validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line));
        }

        [TestMethod]
        public void ValidateSeparationOfEnrollmentMessageWithOutSpaceCorrectLine()
        {
            string[] line = new string[] { "SDS2433" };
            Assert.AreEqual(true, validator.IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmpty()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment(""));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmptyLetters()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmptyNumbers()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLettersInNumbersAndNumbersInLettersWhitoutSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("323FGKR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLettersInNumbersAndNumbersInLettersWhitSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("323 FGKR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessLettersWithoutSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJ2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessLettersWithSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJ 2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreLettersWithoutSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJGF2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreLettersWithSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJJT 2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersWithoutSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GDJG242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersWithSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJG 242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersWithoutSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJG24342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersWithSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJG 34242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersAndLettersWithoutSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GG422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersAndLettersWithSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJ 422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersAndLettersWithoutSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJGN33422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersAndLettersWithSpace()
        {
            Assert.AreEqual(false, validator.ValidateFormatOfEnrollment("GJGF 43422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentWithoutSpace()
        {
            Assert.AreEqual(true, validator.ValidateFormatOfEnrollment("GJG3422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentWithSpace()
        {
            Assert.AreEqual(true, validator.ValidateFormatOfEnrollment("GJG 3422"));
        }
    }
}

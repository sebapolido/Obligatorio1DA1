using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class EnrollmentTest
    {
        public EnrollmentTest()
        {
        }
       
        Enrollment Enrollment;
        Enrollment EnrollmentEmpty;

        [TestCleanup]
        public void TestClean()
        {
            Enrollment = null;
            EnrollmentEmpty = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            EnrollmentEmpty = new Enrollment();
            Enrollment = new Enrollment("SBN", 4849);
        }

        [TestMethod]
        public void CreateEmptyEnrollmentLetters()
        {
            Assert.AreEqual("", EnrollmentEmpty.LettersOfEnrollment);
        }

        [TestMethod]
        public void CreateEmptyEnrollmentNumbers()
        {
            Assert.AreEqual(0, EnrollmentEmpty.NumbersOfEnrollment);
        }

        [TestMethod]
        public void CreateEnrollmentLetters()
        {
            Assert.AreEqual("SBN", Enrollment.LettersOfEnrollment);
        }

        [TestMethod]
        public void CreateEnrollmentNumbers()
        {
            Assert.AreEqual(4849, Enrollment.NumbersOfEnrollment);
        }

        [TestMethod]
        public void ValidateNotEquals()
        {
            Assert.AreEqual(false, Enrollment.Equals(new Enrollment("SDS", 4322)));
        }

        [TestMethod]
        public void ValidateNotEqualsNumbers()
        {
            Assert.AreEqual(false, Enrollment.Equals(new Enrollment("SBN", 4322)));
        }

        [TestMethod]
        public void ValidateNotEqualsLetters()
        {
            Assert.AreEqual(false, Enrollment.Equals(new Enrollment("SDS", 4849)));
        }

        [TestMethod]
        public void ValidateToString()
        {
            Assert.AreEqual("SBN4849", Enrollment.ToString());
        }
    }
}

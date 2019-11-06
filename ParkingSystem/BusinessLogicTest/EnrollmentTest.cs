﻿using System;
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
       
        Enrollment enrollment;
        Enrollment enrollmentEmpty;

        [TestCleanup]
        public void TestClean()
        {
            enrollment = null;
            enrollmentEmpty = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            enrollmentEmpty = new Enrollment();
            enrollment = new Enrollment("SBN", 4849);
        }

        [TestMethod]
        public void CreateEmptyEnrollmentLetters()
        {
            Assert.AreEqual("", enrollmentEmpty.LettersOfEnrollment);
        }

        [TestMethod]
        public void CreateEmptyEnrollmentNumbers()
        {
            Assert.AreEqual(0, enrollmentEmpty.NumbersOfEnrollment);
        }

        [TestMethod]
        public void CreateEnrollmentLetters()
        {
            Assert.AreEqual("SBN", enrollment.LettersOfEnrollment);
        }

        [TestMethod]
        public void CreateEnrollmentNumbers()
        {
            Assert.AreEqual(4849, enrollment.NumbersOfEnrollment);
        }

        [TestMethod]
        public void ValidateNotEquals()
        {
            Assert.AreEqual(false, enrollment.Equals(new Enrollment("SDS", 4322)));
        }

        [TestMethod]
        public void ValidateNotEqualsNumbers()
        {
            Assert.AreEqual(false, enrollment.Equals(new Enrollment("SBN", 4322)));
        }

        [TestMethod]
        public void ValidateNotEqualsLetters()
        {
            Assert.AreEqual(false, enrollment.Equals(new Enrollment("SDS", 4849)));
        }

        [TestMethod]
        public void ValidateToString()
        {
            Assert.AreEqual("SBN4849", enrollment.ToString());
        }
    }
}

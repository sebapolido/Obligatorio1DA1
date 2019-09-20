using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class SystemControllerTest
    {
        SystemController system = new SystemController();

        [TestMethod]
        public void AddAccountEmpty()
        {
            Account account = new Account();
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountMobileEmpty()
        {
            Account account = new Account();
            account.balance = 50;
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInBalance()
        {
            Account account = new Account(-25, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberMoreLength()
        {
            Account account = new Account(25, "099366931343");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberLessLength()
        {
            Account account = new Account(25, "09936");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberFormat()
        {
            Account account = new Account(25, "09ed1343");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountBalanceEmpty()
        {
            Account account = new Account();
            account.mobile = "099366931";
            system.AddAccount(account);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void AddValidAccount()
        {
            Account account = new Account(25, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void AddValidAccountTwoTimes()
        {
            Account account = new Account(25, "099366931");
            system.AddAccount(account);
            system.AddAccount(account);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void AddValidAccountWhitZeroAndWithoutZero()
        {
            Account validAccount = new Account(25, "099366931");
            system.AddAccount(validAccount);
            Account invalidAccount = new Account(25, "  99366931");
            system.AddAccount(invalidAccount);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void getListOfAccountsEmpty()
        {
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void getListOfAccountsWithAccounts()
        {
            Account accountOne = new Account(25, "099366931");
            Account accountTwo = new Account(225, "099366932");
            Account accountThree = new Account(254, "099366933");
            system.AddAccount(accountOne);
            system.AddAccount(accountTwo);
            system.AddAccount(accountThree);
            Assert.AreEqual(3, system.GetAccounts().ToArray().Length);
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void AddEnrollmentEmpty()
        {
            Enrollment enrollment = new Enrollment();
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentWithLetttersEmpty()
        {
            Enrollment enrollment = new Enrollment();
            enrollment.numbersOfEnrollment = 2344;
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentWithNumbersEmpty()
        {
            Enrollment enrollment = new Enrollment();
            enrollment.lettersOfEnrollment = "AAA";
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentLettersLess()
        {
            Enrollment enrollment = new Enrollment("AA" , 2323);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentLettersMore()
        {
            Enrollment enrollment = new Enrollment("AAAA" , 2345);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersLess()
        {
            Enrollment enrollment = new Enrollment("AAA" , 232);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersMore()
        {
            Enrollment enrollment = new Enrollment("AAA" , 23424);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddValidEnrollment()
        {
            Enrollment enrollment = new Enrollment("AAA", 2324);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
            system.GetEnrollments().Clear();
        }

        [TestMethod]
        public void AddTwoEqualsNumbersEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("BBB", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(2, system.GetEnrollments().ToArray().Length);
            system.GetEnrollments().Clear();
        }

        [TestMethod]
        public void AddTwoEqualsLettersEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2345);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(2, system.GetEnrollments().ToArray().Length);
            system.GetEnrollments().Clear();
        }

        [TestMethod]
        public void AddTwoEqualsEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
            system.GetEnrollments().Clear();
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCase()
        {
            Enrollment enrollmentOne = new Enrollment("aaa", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
            system.GetEnrollments().Clear();
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCaseTwo()
        {
            Enrollment enrollmentOne = new Enrollment("AbC", 2344);
            Enrollment enrollmentTwo = new Enrollment("aBc", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
            system.GetEnrollments().Clear();
        }

        [TestMethod]
        public void AddEnrollmentNumbersInLetters()
        {
            Enrollment enrollment = new Enrollment("232", 23424);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void getListOfEnrollmentEmpty()
        {
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void getListOfEnrollmentsWithEnrollments()
        {
            Enrollment enrollmentOne = new Enrollment("ABC", 2931);
            Enrollment enrollmentTwo = new Enrollment("RRE", 6932);
            Enrollment enrollmentThree = new Enrollment("RWQ", 6936);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            system.AddEnrollment(enrollmentThree);
            Assert.AreEqual(3, system.GetEnrollments().ToArray().Length);
            system.GetEnrollments().Clear();
        }

        [TestMethod]
        public void ValidateLengthNumberEmpty()
        {
            Assert.AreEqual(false, system.ValidateLengthNumber(""));
        }

        [TestMethod]
        public void ValidateLengthNumberLetters()
        {
            Assert.AreEqual(false, system.ValidateLengthNumber("ASDFGHJKL"));
        }

        [TestMethod]
        public void ValidateLengthNumberLessThanEight()
        {
            Assert.AreEqual(false, system.ValidateLengthNumber("09934"));
        }

        [TestMethod]
        public void ValidateLengthNumberGreaterTanNine()
        {
            Assert.AreEqual(false, system.ValidateLengthNumber("09935543223"));
        }

        [TestMethod]
        public void ValidateLengthNumberNotFirstZeroInALengthOfNine()
        {
            Assert.AreEqual(false, system.ValidateLengthNumber("299366931"));
        }

        [TestMethod]
        public void ValidateLengthNumberNotSecondNineInALengthOfNine()
        {
            Assert.AreEqual(false, system.ValidateLengthNumber("029366931"));
        }

        [TestMethod]
        public void ValidateLengthNumberNotFirstNineInALengthOfEight()
        {
            Assert.AreEqual(false, system.ValidateLengthNumber("29366931"));
        }

        [TestMethod]
        public void ValidateCorrectLengthNumberWithLengthOfNine()
        {
            Assert.AreEqual(true, system.ValidateLengthNumber("099366931"));
        }

        [TestMethod]
        public void ValidateCorrectLengthNumberWithLengthOfEigth()
        {
            Assert.AreEqual(true, system.ValidateLengthNumber("99366931"));
        }

        [TestMethod]
        public void ValidateIsNumeric()
        {
            Assert.AreEqual(true, system.ValidateIsNumeric("099366931"));
        }

        [TestMethod]
        public void ValidateIsNumericWithLetters()
        {
            Assert.AreEqual(false, system.ValidateIsNumeric("09vd66931"));
        }

        [TestMethod]
        public void ValidateIsNumericWithOnlyLetters()
        {
            Assert.AreEqual(false, system.ValidateIsNumeric("test"));
        }

        [TestMethod]
        public void ValidateRepeatNumberEmpty()
        {
            Assert.AreEqual(false, system.ValidateRepeatNumber(""));
        }

        [TestMethod]
        public void ValidateRepeatNumberBadFormat()
        {
            Assert.AreEqual(false, system.ValidateRepeatNumber("43823"));
        }

        [TestMethod]
        public void ValidateRepeatNumberLetters()
        {
            Assert.AreEqual(false, system.ValidateRepeatNumber("test"));
        }

        [TestMethod]
        public void ValidateRepeatNumberNotRepeated()
        {
            Assert.AreEqual(false, system.ValidateRepeatNumber("099366931"));
        }

        [TestMethod]
        public void ValidateRepeatNumberRepeated()
        {
            system.AddAccount(new Account(0, "099366931"));
            Assert.AreEqual(true, system.ValidateRepeatNumber("099366931"));
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void ValidateGrabAnAccountWithListEmpty()
        {
            Assert.AreEqual(null, system.getAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountOutsideOfTheList()
        {
            system.AddAccount(new Account(0, "098993924"));
            Assert.AreEqual(null, system.getAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfAnAccount()
        {
            Account account = new Account(0, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(account, system.getAnAccount("099366931"));
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfManyAccounts()
        {
            system.AddAccount(new Account(0, "092345678"));
            system.AddAccount(new Account(0, "095345688"));
            system.AddAccount(new Account(0, "092340478"));
            Account account = new Account(0, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(account, system.getAnAccount("099366931"));
            system.GetAccounts().Clear();
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmpty()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment(""));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmptyLetters()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentEmptyNumbers()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessLettersWithoutSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJ2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessLettersWithSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJ 2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreLettersWithoutSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJGF2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreLettersWithSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJJT 2342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersWithoutSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GDJG242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersWithSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJG 242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersWithoutSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJG24342"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersWithSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJG 34242"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersAndLettersWithoutSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GG422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLessNumbersAndLettersWithSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJ 422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersAndLettersWithoutSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJGN33422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentMoreNumbersAndLettersWithSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("GJGF 43422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentWithoutSpace()
        {
            Assert.AreEqual(true, system.ValidateFormatOfEnrollment("GJG3422"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentWithSpace()
        {
            Assert.AreEqual(true, system.ValidateFormatOfEnrollment("GJG 3422"));
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class SystemControllerTest
    {
        SystemController system;


        [TestCleanup]
        public void testClean()
        {
            system.GetAccounts().Clear();
            system.GetEnrollments().Clear();
            system.GetPurchases().Clear();
            system = null;
            
        }

        [TestInitialize]
        public void testInit()
        {
           system = new SystemController();
        }

        [TestMethod]
        public void AddAccountEmpty()
        {
            IAccount account = new Account();
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountMobileEmpty()
        {
            IAccount account = new Account();
            account.balance = 50;
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInBalance()
        {
            IAccount account = new Account(-25, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberMoreLength()
        {
            IAccount account = new Account(25, "099366931343");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberLessLength()
        {
            IAccount account = new Account(25, "09936");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberFormat()
        {
            IAccount account = new Account(25, "09ed1343");
            system.AddAccount(account);
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountBalanceEmpty()
        {
            IAccount account = new Account();
            account.mobile = "099366931";
            system.AddAccount(account);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddValidAccount()
        {
            IAccount account = new Account(25, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddValidAccountTwoTimes()
        {
            IAccount account = new Account(25, "099366931");
            system.AddAccount(account);
            system.AddAccount(account);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddValidAccountWhitZeroAndWithoutZero()
        {
            IAccount validAccount = new Account(25, "099366931");
            system.AddAccount(validAccount);
            IAccount invalidAccount = new Account(25, "  99366931");
            system.AddAccount(invalidAccount);
            Assert.AreEqual(1, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void getListOfAccountsEmpty()
        {
            Assert.AreEqual(0, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void getListOfAccountsWithAccounts()
        {
            IAccount accountOne = new Account(25, "099366931");
            IAccount accountTwo = new Account(225, "099366932");
            IAccount accountThree = new Account(254, "099366933");
            system.AddAccount(accountOne);
            system.AddAccount(accountTwo);
            system.AddAccount(accountThree);
            Assert.AreEqual(3, system.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentEmpty()
        {
            IEnrollment enrollment = new Enrollment();
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentWithLetttersEmpty()
        {
            IEnrollment enrollment = new Enrollment();
            enrollment.numbersOfEnrollment = 2344;
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentWithNumbersEmpty()
        {
            IEnrollment enrollment = new Enrollment();
            enrollment.lettersOfEnrollment = "AAA";
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentLettersLess()
        {
            IEnrollment enrollment = new Enrollment("AA", 2323);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentLettersMore()
        {
            IEnrollment enrollment = new Enrollment("AAAA", 2345);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersLess()
        {
            IEnrollment enrollment = new Enrollment("AAA", 232);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersMore()
        {
            IEnrollment enrollment = new Enrollment("AAA", 23424);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(0, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddValidEnrollment()
        {
            IEnrollment enrollment = new Enrollment("AAA", 2324);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsNumbersEnrollment()
        {
            IEnrollment enrollmentOne = new Enrollment("AAA", 2344);
            IEnrollment enrollmentTwo = new Enrollment("BBB", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(2, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsLettersEnrollment()
        {
            IEnrollment enrollmentOne = new Enrollment("AAA", 2344);
            IEnrollment enrollmentTwo = new Enrollment("AAA", 2345);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(2, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsEnrollment()
        {
            IEnrollment enrollmentOne = new Enrollment("AAA", 2344);
            IEnrollment enrollmentTwo = new Enrollment("AAA", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCase()
        {
            IEnrollment enrollmentOne = new Enrollment("aaa", 2344);
            IEnrollment enrollmentTwo = new Enrollment("AAA", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCaseTwo()
        {
            IEnrollment enrollmentOne = new Enrollment("AbC", 2344);
            IEnrollment enrollmentTwo = new Enrollment("aBc", 2344);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersInLetters()
        {
            IEnrollment enrollment = new Enrollment("232", 23424);
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
            IEnrollment enrollmentOne = new Enrollment("ABC", 2931);
            IEnrollment enrollmentTwo = new Enrollment("RRE", 6932);
            IEnrollment enrollmentThree = new Enrollment("RWQ", 6936);
            system.AddEnrollment(enrollmentOne);
            system.AddEnrollment(enrollmentTwo);
            system.AddEnrollment(enrollmentThree);
            Assert.AreEqual(3, system.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void ValidateLengthNumberEmpty()
        {
            string input = "";
            Assert.AreEqual(false, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberLetters()
        {
            string input = "ASDFGHJKL";
            Assert.AreEqual(false, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberLessThanEight()
        {
            string input = "09934";
            Assert.AreEqual(false, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberGreaterTanNine()
        {
            string input = "09923132234";
            Assert.AreEqual(false, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberNotFirstZeroInALengthOfNine()
        {
            string input = "299366931";
            Assert.AreEqual(false, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberNotSecondNineInALengthOfNine()
        {
            string input = "029366931";
            Assert.AreEqual(false, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateLengthNumberNotFirstNineInALengthOfEight()
        {
            string input = "29366931";
            Assert.AreEqual(false, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateCorrectLengthNumberWithLengthOfNine()
        {
            string input = "099366931";
            Assert.AreEqual(true, system.ValidateLengthNumber(ref input));
        }

        [TestMethod]
        public void ValidateCorrectLengthNumberWithLengthOfEigth()
        {
            string input = "099366931";
            Assert.AreEqual(true, system.ValidateLengthNumber(ref input));
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
            IAccount account = new Account(0, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(account, system.getAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfManyAccounts()
        {
            system.AddAccount(new Account(0, "092345678"));
            system.AddAccount(new Account(0, "095345688"));
            system.AddAccount(new Account(0, "092340478"));
            IAccount account = new Account(0, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(account, system.getAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWithListEmpty()
        {
            Assert.AreEqual(null, system.getAnEnrollment("sbn", 4040));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentOutsideOfTheList()
        {
            system.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, system.getAnEnrollment("sad", 4334));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameLetters()
        {
            system.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, system.getAnEnrollment("sbn", 3922));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameNumbers()
        {
            system.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, system.getAnEnrollment("sbv", 3924));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfEnrollment()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, system.getAnEnrollment("sbn", 4849));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfManyEnrollments()
        {
            system.AddEnrollment(new Enrollment("sbn", 3020));
            system.AddEnrollment(new Enrollment("sbf", 2688));
            system.AddEnrollment(new Enrollment("sdf", 2340));
            IEnrollment enrollment = new Enrollment("fds", 1232);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, system.getAnEnrollment("fds", 1232));
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
        public void ValidateFormatOfEnrollmentLettersInNumbersAndNumbersInLettersWhitoutSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("323FGKR"));
        }

        [TestMethod]
        public void ValidateFormatOfEnrollmentLettersInNumbersAndNumbersInLettersWhitSpace()
        {
            Assert.AreEqual(false, system.ValidateFormatOfEnrollment("323 FGKR"));
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

        [TestMethod]
        public void ValidateRepeatEnrollmentEmpty()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.ValidateRepeatEnrollment("", 0));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentEmptyList()
        {
            Assert.AreEqual(false, system.ValidateRepeatEnrollment("SBN", 4230));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNumbers()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.ValidateRepeatEnrollment("SBM", 4849));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentLetters()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.ValidateRepeatEnrollment("SBN", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNotRepeated()
        {
            Enrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.ValidateRepeatEnrollment("SBM", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentRepeated()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(true, system.ValidateRepeatEnrollment("SBN", 4849));
        }

        [TestMethod]
        public void ValidateHourEmpty()
        {
            DateTime date = new DateTime();
            Assert.AreEqual(false, system.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateHourLessThanTen()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 9, 0, 0);
            Assert.AreEqual(false, system.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateHourMoreThanSixteen()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 21, 0, 0);
            Assert.AreEqual(false, system.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateHourTen()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                 DateTime.Now.Day, 10, 0, 0);
            Assert.AreEqual(true, system.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateHourSixteen()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 18, 0, 0);
            Assert.AreEqual(false, system.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateHourInTheMiddle()
        {
            DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 14, 0, 0);
            Assert.AreEqual(true, system.ValidateValidHour(date));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseZero()
        {
            Assert.AreEqual(false, system.ValideTimeOfPurchase(0));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseNegativeNumber()
        {
            Assert.AreEqual(false, system.ValideTimeOfPurchase(-23));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseNotMultipleOfThirty()
        {
            Assert.AreEqual(false, system.ValideTimeOfPurchase(23));
        }

        [TestMethod]
        public void ValidateTimeOfPurchaseMultipleOfThirty()
        {
            Assert.AreEqual(true, system.ValideTimeOfPurchase(60));
        }

        [TestMethod]
        public void ValidateStringToNumberEmpty()
        {
            Assert.AreEqual(false, system.IsConvertStringToNumber(""));
        }

        [TestMethod]
        public void ValidateStringToNumberWithOneLetter()
        {
            Assert.AreEqual(false, system.IsConvertStringToNumber("t"));
        }

        [TestMethod]
        public void ValidateStringToNumberWithOneNumber()
        {
            Assert.AreEqual(true, system.IsConvertStringToNumber("1"));
        }

        [TestMethod]
        public void ValidateStringToNumberWithDecimalNumber()
        {
            Assert.AreEqual(false, system.IsConvertStringToNumber("2,4"));
        }

        [TestMethod]
        public void ValidateStringToNumberWithLetters()
        {
            Assert.AreEqual(false, system.IsConvertStringToNumber("test"));
        }

        [TestMethod]
        public void ValidateStringToNumberWithNumbers()
        {
            Assert.AreEqual(true, system.IsConvertStringToNumber("232"));
        }

        [TestMethod]
        public void ValidateStringToNumberWithLettersAndNumbers()
        {
            Assert.AreEqual(false, system.IsConvertStringToNumber("t2e3s4t"));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseEmpty()
        {
            Assert.AreEqual(0, system.CalculateFinalTimeOfPurchase(0, 0, 0));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTimeEmpty()
        {
            Assert.AreEqual(0, system.CalculateFinalTimeOfPurchase(0, 10, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseHourEmpty()
        {
            Assert.AreEqual(0, system.CalculateFinalTimeOfPurchase(30, 0, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseMinutesEmpty()
        {
            Assert.AreEqual(0, system.CalculateFinalTimeOfPurchase(30, 20, 0));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseLessThanTen()
        {
            Assert.AreEqual(0, system.CalculateFinalTimeOfPurchase(30, 9, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseMoreThanSixteen()
        {
            Assert.AreEqual(0, system.CalculateFinalTimeOfPurchase(30, 19, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseMinutesMoreOfSixty()
        {
            Assert.AreEqual(0, system.CalculateFinalTimeOfPurchase(30, 10, 70));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteWithMinutes()
        {
            Assert.AreEqual(60, system.CalculateFinalTimeOfPurchase(60, 12, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutes()
        {
            Assert.AreEqual(20, system.CalculateFinalTimeOfPurchase(60, 17, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForOnlyMinutesAndOneHour()
        {
            Assert.AreEqual(80, system.CalculateFinalTimeOfPurchase(90, 16, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForMinutesAndOneHour()
        {
            Assert.AreEqual(60, system.CalculateFinalTimeOfPurchase(60, 16, 40));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeIncompleteForALotOfHours()
        {
            Assert.AreEqual(330, system.CalculateFinalTimeOfPurchase(3000, 12, 30));
        }

        [TestMethod]
        public void ValidateCalculateFinalTimeOfPurchaseTheTimeCompleteForALotOfHours()
        {
            Assert.AreEqual(300, system.CalculateFinalTimeOfPurchase(300, 12, 30));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchases()
        {
            Assert.AreEqual(false, system.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbm" , 3030)));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInMinutes()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, 10, DateTime.Now.Second);
            system.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, 45, DateTime.Now.Second);

            Assert.AreEqual(false, system.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInHours()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 14, DateTime.Now.Minute, DateTime.Now.Second);
            system.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 15, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, system.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInDay()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                23, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            system.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                22, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, system.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInMonth()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, 11,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            system.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, 5,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, system.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInYear()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(2019, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            system.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase));

            DateTime dateTimeOfQuery = new DateTime(2018, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, system.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInLetters()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = DateTime.Now;
            system.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase));
            Assert.AreEqual(false, system.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbm", 4849)));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInNumbers()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = DateTime.Now;
            system.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase));
            Assert.AreEqual(false, system.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbn",4848)));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateOnePurchase()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            system.AddPurchase(new Purchase(enrollment, 30, DateTime.Now));
            Assert.AreEqual(true, system.ArePurchaseOnThatDate(DateTime.Now, enrollment));
        }
   
        [TestMethod]
        public void ValidatePurchaseInTheDateMoreOfOnePurchase()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);

            system.AddPurchase(new Purchase(enrollment, 30, DateTime.Now));
            system.AddPurchase(new Purchase(enrollment, 30, DateTime.Now));
            system.AddPurchase(new Purchase(enrollment, 30, DateTime.Now));
            system.AddPurchase(new Purchase(enrollment, 30, DateTime.Now));
            
            Assert.AreEqual(true, system.ArePurchaseOnThatDate(DateTime.Now, enrollment));
        }

        [TestMethod]
        public void ValidateCheckDateTheSameDate()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            Assert.AreEqual(true, system.CheckDateWithTimeOfPurchase(DateTime.Now, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInTime()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(15);
            Assert.AreEqual(true, system.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateInALimitTime()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(30);
            Assert.AreEqual(true, system.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }

        [TestMethod]
        public void ValidateCheckDateDateOutOfBounds()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateCheck = DateTime.Now;
            dateCheck = dateCheck.AddMinutes(40);
            Assert.AreEqual(false, system.CheckDateWithTimeOfPurchase(dateCheck, new Purchase(enrollment, 30, DateTime.Now)));
        }
    }
}

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
        public void ValidateRepeatNumberEmpty()
        {
            Assert.AreEqual(false, system.IsRepeatedNumber(""));
        }

        [TestMethod]
        public void ValidateRepeatNumberBadFormat()
        {
            Assert.AreEqual(false, system.IsRepeatedNumber("43823"));
        }

        [TestMethod]
        public void ValidateRepeatNumberLetters()
        {
            Assert.AreEqual(false, system.IsRepeatedNumber("test"));
        }

        [TestMethod]
        public void ValidateRepeatNumberNotRepeated()
        {
            Assert.AreEqual(false, system.IsRepeatedNumber("099366931"));
        }

        [TestMethod]
        public void ValidateRepeatNumberRepeated()
        {
            system.AddAccount(new Account(0, "099366931"));
            Assert.AreEqual(true, system.IsRepeatedNumber("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountWithListEmpty()
        {
            Assert.AreEqual(null, system.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountOutsideOfTheList()
        {
            system.AddAccount(new Account(0, "098993924"));
            Assert.AreEqual(null, system.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfAnAccount()
        {
            IAccount account = new Account(0, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(account, system.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfManyAccounts()
        {
            system.AddAccount(new Account(0, "092345678"));
            system.AddAccount(new Account(0, "095345688"));
            system.AddAccount(new Account(0, "092340478"));
            IAccount account = new Account(0, "099366931");
            system.AddAccount(account);
            Assert.AreEqual(account, system.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWithListEmpty()
        {
            Assert.AreEqual(null, system.GetAnEnrollment("sbn", 4040));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentOutsideOfTheList()
        {
            system.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, system.GetAnEnrollment("sad", 4334));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameLetters()
        {
            system.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, system.GetAnEnrollment("sbn", 3922));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameNumbers()
        {
            system.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, system.GetAnEnrollment("sbv", 3924));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfEnrollment()
        {
            IEnrollment enrollment = new Enrollment("sbn", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, system.GetAnEnrollment("sbn", 4849));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfManyEnrollments()
        {
            system.AddEnrollment(new Enrollment("sbn", 3020));
            system.AddEnrollment(new Enrollment("sbf", 2688));
            system.AddEnrollment(new Enrollment("sdf", 2340));
            IEnrollment enrollment = new Enrollment("fds", 1232);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, system.GetAnEnrollment("fds", 1232));
        }

        
        [TestMethod]
        public void ValidateRepeatEnrollmentEmpty()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.IsRepeatedEnrollment("", 0));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentEmptyList()
        {
            Assert.AreEqual(false, system.IsRepeatedEnrollment("SBN", 4230));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNumbers()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.IsRepeatedEnrollment("SBM", 4849));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentLetters()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.IsRepeatedEnrollment("SBN", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNotRepeated()
        {
            Enrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(false, system.IsRepeatedEnrollment("SBM", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentRepeated()
        {
            IEnrollment enrollment = new Enrollment("SBN", 4849);
            system.AddEnrollment(enrollment);
            Assert.AreEqual(true, system.IsRepeatedEnrollment("SBN", 4849));
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

        
    }
}

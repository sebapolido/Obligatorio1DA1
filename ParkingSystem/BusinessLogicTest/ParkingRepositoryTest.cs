using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ParkingRepositoryTest
    {
        IParkingRepository repository;
        CountryHandler uruguay;
        Account account;

        [TestCleanup]
        public void TestClean()
        {
            repository.GetAccounts().Clear();
            repository.GetEnrollments().Clear();
            repository.GetPurchases().Clear();
            repository.GetCountries().Clear();
            repository = null;
            uruguay = null;
            account = null;
        }

        [TestInitialize]
        public void TestInit()
        {
           repository = new ParkingRepository();
           uruguay = new CountryHandler("Uruguay", 1);
           uruguay.SetValidators(new ValidatorOfPhoneInUruguay(), new ValidatorOfMessageInUruguay());
           account = new Account();
           account.Country = uruguay;
        }

        [TestMethod]
        public void AddAccountEmpty()
        {
            repository.AddAccount(account);
            Assert.AreEqual(0, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountMobileEmpty()
        {
           account.Balance = 50;
           repository.AddAccount(account);
           Assert.AreEqual(0, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInBalance()
        {
            Account account = new Account(-25, "099366931", uruguay);
            repository.AddAccount(account);
            Assert.AreEqual(0, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberMoreLength()
        {
            Account account = new Account(25, "099366931343", uruguay);
            repository.AddAccount(account);
            Assert.AreEqual(0, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberLessLength()
        {
            Account account = new Account(25, "09936", uruguay);
            repository.AddAccount(account);
            Assert.AreEqual(0, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberFormat()
        {
            Account account = new Account(25, "09ed1343", uruguay);
            repository.AddAccount(account);
            Assert.AreEqual(0, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddAccountBalanceEmpty()
        {
            account.Mobile = "099366931";
            repository.AddAccount(account);
            Assert.AreEqual(1, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddValidAccount()
        {
            Account account = new Account(25, "099366931", uruguay);
            repository.AddAccount(account);
            Assert.AreEqual(1, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddValidAccountTwoTimes()
        {
            Account account = new Account(25, "099366931", uruguay);
            repository.AddAccount(account);
            repository.AddAccount(account);
            Assert.AreEqual(1, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddValidAccountWhitZeroAndWithoutZero()
        {
            Account validAccount = new Account(25, "099366931", uruguay);
            repository.AddAccount(validAccount);
            Account invalidAccount = new Account(25, "99366931", uruguay);
            repository.AddAccount(invalidAccount);
            Assert.AreEqual(1, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void getListOfAccountsEmpty()
        {
            Assert.AreEqual(0, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void getListOfAccountsWithAccounts()
        {
            Account accountOne = new Account(25, "099366931", uruguay);
            Account accountTwo = new Account(225, "099366932", uruguay);
            Account accountThree = new Account(254, "099366933", uruguay);
            repository.AddAccount(accountOne);
            repository.AddAccount(accountTwo);
            repository.AddAccount(accountThree);
            Assert.AreEqual(3, repository.GetAccounts().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentEmpty()
        {
            Enrollment enrollment = new Enrollment();
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentWithLetttersEmpty()
        {
            Enrollment enrollment = new Enrollment();
            enrollment.NumbersOfEnrollment = 2344;
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentWithNumbersEmpty()
        {
            Enrollment enrollment = new Enrollment();
            enrollment.LettersOfEnrollment = "AAA";
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentLettersLess()
        {
            Enrollment enrollment = new Enrollment("AA", 2323);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentLettersMore()
        {
            Enrollment enrollment = new Enrollment("AAAA", 2345);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersLess()
        {
            Enrollment enrollment = new Enrollment("AAA", 232);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersMore()
        {
            Enrollment enrollment = new Enrollment("AAA", 23424);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddValidEnrollment()
        {
            Enrollment enrollment = new Enrollment("AAA", 2324);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(1, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsNumbersEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("BBB", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(2, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsLettersEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2345);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(2, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCase()
        {
            Enrollment enrollmentOne = new Enrollment("aaa", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCaseTwo()
        {
            Enrollment enrollmentOne = new Enrollment("AbC", 2344);
            Enrollment enrollmentTwo = new Enrollment("aBc", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(1, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddEnrollmentNumbersInLetters()
        {
            Enrollment enrollment = new Enrollment("232", 23424);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void getListOfEnrollmentEmpty()
        {
            Assert.AreEqual(0, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void getListOfEnrollmentsWithEnrollments()
        {
            Enrollment enrollmentOne = new Enrollment("ABC", 2931);
            Enrollment enrollmentTwo = new Enrollment("RRE", 6932);
            Enrollment enrollmentThree = new Enrollment("RWQ", 6936);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            repository.AddEnrollment(enrollmentThree);
            Assert.AreEqual(3, repository.GetEnrollments().ToArray().Length);
        }

        [TestMethod]
        public void AddCountryEmpty()
        {
            CountryHandler country = new CountryHandler("Brasil", 1);
            Assert.AreEqual(2, repository.GetCountries().ToArray().Length);
        }

        [TestMethod]
        public void AddCountry()
        {
            CountryHandler country = new CountryHandler("Brasil", 1);
            repository.AddCountry(country);
            Assert.AreEqual(3, repository.GetCountries().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoCountry()
        {
            CountryHandler country = new CountryHandler("Brasil", 1);
            CountryHandler secondCountry = new CountryHandler("Chile", 1);
            repository.AddCountry(country);
            repository.AddCountry(secondCountry);
            Assert.AreEqual(4, repository.GetCountries().ToArray().Length);
        }

        [TestMethod]
        public void AddTwoEqualsCountry()
        {
            CountryHandler country = new CountryHandler("Brasil", 1);
            CountryHandler secondCountry = new CountryHandler("Brasil", 2);
            repository.AddCountry(country);
            repository.AddCountry(secondCountry);
            Assert.AreEqual(3, repository.GetCountries().ToArray().Length);
        }

        [TestMethod]
        public void ValidateRepeatNumberEmpty()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber("", uruguay));
        }

        [TestMethod]
        public void ValidateRepeatNumberBadFormat()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber("43823", uruguay));
        }

        [TestMethod]
        public void ValidateRepeatNumberLetters()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber("test", uruguay));
        }

        [TestMethod]
        public void ValidateRepeatNumberNotRepeated()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber("099366931", uruguay));
        }

        [TestMethod]
        public void ValidateRepeatNumberRepeated()
        {
            repository.AddAccount(new Account(0, "099366931", uruguay));
            Assert.AreEqual(true, repository.IsRepeatedNumber("099366931", uruguay));
        }

        [TestMethod]
        public void ValidateGrabAnAccountWithListEmpty()
        {
            Assert.AreEqual(null, repository.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountOutsideOfTheList()
        {
            repository.AddAccount(new Account(0, "098993924", uruguay));
            Assert.AreEqual(null, repository.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfAnAccount()
        {
            Account account = new Account(0, "099366931", uruguay);
            repository.AddAccount(account);
            Assert.AreEqual(account, repository.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfManyAccounts()
        {
            repository.AddAccount(new Account(0, "092345678", uruguay));
            repository.AddAccount(new Account(0, "095345688", uruguay));
            repository.AddAccount(new Account(0, "092340478", uruguay));
            Account account = new Account(0, "099366931", uruguay);
            repository.AddAccount(account);
            Assert.AreEqual(account, repository.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWithListEmpty()
        {
            Assert.AreEqual(null, repository.GetAnEnrollment("sbn", 4040));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentOutsideOfTheList()
        {
            repository.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, repository.GetAnEnrollment("sad", 4334));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameLetters()
        {
            repository.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, repository.GetAnEnrollment("sbn", 3922));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameNumbers()
        {
            repository.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, repository.GetAnEnrollment("sbv", 3924));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfEnrollment()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, repository.GetAnEnrollment("sbn", 4849));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfManyEnrollments()
        {
            repository.AddEnrollment(new Enrollment("sbn", 3020));
            repository.AddEnrollment(new Enrollment("sbf", 2688));
            repository.AddEnrollment(new Enrollment("sdf", 2340));
            Enrollment enrollment = new Enrollment("fds", 1232);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, repository.GetAnEnrollment("fds", 1232));
        }        

        [TestMethod]
        public void ValidateGrabAnCountryOutsideOfTheList()
        {
            Assert.AreEqual(null, repository.GetACountry("Brasil"));
        }

        [TestMethod]
        public void ValidateGrabAnCountryInTheList()
        {
            CountryHandler brasil = new CountryHandler("Brasil", 5);
            repository.AddCountry(brasil);
            Assert.AreEqual(brasil, repository.GetACountry("Brasil"));
        }
        
        [TestMethod]
        public void ValidateGrabACountryInTheListOfManyCountries()
        {
            repository.AddCountry(new CountryHandler("Argentina", 2));
            repository.AddCountry(new CountryHandler("Chile", 3));
            repository.AddCountry(new CountryHandler("Brasil", 2));
            CountryHandler venezuela = new CountryHandler("Venezuela", 3);
            repository.AddCountry(venezuela);
            Assert.AreEqual(venezuela, repository.GetACountry("Venezuela"));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentEmpty()
        {
            Enrollment enrollment = new Enrollment("SBN", 4849);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("", 0));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentEmptyList()
        {
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("SBN", 4230));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNumbers()
        {
            Enrollment enrollment = new Enrollment("SBN", 4849);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("SBM", 4849));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentLetters()
        {
            Enrollment enrollment = new Enrollment("SBN", 4849);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("SBN", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNotRepeated()
        {
            Enrollment enrollment = new Enrollment("SBN", 4849);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("SBM", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentRepeated()
        {
            Enrollment enrollment = new Enrollment("SBN", 4849);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(true, repository.IsRepeatedEnrollment("SBN", 4849));
        }

        [TestMethod]
        public void ValidateRepeatCountryNotRepeated()
        {
            CountryHandler country = new CountryHandler("Brasil", 1);
            repository.AddCountry(country);
            Assert.AreEqual(false, repository.IsRepeatedCountry("Chile"));
        }

        [TestMethod]
        public void ValidateRepeatCountryEmptyList()
        {
            Assert.AreEqual(false, repository.IsRepeatedCountry("Chile"));
        }

        [TestMethod]
        public void ValidateRepeatCountry()
        {
            CountryHandler country = new CountryHandler("Brasil", 2);
            repository.AddCountry(country);
            Assert.AreEqual(true, repository.IsRepeatedCountry("Brasil"));
        }
        
        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchases()
        {
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbm" , 3030)));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInMinutes()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, 10, DateTime.Now.Second);
            repository.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase, account));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, 45, DateTime.Now.Second);

            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInHours()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 14, DateTime.Now.Minute, DateTime.Now.Second);
            repository.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase, account));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, 15, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInDay()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                23, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            repository.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase, account));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                22, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInMonth()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(DateTime.Now.Year, 11,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            repository.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase, account));

            DateTime dateTimeOfQuery = new DateTime(DateTime.Now.Year, 5,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInYear()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = new DateTime(2019, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            repository.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase, account));

            DateTime dateTimeOfQuery = new DateTime(2018, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInLetters()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = DateTime.Now;
            repository.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase, account));
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbm", 4849)));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInNumbers()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            DateTime dateTimeOfPurchase = DateTime.Now;
            repository.AddPurchase(new Purchase(enrollment, 30, dateTimeOfPurchase, account));
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbn",4848)));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateOnePurchase()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);
            repository.AddPurchase(new Purchase(enrollment, 30, DateTime.Now, account));
            Assert.AreEqual(true, repository.ArePurchaseOnThatDate(DateTime.Now, enrollment));
        }
   
        [TestMethod]
        public void ValidatePurchaseInTheDateMoreOfOnePurchase()
        {
            Enrollment enrollment = new Enrollment("sbn", 4849);

            repository.AddPurchase(new Purchase(enrollment, 30, DateTime.Now, account));
            repository.AddPurchase(new Purchase(enrollment, 30, DateTime.Now, account));
            repository.AddPurchase(new Purchase(enrollment, 30, DateTime.Now, account));
            repository.AddPurchase(new Purchase(enrollment, 30, DateTime.Now, account));
            
            Assert.AreEqual(true, repository.ArePurchaseOnThatDate(DateTime.Now, enrollment));
        }        

        [TestMethod]
        public void AddInvalidBalanceTest()
        {
            repository.AddBalanceToAccount(account, -25);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceInZeroTest()
        {
            repository.AddBalanceToAccount(account, 25);
            Assert.AreEqual(25, account.Balance);
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceTest()
        {
            repository.AddBalanceToAccount(account, 22);
            repository.AddBalanceToAccount(account, 25);
            Assert.AreEqual(47, account.Balance);
        }

        [TestMethod]
        public void SubstractInvalidBalanceTest()
        {
            repository.SubstractBalanceToAccount(account, -25);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void SubstractBalanceWithBalanceInZeroTest()
        {
            repository.SubstractBalanceToAccount(account, 25);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void SubstractBalanceMoreThanTheAccountBalance()
        {
            repository.AddBalanceToAccount(account, 20);
            repository.SubstractBalanceToAccount(account, 25);
            Assert.AreEqual(20, account.Balance);
        }

        [TestMethod]
        public void SubstracTheSameBalanceInTheAccount()
        {
            repository.AddBalanceToAccount(account, 22);
            repository.SubstractBalanceToAccount(account, 22);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void SubstracBalanceInTheAccount()
        {
            repository.AddBalanceToAccount(account, 22);
            repository.SubstractBalanceToAccount(account, 12);
            Assert.AreEqual(10, account.Balance);
        }
    }
}

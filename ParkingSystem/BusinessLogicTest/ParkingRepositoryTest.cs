using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ParkingRepositoryTest
    {
        IParkingRepository repository;
        Account account;
        Enrollment enrollment;

        [TestCleanup]
        public void TestClean() {
            account = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            repository = new ParkingRepository();
            repository.GetAccounts().Clear();
            repository.GetEnrollments().Clear();
            repository.GetPurchases().Clear();
            account = new Account();
            account.Mobile = "099344951";
            account.Balance = 0;
            enrollment = new Enrollment("sbn", 4849);
            account.Country = repository.GetACountry("Uruguay");
        }

        [TestMethod]
        public void AddAccountEmpty()
        {
            account.Mobile = "";
            repository.AddAccount(account);
            Assert.AreEqual(false, repository.GetAccounts().Contains(account));
        }

        [TestMethod]
        public void AddAccountMobileEmpty()
        {
           account.Mobile = "";
           account.Balance = 50;
           repository.AddAccount(account);
           Assert.AreEqual(false, repository.GetAccounts().Contains(account));
        }

        [TestMethod]
        public void AddAccountWithErrorInBalance()
        {
            account.Balance = -25;
            repository.AddAccount(account);
            Assert.AreEqual(false, repository.GetAccounts().Contains(account));
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberLessLength()
        {
            account.Mobile = "09936";
            repository.AddAccount(account);
            Assert.AreEqual(false, repository.GetAccounts().Contains(account));
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberFormat()
        {
            account.Mobile = "09ed1343";
            repository.AddAccount(account);
            Assert.AreEqual(false, repository.GetAccounts().Contains(account));
        }

        [TestMethod]
        public void AddAccountBalanceEmpty()
        {
            account.Mobile = "099123496";
            repository.AddAccount(account);
            Assert.AreEqual(true, repository.GetAccounts().Contains(account));
        }

        [TestMethod]
        public void AddValidAccount()
        {
            repository.AddAccount(account);
            Assert.AreEqual(true, repository.GetAccounts().Contains(account));
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void AddValidAccountTwoTimes()
        {
            repository.AddAccount(account);
            repository.AddAccount(account);
            Assert.AreEqual(true, repository.GetAccounts().Contains(account));
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void AddValidAccountWhitZeroAndWithoutZero()
        {
            Account validAccount = new Account(25, "099366931", repository.GetACountry("Uruguay"));
            repository.AddAccount(validAccount);
            Account invalidAccount = new Account(25, "99366931", repository.GetACountry("Uruguay"));
            repository.AddAccount(invalidAccount);
            Assert.AreEqual(false, repository.GetAccounts().Contains(invalidAccount));
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void AddEnrollmentEmpty()
        {
            Enrollment enrollment = new Enrollment();
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddEnrollmentWithLetttersEmpty()
        {
            Enrollment enrollment = new Enrollment();
            enrollment.NumbersOfEnrollment = 2344;
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddEnrollmentWithNumbersEmpty()
        {
            Enrollment enrollment = new Enrollment();
            enrollment.LettersOfEnrollment = "AAA";
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddEnrollmentLettersLess()
        {
            Enrollment enrollment = new Enrollment("AA", 2323);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddEnrollmentLettersMore()
        {
            Enrollment enrollment = new Enrollment("AAAA", 2345);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddEnrollmentNumbersLess()
        {
            Enrollment enrollment = new Enrollment("AAA", 232);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddEnrollmentNumbersMore()
        {
            Enrollment enrollment = new Enrollment("AAA", 23424);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddValidEnrollment()
        {
            Enrollment enrollment = new Enrollment("AAA", 2324);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(true, repository.GetEnrollments().Contains(enrollment));
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
            }
        }

        [TestMethod]
        public void AddTwoEqualsNumbersEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("BBB", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(true, repository.GetEnrollments().Contains(enrollmentTwo));
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollmentOne);
                myContext.Enrollments.Attach(enrollmentTwo);
            }
        }

        [TestMethod]
        public void AddTwoEqualsLettersEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2346);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2347);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(true, repository.GetEnrollments().Contains(enrollmentTwo));
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollmentOne);
                myContext.Enrollments.Attach(enrollmentTwo);
            }
        }

        [TestMethod]
        public void AddTwoEqualsEnrollment()
        {
            Enrollment enrollmentOne = new Enrollment("AAA", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollmentTwo));
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollmentOne);
            }
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCase()
        {
            Enrollment enrollmentOne = new Enrollment("aaa", 2344);
            Enrollment enrollmentTwo = new Enrollment("AAA", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollmentTwo));
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollmentOne);
            }
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCaseTwo()
        {
            Enrollment enrollmentOne = new Enrollment("AbC", 2344);
            Enrollment enrollmentTwo = new Enrollment("aBc", 2344);
            repository.AddEnrollment(enrollmentOne);
            repository.AddEnrollment(enrollmentTwo);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollmentTwo));
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollmentOne);
            }
        }

        [TestMethod]
        public void AddEnrollmentNumbersInLetters()
        {
            Enrollment enrollment = new Enrollment("232", 23424);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.GetEnrollments().Contains(enrollment));
        }

        [TestMethod]
        public void AddCountryEmpty()
        {
            CountryHandler country = new CountryHandler("Bolivia", 1);
            Assert.AreEqual(false, repository.GetCountries().Contains(country));
        }

        [TestMethod]
        public void AddCountry()
        {
            repository.GetCountries().Clear();
            CountryHandler country = new CountryHandler("Brasil", 1);
            repository.AddCountry(country);
            Assert.AreEqual(true, repository.GetCountries().Contains(country));
            using (var myContext = new MyContext())
            {
                myContext.Countries.Attach(country);
            }
        }

        [TestMethod]
        public void AddTwoEqualsCountry()
        {
            CountryHandler country = new CountryHandler("Brasil", 1);
            CountryHandler secondCountry = new CountryHandler("Brasil", 2);
            repository.AddCountry(country);
            repository.AddCountry(secondCountry);
            Assert.AreEqual(false, repository.GetCountries().Contains(secondCountry));
            using (var myContext = new MyContext())
            {
                myContext.Countries.Attach(country);
            }
        }

        [TestMethod]
        public void ValidateRepeatNumberEmpty()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber(""));
        }

        [TestMethod]
        public void ValidateRepeatNumberBadFormat()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber("43823"));
        }

        [TestMethod]
        public void ValidateRepeatNumberLetters()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber("test"));
        }

        [TestMethod]
        public void ValidateRepeatNumberNotRepeated()
        {
            Assert.AreEqual(false, repository.IsRepeatedNumber("12398989898"));
        }

        [TestMethod]
        public void ValidateRepeatNumberRepeated()
        {
            repository.AddAccount(new Account(0, "099366931", repository.GetACountry("Uruguay")));
            Assert.AreEqual(true, repository.IsRepeatedNumber("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountWithListEmpty()
        {
            Assert.AreEqual(null, repository.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountOutsideOfTheList()
        {
            Account account = new Account(0, "098993924", repository.GetACountry("Uruguay"));
            repository.AddAccount(account);
            Assert.AreEqual(null, repository.GetAnAccount("099366931"));
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfAnAccount()
        {
            Account account = new Account(0, "099366931", repository.GetACountry("Uruguay"));
            repository.AddAccount(account);
            Assert.AreEqual(account, repository.GetAnAccount("099366931"));
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfManyAccounts()
        {
            repository.AddAccount(new Account(0, "092345678", repository.GetACountry("Uruguay")));
            repository.AddAccount(new Account(0, "095345688", repository.GetACountry("Uruguay")));
            repository.AddAccount(new Account(0, "092340478", repository.GetACountry("Uruguay")));
            Account account = new Account(0, "099366931", repository.GetACountry("Uruguay"));
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
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, repository.GetAnEnrollment("sbn", 4849));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfManyEnrollments()
        {
            Enrollment enrollment = new Enrollment("fds", 1232);
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(enrollment, repository.GetAnEnrollment("fds", 1232));
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
            }
        }        

        [TestMethod]
        public void ValidateGrabAnCountryOutsideOfTheList()
        {
            repository.GetCountries().Clear();
            Assert.AreEqual(null, repository.GetACountry("Brasil"));
        }

        [TestMethod]
        public void ValidateGrabAnCountryInTheList()
        {
            repository.GetCountries().Clear();
            CountryHandler brasil = new CountryHandler("Brasil", 5);
            repository.AddCountry(brasil);
            Assert.AreEqual(brasil, repository.GetACountry("Brasil"));
        }
        
        [TestMethod]
        public void ValidateGrabACountryInTheListOfManyCountries()
        {
            repository.GetCountries().Clear();
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
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("SBM", 4849));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentLetters()
        {
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("SBN", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNotRepeated()
        {
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(false, repository.IsRepeatedEnrollment("SBM", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentRepeated()
        {
            repository.AddEnrollment(enrollment);
            Assert.AreEqual(true, repository.IsRepeatedEnrollment("SBN", 4849));
        }

        [TestMethod]
        public void ValidateRepeatCountryNotRepeated()
        {
            repository.GetCountries().Clear();
            CountryHandler country = new CountryHandler("Brasil", 1);
            repository.AddCountry(country);
            Assert.AreEqual(false, repository.IsRepeatedCountry(""));
        }

        [TestMethod]
        public void ValidateRepeatCountryEmptyList()
        {
            repository.GetCountries().Clear();
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
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 20, 0);
            Purchase purchase = new Purchase(enrollment, 30, dateTimeOfPurchase, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 4, 20, 13, 0, 0);
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInHours()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase purchase = new Purchase(enrollment, 30, dateTimeOfPurchase, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 4, 20, 14, 0, 0);
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInDay()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase purchase = new Purchase(enrollment, 30, dateTimeOfPurchase, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 4, 22, 13, 0, 0);
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInMonth()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 11, 20, 13, 0, 0);
            Purchase purchase = new Purchase(enrollment, 30, dateTimeOfPurchase, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 5, 20, 13, 0, 0);
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInYear()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase purchase = new Purchase(enrollment, 30, dateTimeOfPurchase, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            DateTime dateTimeOfQuery = new DateTime(2018, 4, 20, 13, 0, 0);
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(dateTimeOfQuery, enrollment));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInLetters()
        {
            DateTime dateTimeOfPurchase = DateTime.Now;
            Purchase purchase = new Purchase(enrollment, 30, dateTimeOfPurchase, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbm", 4849)));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInNumbers()
        {
            DateTime dateTimeOfPurchase = DateTime.Now;
            Purchase purchase = new Purchase(enrollment, 30, dateTimeOfPurchase, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            Assert.AreEqual(false, repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbn",4848)));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateOnePurchase()
        {
            Purchase purchase = new Purchase(enrollment, 30, DateTime.Now, account);
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            repository.AddPurchase(purchase);
            Assert.AreEqual(true, repository.ArePurchaseOnThatDate(DateTime.Now, enrollment));
            using (var myContext = new MyContext())
            {
                myContext.Purchases.Attach(purchase);
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
            }
        }    

        [TestMethod]
        public void AddInvalidBalanceTest()
        {
            repository.AddAccount(account);
            repository.AddBalanceToAccount(account, -25);
            Assert.AreEqual(0, account.Balance);
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceInZeroTest()
        {
            repository.AddAccount(account);
            repository.AddBalanceToAccount(account, 25);
            Assert.AreEqual(25, account.Balance);
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceTest()
        {
            account.Mobile = "099344951";
            account.Balance = 0;
            repository.AddAccount(account);
            repository.AddBalanceToAccount(account, 22);
            repository.AddBalanceToAccount(account, 25);
            Assert.AreEqual(47, account.Balance);
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void SubstractInvalidBalanceTest()
        {
            repository.AddAccount(account);
            repository.SubstractBalanceToAccount(account, -25);
            Assert.AreEqual(0, account.Balance);
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void SubstractBalanceWithBalanceInZeroTest()
        {
            account.Mobile = "099344951";
            account.Balance = 0;
            repository.AddAccount(account);
            repository.SubstractBalanceToAccount(account, 25);
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void SubstractBalanceMoreThanTheAccountBalance()
        {
            repository.AddAccount(account);
            repository.AddBalanceToAccount(account, 20);
            repository.SubstractBalanceToAccount(account, 25);
            Assert.AreEqual(20, account.Balance);
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void SubstracTheSameBalanceInTheAccount()
        {
            repository.AddAccount(account);
            repository.AddBalanceToAccount(account, 22);
            repository.SubstractBalanceToAccount(account, 22);
            Assert.AreEqual(0, account.Balance);
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void SubstracBalanceInTheAccount()
        {
            repository.AddAccount(account);
            repository.AddBalanceToAccount(account, 22);
            repository.SubstractBalanceToAccount(account, 12);
            Assert.AreEqual(10, account.Balance);
            using (var myContext = new MyContext())
            {
                myContext.Accounts.Attach(account);
            }
        }

        [TestMethod]
        public void InsertPurchaseOfEnrollmentEmpty()
        {
            repository.GetPurchases().Clear();
            repository.AddEnrollment(enrollment);
            List<Purchase> purchases = repository.InsertPurchaseOfEnrollmentToDataGridView(enrollment);
            Assert.AreEqual(0, purchases.ToArray().Length);
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
            }
        }

        [TestMethod]
        public void InsertPurchaseOfEnrollment()
        {
            repository.GetPurchases().Clear();
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            Purchase purchase = new Purchase(enrollment, 30, DateTime.Now, account);
            repository.AddPurchase(purchase);
            List<Purchase> purchases = repository.InsertPurchaseOfEnrollmentToDataGridView(enrollment);
            Assert.AreEqual(1, purchases.ToArray().Length);
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
                myContext.Purchases.Attach(purchase);
            }
        }

        [TestMethod]
        public void InsertPurchaseOnThatDateEmpty()
        {
            repository.GetPurchases().Clear();
            repository.AddEnrollment(enrollment);
            DateTime dateTimeInitial = new DateTime(2019, 4, 20, 12, 0, 0);
            DateTime dateTimeFinal = new DateTime(2019, 4, 20, 13, 00, DateTime.Now.Second);
            List<Purchase> purchases = repository.InsertPurchaseOnThatDate(dateTimeInitial, dateTimeFinal);
            Assert.AreEqual(0, purchases.ToArray().Length);
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
            }
        }

        [TestMethod]
        public void InsertPurchaseOnThatDate()
        {
            repository.GetPurchases().Clear();
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            DateTime dateTimeInitial = new DateTime(2019, 4, 20, 12, 0, 0);
            DateTime dateTimeFinal = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase purchase = new Purchase(enrollment, 30, dateTimeFinal, account);
            repository.AddPurchase(purchase);
            List<Purchase> purchases = repository.InsertPurchaseOnThatDate(dateTimeInitial, dateTimeFinal);
            Assert.AreEqual(1, purchases.ToArray().Length);
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
                myContext.Purchases.Attach(purchase);
            }
        }

        [TestMethod]
        public void EliminatePurchaseFromAnotherCountryEmpty()
        {
            repository.GetPurchases().Clear();
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            Purchase purchase = new Purchase(enrollment, 30, DateTime.Now, account);
            repository.AddPurchase(purchase);
            List<Purchase> purchases = repository.EliminatePurchasesFromAnoterCountry(repository.GetPurchases(), repository.GetACountry("Argentina"));
            Assert.AreEqual(0, purchases.ToArray().Length);
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
                myContext.Purchases.Attach(purchase);
            }
        }

        [TestMethod]
        public void EliminatePurchaseFromAnotherCountry()
        {
            repository.GetPurchases().Clear();
            repository.AddAccount(account);
            repository.AddEnrollment(enrollment);
            DateTime dateTimeInitial = new DateTime(2019, 4, 20, 12, 0, 0);
            DateTime dateTimeFinal = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase purchase = new Purchase(enrollment, 30, dateTimeFinal, account);
            repository.AddPurchase(purchase);
            List<Purchase> purchases = repository.EliminatePurchasesFromAnoterCountry(repository.GetPurchases(), repository.GetACountry("Uruguay"));
            Assert.AreEqual(1, purchases.ToArray().Length);
            using (var myContext = new MyContext())
            {
                myContext.Enrollments.Attach(enrollment);
                myContext.Accounts.Attach(account);
                myContext.Purchases.Attach(purchase);
            }
        }

        [TestMethod]
        public void UpdateCostOfMinutes()
        {
            repository.GetCountries().Clear();
            CountryHandler country = new CountryHandler("Uruguay", 1);
            country.SetValidators(new ValidatorOfPhoneInUruguay(), new ValidatorOfMessageInUruguay());
            repository.AddCountry(country);
            country.CostForMinutes = 2;
            repository.UpdateCostForMinutes(country);
            Assert.AreEqual(2, country.CostForMinutes);
            using (var myContext = new MyContext())
            {
                myContext.Countries.Attach(country);
            }
        }
    }
}

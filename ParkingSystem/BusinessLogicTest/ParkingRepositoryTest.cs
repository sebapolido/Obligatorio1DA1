using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataBaseConnection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class ParkingRepositoryTest
    {
        IParkingRepository Repository;
        Account Account;
        Enrollment Enrollment;

        [TestCleanup]
        public void TestClean() {
            Account = null;
        }

        [TestInitialize]
        public void TestInit()
        {
            Repository = new ParkingRepository();
            Repository.GetAccounts().Clear();
            Repository.GetEnrollments().Clear();
            Repository.GetPurchases().Clear();
            Account = new Account();
            Account.Mobile = "099344951";
            Account.Balance = 0;
            Enrollment = new Enrollment("sbn", 4849);
            Account.Country = Repository.GetACountry("Uruguay");
        }

        [TestMethod]
        public void ValidateIsNumericEmpty()
        {
            Assert.AreEqual(false, Account.Country.ValidateIsNumericByCountry(""));
        }

        [TestMethod]
        public void ValidateIsNumericWithOneNumber()
        {
            Assert.AreEqual(true, Account.Country.ValidateIsNumericByCountry("1"));
        }

        [TestMethod]
        public void ValidateIsNumericWithDecimalNumber()
        {
            Assert.AreEqual(false, Account.Country.ValidateIsNumericByCountry("2,4"));
        }

        [TestMethod]
        public void ValidateIsNumericWithLettersAndNumbers()
        {
            Assert.AreEqual(false, Account.Country.ValidateIsNumericByCountry("t2e3s4t"));
        }

        [TestMethod]
        public void ValidatePhoneIsNumeric()
        {
            Assert.AreEqual(true, Account.Country.ValidateIsNumericByCountry("099366931"));
        }

        [TestMethod]
        public void ValidateIsEmpty()
        {
            Assert.AreEqual(true, Account.Country.ValidateIsEmptyByCountry(""));
        }

        [TestMethod]
        public void ValidateIsNotEmpty()
        {
            Assert.AreEqual(false, Account.Country.ValidateIsEmptyByCountry("test"));
        }

        [TestMethod]
        public void AddAccountEmpty()
        {
            Account.Mobile = "";
            Repository.AddAccount(Account);
            Assert.AreEqual(false, Repository.GetAccounts().Contains(Account));
        }

        [TestMethod]
        public void AddAccountMobileEmpty()
        {
           Account.Mobile = "";
           Account.Balance = 50;
           Repository.AddAccount(Account);
           Assert.AreEqual(false, Repository.GetAccounts().Contains(Account));
        }

        [TestMethod]
        public void AddAccountWithErrorInBalance()
        {
            Account.Balance = -25;
            Repository.AddAccount(Account);
            Assert.AreEqual(false, Repository.GetAccounts().Contains(Account));
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberLessLength()
        {
            Account.Mobile = "09936";
            Repository.AddAccount(Account);
            Assert.AreEqual(false, Repository.GetAccounts().Contains(Account));
        }

        [TestMethod]
        public void AddAccountWithErrorInNumberFormat()
        {
            Account.Mobile = "09ed1343";
            Repository.AddAccount(Account);
            Assert.AreEqual(false, Repository.GetAccounts().Contains(Account));
        }

        [TestMethod]
        public void AddAccountBalanceEmpty()
        {
            Account.Mobile = "099123496";
            Repository.AddAccount(Account);
            Assert.AreEqual(true, Repository.GetAccounts().Contains(Account));
        }

        [TestMethod]
        public void AddValidAccount()
        {
            Repository.AddAccount(Account);
            Assert.AreEqual(true, Repository.GetAccounts().Contains(Account));
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void AddValidAccountTwoTimes()
        {
            Repository.AddAccount(Account);
            Repository.AddAccount(Account);
            Assert.AreEqual(true, Repository.GetAccounts().Contains(Account));
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void AddValidAccountWhitZeroAndWithoutZero()
        {
            Account validAccount = new Account(25, "099366931", Repository.GetACountry("Uruguay"));
            Repository.AddAccount(validAccount);
            Account invalidAccount = new Account(25, "99366931", Repository.GetACountry("Uruguay"));
            Repository.AddAccount(invalidAccount);
            Assert.AreEqual(false, Repository.GetAccounts().Contains(invalidAccount));
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void AddEnrollmentEmpty()
        {
            Enrollment Enrollment = new Enrollment();
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddEnrollmentWithLetttersEmpty()
        {
            Enrollment Enrollment = new Enrollment();
            Enrollment.NumbersOfEnrollment = 2344;
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddEnrollmentWithNumbersEmpty()
        {
            Enrollment Enrollment = new Enrollment();
            Enrollment.LettersOfEnrollment = "AAA";
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddEnrollmentLettersLess()
        {
            Enrollment Enrollment = new Enrollment("AA", 2323);
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddEnrollmentLettersMore()
        {
            Enrollment Enrollment = new Enrollment("AAAA", 2345);
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddEnrollmentNumbersLess()
        {
            Enrollment Enrollment = new Enrollment("AAA", 232);
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddEnrollmentNumbersMore()
        {
            Enrollment Enrollment = new Enrollment("AAA", 23424);
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddValidEnrollment()
        {
            Enrollment Enrollment = new Enrollment("AAA", 2324);
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(true, Repository.GetEnrollments().Contains(Enrollment));
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
            }
        }

        [TestMethod]
        public void AddTwoEqualsNumbersEnrollment()
        {
            Enrollment EnrollmentOne = new Enrollment("AAA", 2344);
            Enrollment EnrollmentTwo = new Enrollment("BBB", 2344);
            Repository.AddEnrollment(EnrollmentOne);
            Repository.AddEnrollment(EnrollmentTwo);
            Assert.AreEqual(true, Repository.GetEnrollments().Contains(EnrollmentTwo));
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(EnrollmentOne);
                MyContext.Enrollments.Attach(EnrollmentTwo);
            }
        }

        [TestMethod]
        public void AddTwoEqualsLettersEnrollment()
        {
            Enrollment EnrollmentOne = new Enrollment("AAA", 2346);
            Enrollment EnrollmentTwo = new Enrollment("AAA", 2347);
            Repository.AddEnrollment(EnrollmentOne);
            Repository.AddEnrollment(EnrollmentTwo);
            Assert.AreEqual(true, Repository.GetEnrollments().Contains(EnrollmentTwo));
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(EnrollmentOne);
                MyContext.Enrollments.Attach(EnrollmentTwo);
            }
        }

        [TestMethod]
        public void AddTwoEqualsEnrollment()
        {
            Enrollment EnrollmentOne = new Enrollment("AAA", 2344);
            Enrollment EnrollmentTwo = new Enrollment("AAA", 2344);
            Repository.AddEnrollment(EnrollmentOne);
            Repository.AddEnrollment(EnrollmentTwo);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(EnrollmentTwo));
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(EnrollmentOne);
            }
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCase()
        {
            Enrollment EnrollmentOne = new Enrollment("aaa", 2344);
            Enrollment EnrollmentTwo = new Enrollment("AAA", 2344);
            Repository.AddEnrollment(EnrollmentOne);
            Repository.AddEnrollment(EnrollmentTwo);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(EnrollmentTwo));
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(EnrollmentOne);
            }
        }

        [TestMethod]
        public void AddTwoEqualsLettersInUpperAndLowerCaseTwo()
        {
            Enrollment EnrollmentOne = new Enrollment("AbC", 2344);
            Enrollment EnrollmentTwo = new Enrollment("aBc", 2344);
            Repository.AddEnrollment(EnrollmentOne);
            Repository.AddEnrollment(EnrollmentTwo);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(EnrollmentTwo));
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(EnrollmentOne);
            }
        }

        [TestMethod]
        public void AddEnrollmentNumbersInLetters()
        {
            Enrollment Enrollment = new Enrollment("232", 23424);
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.GetEnrollments().Contains(Enrollment));
        }

        [TestMethod]
        public void AddCountryEmpty()
        {
            CountryHandler Country = new CountryHandler("Bolivia", 1);
            Assert.AreEqual(false, Repository.GetCountries().Contains(Country));
        }

        [TestMethod]
        public void AddCountry()
        {
            Repository.GetCountries().Clear();
            CountryHandler Country = new CountryHandler("Brasil", 1);
            Repository.AddCountry(Country);
            Assert.AreEqual(true, Repository.GetCountries().Contains(Country));
            using (var MyContext = new MyContext())
            {
                MyContext.Countries.Attach(Country);
            }
        }

        [TestMethod]
        public void AddTwoEqualsCountry()
        {
            CountryHandler Country = new CountryHandler("Brasil", 1);
            CountryHandler secondCountry = new CountryHandler("Brasil", 2);
            Repository.AddCountry(Country);
            Repository.AddCountry(secondCountry);
            Assert.AreEqual(false, Repository.GetCountries().Contains(secondCountry));
            using (var MyContext = new MyContext())
            {
                MyContext.Countries.Attach(Country);
            }
        }

        [TestMethod]
        public void ValidateRepeatNumberEmpty()
        {
            Assert.AreEqual(false, Repository.IsRepeatedNumber(""));
        }

        [TestMethod]
        public void ValidateRepeatNumberBadFormat()
        {
            Assert.AreEqual(false, Repository.IsRepeatedNumber("43823"));
        }

        [TestMethod]
        public void ValidateRepeatNumberLetters()
        {
            Assert.AreEqual(false, Repository.IsRepeatedNumber("test"));
        }

        [TestMethod]
        public void ValidateRepeatNumberNotRepeated()
        {
            Assert.AreEqual(false, Repository.IsRepeatedNumber("12398989898"));
        }

        [TestMethod]
        public void ValidateRepeatNumberRepeated()
        {
            Repository.AddAccount(new Account(0, "099366931", Repository.GetACountry("Uruguay")));
            Assert.AreEqual(true, Repository.IsRepeatedNumber("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountWithListEmpty()
        {
            Assert.AreEqual(null, Repository.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnAccountOutsideOfTheList()
        {
            Account Account = new Account(0, "098993924", Repository.GetACountry("Uruguay"));
            Repository.AddAccount(Account);
            Assert.AreEqual(null, Repository.GetAnAccount("099366931"));
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfAnAccount()
        {
            Account Account = new Account(0, "099366931", Repository.GetACountry("Uruguay"));
            Repository.AddAccount(Account);
            Assert.AreEqual(Account, Repository.GetAnAccount("099366931"));
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidateGrabAnAccountInTheListOfManyAccounts()
        {
            Repository.AddAccount(new Account(0, "092345678", Repository.GetACountry("Uruguay")));
            Repository.AddAccount(new Account(0, "095345688", Repository.GetACountry("Uruguay")));
            Repository.AddAccount(new Account(0, "092340478", Repository.GetACountry("Uruguay")));
            Account Account = new Account(0, "099366931", Repository.GetACountry("Uruguay"));
            Repository.AddAccount(Account);
            Assert.AreEqual(Account, Repository.GetAnAccount("099366931"));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWithListEmpty()
        {
            Assert.AreEqual(null, Repository.GetAnEnrollment("sbn", 4040));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentOutsideOfTheList()
        {
            Repository.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, Repository.GetAnEnrollment("sad", 4334));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameLetters()
        {
            Repository.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, Repository.GetAnEnrollment("sbn", 3922));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentWhitTheSameNumbers()
        {
            Repository.AddEnrollment(new Enrollment("sbn", 3924));
            Assert.AreEqual(null, Repository.GetAnEnrollment("sbv", 3924));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfEnrollment()
        {
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(Enrollment, Repository.GetAnEnrollment("sbn", 4849));
        }

        [TestMethod]
        public void ValidateGrabAnEnrollmentInTheListOfManyEnrollments()
        {
            Enrollment Enrollment = new Enrollment("fds", 1232);
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(Enrollment, Repository.GetAnEnrollment("fds", 1232));
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
            }
        }        

        [TestMethod]
        public void ValidateGrabAnCountryOutsideOfTheList()
        {
            Repository.GetCountries().Clear();
            Assert.AreEqual(null, Repository.GetACountry("Brasil"));
        }

        [TestMethod]
        public void ValidateGrabAnCountryInTheList()
        {
            Repository.GetCountries().Clear();
            CountryHandler brasil = new CountryHandler("Brasil", 5);
            Repository.AddCountry(brasil);
            Assert.AreEqual(brasil, Repository.GetACountry("Brasil"));
        }
        
        [TestMethod]
        public void ValidateGrabACountryInTheListOfManyCountries()
        {
            Repository.GetCountries().Clear();
            Repository.AddCountry(new CountryHandler("Argentina", 2));
            Repository.AddCountry(new CountryHandler("Chile", 3));
            Repository.AddCountry(new CountryHandler("Brasil", 2));
            CountryHandler venezuela = new CountryHandler("Venezuela", 3);
            Repository.AddCountry(venezuela);
            Assert.AreEqual(venezuela, Repository.GetACountry("Venezuela"));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentEmpty()
        {
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.IsRepeatedEnrollment("", 0));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentEmptyList()
        {
            Assert.AreEqual(false, Repository.IsRepeatedEnrollment("SBN", 4230));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNumbers()
        {
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.IsRepeatedEnrollment("SBM", 4849));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentLetters()
        {
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.IsRepeatedEnrollment("SBN", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentNotRepeated()
        {
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(false, Repository.IsRepeatedEnrollment("SBM", 4848));
        }

        [TestMethod]
        public void ValidateRepeatEnrollmentRepeated()
        {
            Repository.AddEnrollment(Enrollment);
            Assert.AreEqual(true, Repository.IsRepeatedEnrollment("SBN", 4849));
        }

        [TestMethod]
        public void ValidateRepeatCountryNotRepeated()
        {
            Repository.GetCountries().Clear();
            CountryHandler Country = new CountryHandler("Brasil", 1);
            Repository.AddCountry(Country);
            Assert.AreEqual(false, Repository.IsRepeatedCountry(""));
        }

        [TestMethod]
        public void ValidateRepeatCountryEmptyList()
        {
            Repository.GetCountries().Clear();
            Assert.AreEqual(false, Repository.IsRepeatedCountry("Chile"));
        }

        [TestMethod]
        public void ValidateRepeatCountry()
        {
            CountryHandler Country = new CountryHandler("Brasil", 2);
            Repository.AddCountry(Country);
            Assert.AreEqual(true, Repository.IsRepeatedCountry("Brasil"));
        }
        
        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchases()
        {
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbm" , 3030)));
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInMinutes()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 20, 0);
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeOfPurchase, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 4, 20, 13, 0, 0);
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(dateTimeOfQuery, Enrollment));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInHours()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeOfPurchase, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 4, 20, 14, 0, 0);
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(dateTimeOfQuery, Enrollment));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInDay()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeOfPurchase, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 4, 22, 13, 0, 0);
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(dateTimeOfQuery, Enrollment));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInMonth()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 11, 20, 13, 0, 0);
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeOfPurchase, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            DateTime dateTimeOfQuery = new DateTime(2019, 5, 20, 13, 0, 0);
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(dateTimeOfQuery, Enrollment));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatDateInYear()
        {
            DateTime dateTimeOfPurchase = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeOfPurchase, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            DateTime dateTimeOfQuery = new DateTime(2018, 4, 20, 13, 0, 0);
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(dateTimeOfQuery, Enrollment));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInLetters()
        {
            DateTime dateTimeOfPurchase = DateTime.Now;
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeOfPurchase, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbm", 4849)));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateNotPurchasesInThatEnrollmentInNumbers()
        {
            DateTime dateTimeOfPurchase = DateTime.Now;
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeOfPurchase, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            Assert.AreEqual(false, Repository.ArePurchaseOnThatDate(DateTime.Now, new Enrollment("sbn",4848)));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void ValidatePurchaseInTheDateOnePurchase()
        {
            Purchase Purchase = new Purchase(Enrollment, 30, DateTime.Now, Account);
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Repository.AddPurchase(Purchase);
            Assert.AreEqual(true, Repository.ArePurchaseOnThatDate(DateTime.Now, Enrollment));
            using (var MyContext = new MyContext())
            {
                MyContext.Purchases.Attach(Purchase);
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
            }
        }    

        [TestMethod]
        public void AddInvalidBalanceTest()
        {
            Repository.AddAccount(Account);
            Repository.AddBalanceToAccount(Account, -25);
            Assert.AreEqual(0, Account.Balance);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceInZeroTest()
        {
            Repository.AddAccount(Account);
            Repository.AddBalanceToAccount(Account, 25);
            Assert.AreEqual(25, Account.Balance);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void AddValidBalanceWithBalanceTest()
        {
            Account.Mobile = "099344951";
            Account.Balance = 0;
            Repository.AddAccount(Account);
            Repository.AddBalanceToAccount(Account, 22);
            Repository.AddBalanceToAccount(Account, 25);
            Assert.AreEqual(47, Account.Balance);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void SubstractInvalidBalanceTest()
        {
            Repository.AddAccount(Account);
            Repository.SubstractBalanceToAccount(Account, -25);
            Assert.AreEqual(0, Account.Balance);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void SubstractBalanceWithBalanceInZeroTest()
        {
            Account.Mobile = "099344951";
            Account.Balance = 0;
            Repository.AddAccount(Account);
            Repository.SubstractBalanceToAccount(Account, 25);
            Assert.AreEqual(0, Account.Balance);
        }

        [TestMethod]
        public void SubstractBalanceMoreThanTheAccountBalance()
        {
            Repository.AddAccount(Account);
            Repository.AddBalanceToAccount(Account, 20);
            Repository.SubstractBalanceToAccount(Account, 25);
            Assert.AreEqual(20, Account.Balance);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void SubstracTheSameBalanceInTheAccount()
        {
            Repository.AddAccount(Account);
            Repository.AddBalanceToAccount(Account, 22);
            Repository.SubstractBalanceToAccount(Account, 22);
            Assert.AreEqual(0, Account.Balance);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void SubstracBalanceInTheAccount()
        {
            Repository.AddAccount(Account);
            Repository.AddBalanceToAccount(Account, 22);
            Repository.SubstractBalanceToAccount(Account, 12);
            Assert.AreEqual(10, Account.Balance);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }

        [TestMethod]
        public void InsertPurchaseOfEnrollmentEmpty()
        {
            Repository.GetPurchases().Clear();
            Repository.AddEnrollment(Enrollment);
            List<Purchase> Purchases = Repository.InsertPurchaseOfEnrollmentToDataGridView(Enrollment);
            Assert.AreEqual(0, Purchases.ToArray().Length);
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
            }
        }

        [TestMethod]
        public void InsertPurchaseOfEnrollment()
        {
            Repository.GetPurchases().Clear();
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Purchase Purchase = new Purchase(Enrollment, 30, DateTime.Now, Account);
            Repository.AddPurchase(Purchase);
            List<Purchase> Purchases = Repository.InsertPurchaseOfEnrollmentToDataGridView(Enrollment);
            Assert.AreEqual(1, Purchases.ToArray().Length);
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
                MyContext.Purchases.Attach(Purchase);
            }
        }

        [TestMethod]
        public void InsertPurchaseOnThatDateEmpty()
        {
            Repository.GetPurchases().Clear();
            Repository.AddEnrollment(Enrollment);
            DateTime dateTimeInitial = new DateTime(2019, 4, 20, 12, 0, 0);
            DateTime dateTimeFinal = new DateTime(2019, 4, 20, 13, 00, DateTime.Now.Second);
            List<Purchase> Purchases = Repository.InsertPurchaseOnThatDate(dateTimeInitial, dateTimeFinal);
            Assert.AreEqual(0, Purchases.ToArray().Length);
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
            }
        }

        [TestMethod]
        public void InsertPurchaseOnThatDate()
        {
            Repository.GetPurchases().Clear();
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            DateTime dateTimeInitial = new DateTime(2019, 4, 20, 12, 0, 0);
            DateTime dateTimeFinal = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeFinal, Account);
            Repository.AddPurchase(Purchase);
            List<Purchase> Purchases = Repository.InsertPurchaseOnThatDate(dateTimeInitial, dateTimeFinal);
            Assert.AreEqual(1, Purchases.ToArray().Length);
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
                MyContext.Purchases.Attach(Purchase);
            }
        }

        [TestMethod]
        public void EliminatePurchaseFromAnotherCountryEmpty()
        {
            Repository.GetPurchases().Clear();
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            Purchase Purchase = new Purchase(Enrollment, 30, DateTime.Now, Account);
            Repository.AddPurchase(Purchase);
            List<Purchase> Purchases = Repository.EliminatePurchasesFromAnoterCountry(Repository.GetPurchases(), Repository.GetACountry("Argentina"));
            Assert.AreEqual(0, Purchases.ToArray().Length);
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
                MyContext.Purchases.Attach(Purchase);
            }
        }

        [TestMethod]
        public void EliminatePurchaseFromAnotherCountry()
        {
            Repository.GetPurchases().Clear();
            Repository.AddAccount(Account);
            Repository.AddEnrollment(Enrollment);
            DateTime dateTimeInitial = new DateTime(2019, 4, 20, 12, 0, 0);
            DateTime dateTimeFinal = new DateTime(2019, 4, 20, 13, 0, 0);
            Purchase Purchase = new Purchase(Enrollment, 30, dateTimeFinal, Account);
            Repository.AddPurchase(Purchase);
            List<Purchase> Purchases = Repository.EliminatePurchasesFromAnoterCountry(Repository.GetPurchases(), Repository.GetACountry("Uruguay"));
            Assert.AreEqual(1, Purchases.ToArray().Length);
            using (var MyContext = new MyContext())
            {
                MyContext.Enrollments.Attach(Enrollment);
                MyContext.Accounts.Attach(Account);
                MyContext.Purchases.Attach(Purchase);
            }
        }

        [TestMethod]
        public void UpdateCostOfMinutes()
        {
            Repository.GetCountries().Clear();
            CountryHandler Country = new CountryHandler("Uruguay", 1);
            Country.SetValidators(new ValidatorOfPhoneInUruguay(), new ValidatorOfMessageInUruguay());
            Repository.AddCountry(Country);
            Country.CostForMinutes = 2;
            Repository.UpdateCostForMinutes(Country);
            Assert.AreEqual(2, Country.CostForMinutes);
            using (var MyContext = new MyContext())
            {
                MyContext.Countries.Attach(Country);
            }
        }

        [TestMethod]
        public void CallContextDataBaseEmpty()
        {
            Repository.AddAccount(Account);
            int LengthAccountContextEmpty;
            using (var MyContext = new MyContextEmpty())
            {
                LengthAccountContextEmpty = MyContext.Accounts.ToArray().Length;
            }
            Assert.AreEqual(0, LengthAccountContextEmpty);
            using (var MyContext = new MyContext())
            {
                MyContext.Accounts.Attach(Account);
            }
        }
    }
}

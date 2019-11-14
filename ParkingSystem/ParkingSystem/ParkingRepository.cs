using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParkingSystem
{
    public class ParkingRepository:IParkingRepository
    {

        private List<Account> accountList = new List<Account>();
        private List<Enrollment> enrollmentList = new List<Enrollment>();
        private List<Purchase> purchaseList = new List<Purchase>();
        private List<CountryHandler> countryList = new List<CountryHandler>();

        public ParkingRepository()
        {           
            using (var myContext = new MyContext())
            {
                accountList = myContext.ReturnListOfAccounts();               
                enrollmentList = myContext.ReturnListOfEnrollments();
                purchaseList = myContext.ReturnListOfPurchases();
                countryList = myContext.ReturnListOfCountries();
                myContext.SaveChanges();
            }
        }

        public void AddAccount(Account newAccount)
        {
            CountryHandler countryHandler = newAccount.Country;
            string text = newAccount.Mobile;
            if (newAccount.Balance >= 0 && countryHandler.ValidateFormatNumberByCountry(ref text) && !IsRepeatedNumber(text) &&
                countryHandler.ValidateIsNumericByCountry(newAccount.Mobile))
            {
               accountList.Add(newAccount);
               using (var myContext = new MyContext())
                    myContext.AddAccount(newAccount); 
            }
        }

        public List<Account> GetAccounts()
        {
            return accountList;
        }

        public void AddBalanceToAccount(Account account, int balanceToAdd)
        {
            if (balanceToAdd > 0)
            {
                account.Balance += balanceToAdd;
                using (var myContext = new MyContext())
                    myContext.AddBalanceToAccount(account, balanceToAdd);
            }
        }

        public void SubstractBalanceToAccount(Account account, int balanceToSubstract)
        {
            if (balanceToSubstract > 0 && account.Balance >= balanceToSubstract)
            {
                account.Balance -= balanceToSubstract;
                using (var myContext = new MyContext())
                    myContext.SubstractBalanceToAccount(account, balanceToSubstract);
            }
        }        

        public void AddEnrollment(Enrollment newEnrollment)
        {
            ValidatorOfEnrollment validator = new ValidatorOfEnrollment();
            if (validator.ValidateFormatOfEnrollment(newEnrollment.LettersOfEnrollment + newEnrollment.NumbersOfEnrollment)
                && !IsRepeatedEnrollment(newEnrollment.LettersOfEnrollment, newEnrollment.NumbersOfEnrollment))
            {
                enrollmentList.Add(newEnrollment);
                using (var myContext = new MyContext())
                    myContext.AddEnrollment(newEnrollment);
            }
        }

        public List<Enrollment> GetEnrollments()
        {
            return enrollmentList;
        }

        public void AddPurchase(Purchase newPurchase)
        {
            purchaseList.Add(newPurchase);
            using (var myContext = new MyContext())
                myContext.AddPurchase(newPurchase);
        }

        public List<Purchase> GetPurchases()
        {
            return purchaseList;
        }

        public void AddCountry(CountryHandler newCountry)
        {
            if (!IsRepeatedCountry(newCountry.NameOfCountry))
            {
                countryList.Add(newCountry);
                using (var myContext = new MyContext())
                    myContext.AddCountry(newCountry);
            }
        }

        public List<CountryHandler> GetCountries()
        {
            return countryList;
        }

        public bool IsRepeatedNumber(string text)
        {
            return this.GetAccounts().Any(a => text.Equals(a.Mobile));
        }

        public Account GetAnAccount(string mobileToCompare)
        {
            for (int i = 0; i < this.GetAccounts().ToArray().Length; i++)
                if (mobileToCompare.Equals(this.GetAccounts().ToArray().ElementAt(i).Mobile))
                    return this.GetAccounts().ToArray().ElementAt(i);
            return null;
        }

        public Enrollment GetAnEnrollment(string lettersToCompare, int numbersToCompare)
        {
            for (int i = 0; i < this.GetEnrollments().ToArray().Length; i++)
                if (lettersToCompare.ToUpper().Equals(this.GetEnrollments().ToArray().ElementAt(i).LettersOfEnrollment.ToUpper())
                    && numbersToCompare == this.GetEnrollments().ToArray().ElementAt(i).NumbersOfEnrollment)
                    return this.GetEnrollments().ToArray().ElementAt(i);
            return null;
        }

        public CountryHandler GetACountry(string nameOfCountry)
        {
            for (int i = 0; i < this.GetCountries().ToArray().Length; i++)
                if (nameOfCountry.ToUpper().Equals(this.GetCountries().ToArray().ElementAt(i).NameOfCountry.ToUpper()))
                    return this.GetCountries().ToArray().ElementAt(i);
            return null;
        }

        public bool IsRepeatedEnrollment(string letters, int numbers)
        {
            return this.GetEnrollments().Any(e => letters.ToUpper().Equals(e.LettersOfEnrollment.ToUpper())
                && numbers == e.NumbersOfEnrollment);
        }

        public bool IsRepeatedCountry(string name)
        {
            return this.GetCountries().Any(c => name.ToUpper().Equals(c.NameOfCountry.ToUpper()));
        }

        public bool ArePurchaseOnThatDate(DateTime dateToCompare, Enrollment enrollmentToCompare)
        {
            ValidatorOfDate validator = new ValidatorOfDate();
            for(int i = 0; i<this.GetPurchases().ToArray().Length; i++)
            {
                Enrollment enrollmentOfPurchase = this.GetPurchases().ToArray().ElementAt(i).EnrollmentOfPurchase;
                if (validator.CheckDateWithTimeOfPurchase(dateToCompare, this.GetPurchases().ElementAt(i)) &&
                    enrollmentOfPurchase.EnrollmentId == enrollmentToCompare.EnrollmentId)
                    return true;
            }
            return false;
        }

        public List<Purchase> InsertPurchaseOfEnrollmentToDataGridView(Enrollment enrollmentOfPurchase)
        {
            List<Purchase> purchaseOfThisEnrollment = new List<Purchase>();
            purchaseOfThisEnrollment = GetPurchases().Where(p => p.EnrollmentOfPurchase.EnrollmentId.Equals(enrollmentOfPurchase.EnrollmentId)).ToList();
            return purchaseOfThisEnrollment;
        }

        public List<Purchase> InsertPurchaseOnThatDate(DateTime initialDateOfPurchase, DateTime finalDateOfPurchase)
        {
            List<Purchase> purchaseOfThisEnrollment = new List<Purchase>();
            purchaseOfThisEnrollment = GetPurchases().Where(p => p.DateOfPurchase >= initialDateOfPurchase
                && p.DateOfPurchase <= finalDateOfPurchase).ToList();
            return purchaseOfThisEnrollment;
        }

        public List<Purchase> EliminatePurchasesFromAnoterCountry(List<Purchase> purchasesOnThatDate, CountryHandler country)
        {
           return purchasesOnThatDate.Where(p => p.AccountOfPurchase.Country.CountryHandlerId == country.CountryHandlerId).ToList();
        }

        public void UpdateCostForMinutes(CountryHandler country)
        {
            using (var myContext = new MyContext())
                myContext.UpdateCostForMinutes(country);
        }
    }
}


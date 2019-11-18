using DataBaseConnection;
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

        private List<Account> AccountList = new List<Account>();
        private List<Enrollment> EnrollmentList = new List<Enrollment>();
        private List<Purchase> PurchaseList = new List<Purchase>();
        private List<CountryHandler> CountryList = new List<CountryHandler>();

        public ParkingRepository()
        {
            using (var MyContext = new MyContext())
            {
                AccountList = MyContext.ReturnListOfAccounts();               
                EnrollmentList = MyContext.ReturnListOfEnrollments();
                PurchaseList = MyContext.ReturnListOfPurchases();
                CountryList = MyContext.ReturnListOfCountries();
                MyContext.SaveChanges();
            }
        }

        public void AddAccount(Account NewAccount)
        {
            CountryHandler CountryHandler = NewAccount.Country;
            string Text = NewAccount.Mobile;
            if (NewAccount.Balance >= 0 && CountryHandler.ValidateFormatNumberByCountry(ref Text) && !IsRepeatedNumber(Text) &&
                CountryHandler.ValidateIsNumericByCountry(NewAccount.Mobile))
            {
               AccountList.Add(NewAccount);
               using (var MyContext = new MyContext())
                    MyContext.AddAccount(NewAccount); 
            }
        }

        public List<Account> GetAccounts()
        {
            return AccountList;
        }

        public void AddBalanceToAccount(Account Account, int BalanceToAdd)
        {
            if (BalanceToAdd > 0)
            {
                Account.Balance += BalanceToAdd;
                using (var MyContext = new MyContext())
                    MyContext.AddBalanceToAccount(Account, BalanceToAdd);
            }
        }

        public void SubstractBalanceToAccount(Account Account, int BalanceToSubstract)
        {
            if (BalanceToSubstract > 0 && Account.Balance >= BalanceToSubstract)
            {
                Account.Balance -= BalanceToSubstract;
                using (var MyContext = new MyContext())
                    MyContext.SubstractBalanceToAccount(Account, BalanceToSubstract);
            }
        }        

        public void AddEnrollment(Enrollment NewEnrollment)
        {
            ValidatorOfEnrollment validator = new ValidatorOfEnrollment();
            if (validator.ValidateFormatOfEnrollment(NewEnrollment.LettersOfEnrollment + NewEnrollment.NumbersOfEnrollment)
                && !IsRepeatedEnrollment(NewEnrollment.LettersOfEnrollment, NewEnrollment.NumbersOfEnrollment))
            {
                EnrollmentList.Add(NewEnrollment);
                using (var MyContext = new MyContext())
                    MyContext.AddEnrollment(NewEnrollment);
            }
        }

        public List<Enrollment> GetEnrollments()
        {
            return EnrollmentList;
        }

        public void AddPurchase(Purchase NewPurchase)
        {
            PurchaseList.Add(NewPurchase);
            using (var MyContext = new MyContext())
                MyContext.AddPurchase(NewPurchase);
        }

        public List<Purchase> GetPurchases()
        {
            return PurchaseList;
        }

        public void AddCountry(CountryHandler NewCountry)
        {
            if (!IsRepeatedCountry(NewCountry.NameOfCountry))
            {
                CountryList.Add(NewCountry);
                using (var MyContext = new MyContext())
                    MyContext.AddCountry(NewCountry);
            }
        }

        public List<CountryHandler> GetCountries()
        {
            return CountryList;
        }

        public bool IsRepeatedNumber(string Text)
        {
            return this.GetAccounts().Any(a => Text.Equals(a.Mobile));
        }

        public Account GetAnAccount(string MobileToCompare)
        {
            for (int i = 0; i < this.GetAccounts().ToArray().Length; i++)
                if (MobileToCompare.Equals(this.GetAccounts().ToArray().ElementAt(i).Mobile))
                    return this.GetAccounts().ToArray().ElementAt(i);
            return null;
        }

        public Enrollment GetAnEnrollment(string LettersToCompare, int NumbersToCompare)
        {
            for (int i = 0; i < this.GetEnrollments().ToArray().Length; i++)
                if (LettersToCompare.ToUpper().Equals(this.GetEnrollments().ToArray().ElementAt(i).LettersOfEnrollment.ToUpper())
                    && NumbersToCompare == this.GetEnrollments().ToArray().ElementAt(i).NumbersOfEnrollment)
                    return this.GetEnrollments().ToArray().ElementAt(i);
            return null;
        }

        public CountryHandler GetACountry(string NameOfCountry)
        {
            for (int i = 0; i < this.GetCountries().ToArray().Length; i++)
                if (NameOfCountry.ToUpper().Equals(this.GetCountries().ToArray().ElementAt(i).NameOfCountry.ToUpper()))
                    return this.GetCountries().ToArray().ElementAt(i);
            return null;
        }

        public bool IsRepeatedEnrollment(string Letters, int Numbers)
        {
            return this.GetEnrollments().Any(e => Letters.ToUpper().Equals(e.LettersOfEnrollment.ToUpper())
                && Numbers == e.NumbersOfEnrollment);
        }

        public bool IsRepeatedCountry(string Name)
        {
            return this.GetCountries().Any(c => Name.ToUpper().Equals(c.NameOfCountry.ToUpper()));
        }

        public bool ArePurchaseOnThatDate(DateTime DateToCompare, Enrollment EnrollmentToCompare)
        {
            ValidatorOfDate validator = new ValidatorOfDate();
            for(int i = 0; i<this.GetPurchases().ToArray().Length; i++)
            {
                Enrollment EnrollmentOfPurchase = this.GetPurchases().ToArray().ElementAt(i).EnrollmentOfPurchase;
                if (validator.CheckDateWithTimeOfPurchase(DateToCompare, this.GetPurchases().ElementAt(i)) &&
                    EnrollmentOfPurchase.EnrollmentId == EnrollmentToCompare.EnrollmentId)
                    return true;
            }
            return false;
        }

        public List<Purchase> InsertPurchaseOfEnrollmentToDataGridView(Enrollment EnrollmentOfPurchase)
        {
            List<Purchase> PurchaseOfThisEnrollment = new List<Purchase>();
            PurchaseOfThisEnrollment = GetPurchases().Where(p => p.EnrollmentOfPurchase.EnrollmentId.Equals(EnrollmentOfPurchase.EnrollmentId)).ToList();
            return PurchaseOfThisEnrollment;
        }

        public List<Purchase> InsertPurchaseOnThatDate(DateTime InitialDateOfPurchase, DateTime FinalDateOfPurchase)
        {
            List<Purchase> PurchaseOfThisEnrollment = new List<Purchase>();
            PurchaseOfThisEnrollment = GetPurchases().Where(p => p.DateOfPurchase >= InitialDateOfPurchase
                && p.DateOfPurchase <= FinalDateOfPurchase).ToList();
            return PurchaseOfThisEnrollment;
        }

        public List<Purchase> EliminatePurchasesFromAnoterCountry(List<Purchase> PurchasesOnThatDate, CountryHandler Country)
        {
           return PurchasesOnThatDate.Where(p => p.AccountOfPurchase.Country.CountryHandlerId == Country.CountryHandlerId).ToList();
        }

        public void UpdateCostForMinutes(CountryHandler Country)
        {
            using (var MyContext = new MyContext())
                MyContext.UpdateCostForMinutes(Country);
        }
    }
}


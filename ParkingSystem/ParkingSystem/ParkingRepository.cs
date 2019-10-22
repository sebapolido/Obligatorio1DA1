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
        private static List<Account> accountsList = new List<Account>();
        private static List<Enrollment> enrollmentsList = new List<Enrollment>();
        private static List<Purchase> purchaseList = new List<Purchase>();
        private static List<Country> countryList = new List<Country>();

        public void AddAccount(Account newAccount, Country country)
        {
            CountryHandler countryHandler = new CountryHandler(country);
            string text = newAccount.mobile;
            if (newAccount.balance >= 0 && countryHandler.ValidateFormatNumberByCountry(ref text) && !IsRepeatedNumber(text) &&
                 countryHandler.ValidateIsNumericByCountry(newAccount.mobile))
                accountsList.Add(newAccount);
        }

        public List<Account> GetAccounts()
        {
            return accountsList;
        }

        public void AddEnrollment(Enrollment newEnrollment)
        {
            ValidatorOfEnrollment validator = new ValidatorOfEnrollment();
            if(validator.ValidateFormatOfEnrollment(newEnrollment.lettersOfEnrollment + newEnrollment.numbersOfEnrollment)
                && !IsRepeatedEnrollment(newEnrollment.lettersOfEnrollment, newEnrollment.numbersOfEnrollment))
                enrollmentsList.Add(newEnrollment);
        }

        public List<Enrollment> GetEnrollments()
        {
            return enrollmentsList;
        }

        public void AddPurchase(Purchase newPurchase)
        {
            purchaseList.Add(newPurchase);
        }

        public List<Purchase> GetPurchases()
        {
            return purchaseList;
        }

        public void AddCountry(Country newCountry)
        {
            if(!IsRepeatedCountry(newCountry.nameOfCountry))
                countryList.Add(newCountry);
        }

        public List<Country> GetCountries()
        {
            return countryList;
        }

        public bool IsRepeatedNumber(string text)
        {
            for (int i = 0; i < this.GetAccounts().ToArray().Length; i++)
                if (text.Equals(this.GetAccounts().ToArray().ElementAt(i).mobile))
                    return true;
            return false;
        }

        public Account GetAnAccount(string mobileToCompare)
        {
            for (int i = 0; i < this.GetAccounts().ToArray().Length; i++)
                if (mobileToCompare.Equals(this.GetAccounts().ToArray().ElementAt(i).mobile))
                    return this.GetAccounts().ToArray().ElementAt(i);
            return null;
        }

        public Enrollment GetAnEnrollment(string lettersToCompare, int numbersToCompare)
        {
            for (int i = 0; i < this.GetEnrollments().ToArray().Length; i++)
                if (lettersToCompare.ToUpper().Equals(this.GetEnrollments().ToArray().ElementAt(i).lettersOfEnrollment.ToUpper())
                    && numbersToCompare == this.GetEnrollments().ToArray().ElementAt(i).numbersOfEnrollment)
                    return this.GetEnrollments().ToArray().ElementAt(i);
            return null;
        }

        public Country GetACountry(string nameOfCountry)
        {
            for (int i = 0; i < this.GetCountries().ToArray().Length; i++)
                if (nameOfCountry.ToUpper().Equals(this.GetCountries().ToArray().ElementAt(i).nameOfCountry.ToUpper()))
                    return this.GetCountries().ToArray().ElementAt(i);
            return null;
        }

        public bool IsRepeatedEnrollment(string letters, int numbers)
        {
            for (int i = 0; i < this.GetEnrollments().ToArray().Length; i++)
            {
                string lettersOfEnrollment = this.GetEnrollments().ToArray().ElementAt(i).lettersOfEnrollment.ToUpper();
                int numbersOfEnrollment = this.GetEnrollments().ToArray().ElementAt(i).numbersOfEnrollment;
                if (letters.ToUpper().Equals(lettersOfEnrollment) && numbers == numbersOfEnrollment)
                    return true;
            }
            return false;
        }

        public bool IsRepeatedCountry(string name)
        {
            for (int i = 0; i < this.GetCountries().ToArray().Length; i++)
            {
                string nameOfCountry = this.GetCountries().ToArray().ElementAt(i).nameOfCountry.ToUpper();
                if (name.ToUpper().Equals(nameOfCountry))
                    return true;
            }
            return false;
        }

        public bool ArePurchaseOnThatDate(DateTime dateToCompare, Enrollment enrollmentToCompare)
        {
            ValidatorOfDate validator = new ValidatorOfDate();
            for(int i = 0; i<this.GetPurchases().ToArray().Length; i++)
            {
                Enrollment enrollmentOfPurchase = this.GetPurchases().ToArray().ElementAt(i).enrollmentOfPurchase;
                if (validator.CheckDateWithTimeOfPurchase(dateToCompare, this.GetPurchases().ToArray().ElementAt(i)) &&
                    enrollmentOfPurchase.Equals(enrollmentToCompare))
                    return true;
            }
            return false;
        }
    }
}


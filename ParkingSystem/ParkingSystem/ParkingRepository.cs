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
        private static List<CountryHandler> countryList = new List<CountryHandler>();

        public ParkingRepository()
        {
            CountryHandler Argentina = new CountryHandler("Argentina", 1);
            Argentina.SetValidators(new ValidatorOfPhoneInArgentina(), new ValidatorOfMessageInArgentina());
            CountryHandler Uruguay = new CountryHandler("Uruguay", 1);
            Uruguay.SetValidators(new ValidatorOfPhoneInUruguay(), new ValidatorOfMessageInUruguay());
            this.AddCountry(Argentina);
            this.AddCountry(Uruguay);
        }

        public void AddAccount(Account newAccount)
        {
            CountryHandler countryHandler = newAccount.Country;
            string text = newAccount.Mobile;
            if (newAccount.Balance >= 0 && countryHandler.ValidateFormatNumberByCountry(ref text) && !IsRepeatedNumber(text) &&
                 countryHandler.ValidateIsNumericByCountry(newAccount.Mobile))
            {
                accountsList.Add(newAccount);
                /*using (var myContext = new MyContext())
                {
                    myContext.Accounts.Add(newAccount);
                    myContext.SaveChanges();
                }*/
            }
        }

        public List<Account> GetAccounts()
        {
            return accountsList;
        }

        public void AddEnrollment(Enrollment newEnrollment)
        {
            ValidatorOfEnrollment validator = new ValidatorOfEnrollment();
            if(validator.ValidateFormatOfEnrollment(newEnrollment.LettersOfEnrollment + newEnrollment.NumbersOfEnrollment)
                && !IsRepeatedEnrollment(newEnrollment.LettersOfEnrollment, newEnrollment.NumbersOfEnrollment))
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

        public void AddCountry(CountryHandler newCountry)
        {
            if(!IsRepeatedCountry(newCountry.NameOfCountry))
                countryList.Add(newCountry);
        }

        public List<CountryHandler> GetCountries()
        {
            return countryList;
        }

        public bool IsRepeatedNumber(string text)
        {
            for (int i = 0; i < this.GetAccounts().ToArray().Length; i++)
                if (text.Equals(this.GetAccounts().ToArray().ElementAt(i).Mobile))
                    return true;
            return false;
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
            for (int i = 0; i < this.GetEnrollments().ToArray().Length; i++)
            {
                string lettersOfEnrollment = this.GetEnrollments().ToArray().ElementAt(i).LettersOfEnrollment.ToUpper();
                int numbersOfEnrollment = this.GetEnrollments().ToArray().ElementAt(i).NumbersOfEnrollment;
                if (letters.ToUpper().Equals(lettersOfEnrollment) && numbers == numbersOfEnrollment)
                    return true;
            }
            return false;
        }

        public bool IsRepeatedCountry(string name)
        {
            for (int i = 0; i < this.GetCountries().ToArray().Length; i++)
            {
                string nameOfCountry = this.GetCountries().ToArray().ElementAt(i).NameOfCountry.ToUpper();
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
                Enrollment enrollmentOfPurchase = this.GetPurchases().ToArray().ElementAt(i).EnrollmentOfPurchase;
                if (validator.CheckDateWithTimeOfPurchase(dateToCompare, this.GetPurchases().ToArray().ElementAt(i)) &&
                    enrollmentOfPurchase.Equals(enrollmentToCompare))
                    return true;
            }
            return false;
        }
    }
}


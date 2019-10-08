using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParkingSystem
{
    public class SystemController:ISystemController
    {
        private static List<IAccount> accountsList = new List<IAccount>();
        private static List<IEnrollment> enrollmentsList = new List<IEnrollment>();
        private static List<IPurchase> purchaseList = new List<IPurchase>();

        public void AddAccount(IAccount account)
        {
            ValidatorOfPhone validator = new ValidatorOfPhone();
            string text = account.mobile;
            if (account.balance >= 0 &&  validator.ValidateFormatNumber(ref text) &&
                 validator.ValidateIsNumeric(account.mobile) && !IsRepeatedNumber(account.mobile))
                accountsList.Add(account);
        }

        public List<IAccount> GetAccounts()
        {
            return accountsList;
        }

        public void AddEnrollment(IEnrollment enrollment)
        {
            ValidatorOfEnrollment validator = new ValidatorOfEnrollment();
            if(validator.ValidateFormatOfEnrollment(enrollment.lettersOfEnrollment + enrollment.numbersOfEnrollment)
                && !IsRepeatedEnrollment(enrollment.lettersOfEnrollment, enrollment.numbersOfEnrollment))
                enrollmentsList.Add(enrollment);
        }

        public List<IEnrollment> GetEnrollments()
        {
            return enrollmentsList;
        }


        public void AddPurchase(IPurchase purchase)
        {
            purchaseList.Add(purchase);
        }

        public List<IPurchase> GetPurchases()
        {
            return purchaseList;
        }   
        
        public bool IsRepeatedNumber(string text)
        {
            bool isEquals = false;
            for (int i = 0; i < this.GetAccounts().ToArray().Length && !isEquals; i++)
            {
                if (text.Equals(this.GetAccounts().ToArray().ElementAt(i).mobile))
                {
                    isEquals = true;
                    return true;
                }
            }
            if (!isEquals)
                return false;
            else
                return true;
        }

        public IAccount GetAnAccount(string text)
        {
            for (int i = 0; i < this.GetAccounts().ToArray().Length; i++)
            {
                if (text.Equals(this.GetAccounts().ToArray().ElementAt(i).mobile))
                {
                    return this.GetAccounts().ToArray().ElementAt(i);
                }
            }
            return null;
        }

        public IEnrollment GetAnEnrollment(string letters, int numbers)
        {
            bool isEquals = false;
            for (int i = 0; i < this.GetEnrollments().ToArray().Length && !isEquals; i++)
            {
                if (letters.ToUpper().Equals(this.GetEnrollments().ToArray().ElementAt(i).lettersOfEnrollment.ToUpper())
                    && numbers == this.GetEnrollments().ToArray().ElementAt(i).numbersOfEnrollment)
                {
                    isEquals = true;
                    return this.GetEnrollments().ToArray().ElementAt(i);
                }
            }
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

       

        public bool ArePurchaseOnThatDate(DateTime date, IEnrollment enrollment)
        {
            ValidatorOfDate validator = new ValidatorOfDate();
            for(int i = 0; i<this.GetPurchases().ToArray().Length; i++)
            {
                IEnrollment enrollmentOfPurchase = this.GetPurchases().ToArray().ElementAt(i).enrollmentOfPurchase;
                if (validator.CheckDateWithTimeOfPurchase(date, this.GetPurchases().ToArray().ElementAt(i)) &&
                    enrollmentOfPurchase.Equals(enrollment))
                    return true;
            }
            return false;
        }
    }
}


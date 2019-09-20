using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ParkingSystem
{
    [Serializable]
    public class SystemController
    {
        private static List<Account> accountsList = new List<Account>();
        private static List<Enrollment> enrollmentsList = new List<Enrollment>();
        private static List<Purchase> purchaseList = new List<Purchase>();


        public void AddAccount(Account account)
        {
            if (account.balance >= 0 && ValidateLengthNumber(account.mobile) &&
                ValidateIsNumeric(account.mobile) && !ValidateRepeatNumber(account.mobile))
                accountsList.Add(account);
        }

        public List<Account> GetAccounts()
        {
            return accountsList;
        }

        public void AddEnrollment(Enrollment enrollment)
        {
            if(ValidateFormatOfEnrollment(enrollment.lettersOfEnrollment + enrollment.numbersOfEnrollment)
                && !ValidateRepeatEnrollment(enrollment.lettersOfEnrollment, enrollment.numbersOfEnrollment))
                enrollmentsList.Add(enrollment);
        }

        public List<Enrollment> GetEnrollments()
        {
            return enrollmentsList;
        }


        public void AddPurchase(Purchase purchase)
        {
            purchaseList.Add(purchase);
        }

        public List<Purchase> GetPurchase()
        {
            return purchaseList;
        }   

        public bool ValidateLengthNumber(string text)
        {
            if (text.Length == 9 && text[0].Equals('0') && text[1].Equals('9'))
                return true;
            else if (text.Length == 8 && text[0].Equals('9'))
            {
                text = text.Insert(0, "0");
                return true;
            }
            else
                return false;
        }

        public bool ValidateIsNumeric(string text)
        {
            if (Int32.TryParse(text, out int isNumeric))
                return true;
            else
                return false;
        }

        public bool ValidateRepeatNumber(string text)
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

        public Account getAnAccount(string text)
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

        public bool ValidateFormatOfEnrollment(string text)
        {
            if (text.Length > 7)
            {
                string[] line = text.Split(' ');
                if (line[0].Length == 3 && line.Length > 0 && line[1].Length == 4 || line[0].Length == 7 && line.Length == 0)
                {
                    if (line[1].Length == 4)
                    {
                        text = text.Replace(" ", "");
                    }
                }
                else
                {

                }
            }
            return true;
                /*if ((text.ElementAt(3).Equals(' ') && text.ElementAt(8).Equals(' ')) ||
                    (!text.Substring(0, 6).Contains(' ') && text.ElementAt(7).Equals(' ')))
                {
                    text = text.Replace(" ", "");
                    string lettersOfEnrollment = text.Substring(0, 3).ToUpper();
                    string numbersOfEnrollment = text.Substring(3, 4);
                    
                    if (!Int32.TryParse(lettersOfEnrollment, out int balance))
                    {
                        if (Int32.TryParse(numbersOfEnrollment, out balance))
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;*/
        }

        public bool ValidateRepeatEnrollment(string letters, int numbers)
        {
            bool isEquals = false;
            for (int i = 0; i < this.GetEnrollments().ToArray().Length && !isEquals; i++)
            {
                if (letters.ToUpper().Equals(this.GetEnrollments().ToArray().ElementAt(i).lettersOfEnrollment.ToUpper())
                    && numbers == this.GetEnrollments().ToArray().ElementAt(i).numbersOfEnrollment)
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

        public int ValidateMinutes(string restOfMessage, string hour, string minutes, string time)
        {
            bool final = false;
            int resultReturn = 0;
            for (int i = 0; i < restOfMessage.Length && !final; i++)
            {
                if (restOfMessage[i].Equals(':'))
                {
                    if (restOfMessage.Length == i + 3)
                    {
                        hour = "" + restOfMessage[i - 2] + restOfMessage[i - 1];
                        minutes = "" + restOfMessage[i + 1] + restOfMessage[i + 2];
                        final = true;
                    }
                    else
                    {
                        resultReturn++;
                    }
                }
                time = time + restOfMessage[i];
            }
            if (final)
            {
                time = time.Substring(0, time.Length - 3);
            }
            return resultReturn;
        }
    }
}

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
            string text = account.mobile;
            if (account.balance >= 0 && ValidateFormatNumber(ref text) &&
                ValidateIsNumeric(account.mobile) && !ValidateRepeatNumber(account.mobile))
                accountsList.Add(account);
        }

        public List<IAccount> GetAccounts()
        {
            return accountsList;
        }

        public void AddEnrollment(IEnrollment enrollment)
        {
            if(ValidateFormatOfEnrollment(enrollment.lettersOfEnrollment + enrollment.numbersOfEnrollment)
                && !ValidateRepeatEnrollment(enrollment.lettersOfEnrollment, enrollment.numbersOfEnrollment))
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

        public bool ValidateFormatNumber(ref string textOfPhone)
        {
            if (IsFormatOfLengthOfNine(textOfPhone))
                return true;
            else if (IsFormatOfLengthOfEigth(textOfPhone))
            {
                textOfPhone = textOfPhone.Insert(0, "0");
                return true;
            }
            else
                return false;
        }

        public bool IsFormatOfLengthOfNine(string text)
        {
            return text.Length == 9 && text[0].Equals('0') && text[1].Equals('9');
        }

        public bool IsFormatOfLengthOfEigth(string text)
        {
            return text.Length == 8 && text[0].Equals('9');
        }

        public bool ValidateIsNumeric(string text)
        {
            return (Int32.TryParse(text, out int isNumeric));
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
        public bool ValidateFormatOfEnrollment(string text)
        {
            if (text.Length > 6)
            {
                string[] line = text.Split(' ');
                if (line[0].Length == 3 && line.Length > 1 && line[1].Length == 4 || line[0].Length == 7 && line.Length == 1)
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
                return false;
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

        public bool ValidateMinutes(string restOfMessage)
        {
            string[] line = restOfMessage.Split(' ');
            if (line.Length >= 2 && line.Length <= 3)
            {
                string time = line[1];
                string hour = "";
                string minutes = "";
                if (line.Length == 3)
                {
                    string[] SecondLine = line[2].Split(':');
                    if (SecondLine.Length == 2)
                    {
                        hour = SecondLine[0];
                        minutes = SecondLine[1];
                        if (Int32.TryParse(hour, out int balance) &&
                            Int32.TryParse(minutes, out balance) &&
                            Int32.TryParse(time, out balance))
                            return true;
                        else
                            return false;
                    }
                    else if (Int32.TryParse(time, out int balance))
                        return true;
                    else
                        return false;
                }
                else
                    return true;
            }
            else
                return false;
        }

        public bool ValidateValidHour(DateTime date)
        {
            if (date.Hour >= 10 && date.Hour < 18 && date.Minute >= 0 && date.Minute <60)
                return true;
            else
                return false;
        }

        public bool ValideTimeOfPurchase(int timeOfPurchase)
        {
            if (timeOfPurchase > 0)
            {
                if (timeOfPurchase % 30 == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool IsConvertStringToNumber(string time)
        {
            if (Int32.TryParse(time, out int isTimeNumeric))
                return true;
            else
                return false;
        }

        public int CalculateFinalTimeOfPurchase(int timeOfPurchase, int hourOfPurchase, int minsOfPurchase)
        {
            if (hourOfPurchase >= 10 && hourOfPurchase < 18 && minsOfPurchase >= 0 && minsOfPurchase < 60){
                int finalTimeOfPurchase = 0;
                finalTimeOfPurchase = 60 - minsOfPurchase;
                for(int i = hourOfPurchase; i < 17; i++)
                    finalTimeOfPurchase += 60;
                if (timeOfPurchase > finalTimeOfPurchase)
                    return finalTimeOfPurchase;
                else
                    return timeOfPurchase;
            }
            else
                return 0;
        }

        public bool ArePurchaseOnThatDate(DateTime date, IEnrollment enrollment)
        {
            for(int i = 0; i<this.GetPurchases().ToArray().Length; i++)
            {
                IEnrollment enrollmentOfPurchase = this.GetPurchases().ToArray().ElementAt(i).enrollmentOfPurchase;
                if (CheckDateWithTimeOfPurchase(date, this.GetPurchases().ToArray().ElementAt(i)) &&
                    enrollmentOfPurchase.Equals(enrollment))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckDateWithTimeOfPurchase(DateTime date, IPurchase purchase)
        {
            DateTime dateWithTime = purchase.dateOfPurchase;
            dateWithTime = dateWithTime.AddMinutes(purchase.timeOfPurchase);
            if (date >= purchase.dateOfPurchase &&
                date <= dateWithTime)
                return true;
            else
                return false;
        }
    }
}


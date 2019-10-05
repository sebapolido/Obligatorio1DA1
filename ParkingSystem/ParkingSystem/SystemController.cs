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

        public bool IsEmptyTextOfPhone(int lengthOfTextPhone)
        {
            return lengthOfTextPhone == 0;
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

        public bool IsLengthOfMessageCorrect(int length)
        {
            return length > 8 && length < 20;
        }

        public bool IsCorrectSeparationOfEnrollmentMessageWithSpace(string[] lineOfMessage)
        {
            return lineOfMessage[0].Length == 3 && lineOfMessage.Length > 1 && lineOfMessage[1].Length == 4;
        }

        public bool IsCorrectSeparationOfEnrollmentMessageWithOutSpace(string[] lineOfMessage)
        {
            return lineOfMessage[0].Length == 7;
        }

        public bool WroteTime(string[] line)
        {
            return line.Length == 3 && line[2].Contains(':') && line[2].Length == 5;
        }

        public bool IsCorrectSeparationOfRestOfMessage(string[] line)
        {
            return line.Length >= 2 && line.Length <= 3;
        }

        public bool ValidateFormatOfEnrollment(string text)
        {
            if (text.Length > 6)
            {
                string[] line = text.Split(' ');
                if (IsCorrectSeparationOfEnrollmentMessageWithSpace(line) || IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line))
                {
                    text = text.Replace(" ", "");
                    string lettersOfEnrollment = text.Substring(0, 3).ToUpper();
                    string numbersOfEnrollment = text.Substring(3, 4);
                    if (!ValidateIsNumeric(lettersOfEnrollment) && ValidateIsNumeric(numbersOfEnrollment))
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

        public bool ValidateRepeatEnrollment(string letters, int numbers)
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
                        if (ValidateIsNumeric(hour) && ValidateIsNumeric(minutes) && ValidateIsNumeric(time))
                            return true;
                        else
                            return false;
                    }
                    else if (ValidateIsNumeric(time))
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
            return date.Hour >= 10 && date.Hour < 18 && date.Minute >= 0 && date.Minute < 60 && ValidateTimeThatHasPassed(date);
        }

        private bool ValidateTimeThatHasPassed(DateTime date)
        {
            if (date.Hour == DateTime.Now.Hour)
                return date.Minute >= DateTime.Now.Minute;
            else
                if (date.Hour > DateTime.Now.Hour)
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
                    return true;
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


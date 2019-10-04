using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public interface ISystemController
    {
        void AddAccount(IAccount account);
        List<IAccount> GetAccounts();
        void AddEnrollment(IEnrollment enrollment);
        List<IEnrollment> GetEnrollments();
        void AddPurchase(IPurchase purchase);
        List<IPurchase> GetPurchases();
        bool ValidateFormatNumber(ref string textOfPhone);
        bool IsFormatOfLengthOfNine(string text);
        bool IsFormatOfLengthOfEigth(string text);
        bool ValidateIsNumeric(string text);
        bool ValidateRepeatNumber(string text);
        IAccount GetAnAccount(string text);
        IEnrollment GetAnEnrollment(string letters, int numbers);
        bool ValidateFormatOfEnrollment(string text);
        bool ValidateRepeatEnrollment(string letters, int numbers);
        bool ValidateMinutes(string restOfMessage);
        bool ValidateValidHour(DateTime date);
        bool ValideTimeOfPurchase(int timeOfPurchase);
        bool IsConvertStringToNumber(string time);
        int CalculateFinalTimeOfPurchase(int timeOfPurchase, int hourOfPurchase, int minsOfPurchase);
        bool ArePurchaseOnThatDate(DateTime date, IEnrollment enrollment);
        bool CheckDateWithTimeOfPurchase(DateTime date, IPurchase purchase);
    }
}

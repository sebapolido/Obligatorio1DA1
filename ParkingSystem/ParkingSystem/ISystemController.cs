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
        bool IsRepeatedNumber(string text);
        IAccount GetAnAccount(string text);
        IEnrollment GetAnEnrollment(string letters, int numbers);
        bool IsRepeatedEnrollment(string letters, int numbers);
        bool ArePurchaseOnThatDate(DateTime date, IEnrollment enrollment);
    }
}

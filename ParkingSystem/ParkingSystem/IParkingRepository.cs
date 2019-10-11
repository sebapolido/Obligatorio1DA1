using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public interface IParkingRepository
    {
        void AddAccount(Account account);

        List<Account> GetAccounts();

        void AddEnrollment(Enrollment enrollment);

        List<Enrollment> GetEnrollments();

        void AddPurchase(Purchase purchase);

        List<Purchase> GetPurchases();

        bool IsRepeatedNumber(string text);

        Account GetAnAccount(string text);

        Enrollment GetAnEnrollment(string lettersToCompare, int numbersToCompare);

        bool IsRepeatedEnrollment(string letters, int numbers);

        bool ArePurchaseOnThatDate(DateTime date, Enrollment enrollment);
    }
}

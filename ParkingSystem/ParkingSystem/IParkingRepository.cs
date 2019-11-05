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

        void AddCountry(CountryHandler newCountry);

        List<CountryHandler> GetCountries();
       
        bool IsRepeatedNumber(string text, CountryHandler country);

        Account GetAnAccount(string text);

        Enrollment GetAnEnrollment(string lettersToCompare, int numbersToCompare);

        CountryHandler GetACountry(string nameOfCountry);

        bool IsRepeatedEnrollment(string letters, int numbers);

        bool IsRepeatedCountry(string name);

        bool ArePurchaseOnThatDate(DateTime date, Enrollment enrollment);

        void AddBalanceToAccount(Account account, int balanceToAdd);

        void SubstractBalanceToAccount(Account account, int balanceToSubstract);
    }
}

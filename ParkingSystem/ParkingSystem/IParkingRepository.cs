using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public interface IParkingRepository
    {
        void AddAccount(Account Account);

        List<Account> GetAccounts();

        void AddEnrollment(Enrollment Enrollment);

        List<Enrollment> GetEnrollments();

        void AddPurchase(Purchase Purchase);

        List<Purchase> GetPurchases();

        void AddCountry(CountryHandler NewCountry);

        List<CountryHandler> GetCountries();
       
        bool IsRepeatedNumber(string text);

        Account GetAnAccount(string text);

        Enrollment GetAnEnrollment(string LettersToCompare, int NumbersToCompare);

        CountryHandler GetACountry(string NameOfCountry);

        bool IsRepeatedEnrollment(string Letters, int Numbers);

        bool IsRepeatedCountry(string name);

        bool ArePurchaseOnThatDate(DateTime date, Enrollment Enrollment);

        void AddBalanceToAccount(Account Account, int balanceToAdd);

        void SubstractBalanceToAccount(Account Account, int BalanceToSubstract);

        List<Purchase> InsertPurchaseOfEnrollmentToDataGridView(Enrollment EnrollmentOfPurchase);

        List<Purchase> InsertPurchaseOnThatDate(DateTime InitialDateOfPurchase, DateTime FinalDateOfPurchase);

        List<Purchase> EliminatePurchasesFromAnoterCountry(List<Purchase> PurchasesOnThatDate, CountryHandler Country);

        void UpdateCostForMinutes(CountryHandler Country);
    }
}

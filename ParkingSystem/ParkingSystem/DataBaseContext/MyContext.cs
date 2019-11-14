using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class MyContext:DbContext
    {
        public DbSet<ValidatorOfPhone> ValidatorsOfPhone { get; set; }
        public DbSet<ValidatorOfMessage> ValidatorsOfMessage { get; set; }
        public DbSet<CountryHandler> Countries { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public MyContext()
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }

        internal List<Account> ReturnListOfAccounts()
        {
            return this.Accounts.Include("Country").Include("Country.ValidatorOfPhone")
                     .Include("Country.ValidatorOfMessage").ToList();
        }

        internal List<CountryHandler> ReturnListOfCountries()
        {
            return Countries.Include("ValidatorOfMessage").Include("ValidatorOfPhone").ToList();
        }

        internal List<Purchase> ReturnListOfPurchases()
        {
            return this.Purchases.Include("AccountOfPurchase").Include("EnrollmentOfPurchase")
                    .Include("AccountOfPurchase.Country").Include("AccountOfPurchase.Country.ValidatorOfMessage").
                    Include("AccountOfPurchase.Country.ValidatorOfPhone").ToList();
        }

        internal List<Enrollment> ReturnListOfEnrollments()
        {
            return this.Enrollments.ToList();
        }

        internal void AddAccount(Account newAccount)
        {
            this.Countries.Attach(newAccount.Country);
            this.Accounts.Add(newAccount);
            this.SaveChanges();
        }

        internal void AddBalanceToAccount(Account account, int balanceToAdd)
        {
            Account accountInDataBase = this.Accounts.Find(account.AccountId);
            accountInDataBase.Balance += balanceToAdd;
            this.SaveChanges();
        }

        internal void SubstractBalanceToAccount(Account account, int balanceToSubstract)
        {
            Account accountInDataBase = this.Accounts.Find(account.AccountId);
            accountInDataBase.Balance -= balanceToSubstract;
            this.SaveChanges();
        }

        internal void AddEnrollment(Enrollment newEnrollment)
        {
            this.Enrollments.Add(newEnrollment);
            this.SaveChanges();
        }

        internal void AddPurchase(Purchase newPurchase)
        {
            this.Enrollments.Attach(newPurchase.EnrollmentOfPurchase);
            this.Accounts.Attach(newPurchase.AccountOfPurchase);
            this.Purchases.Add(newPurchase);
            this.SaveChanges();
        }

        internal void AddCountry(CountryHandler newCountry)
        {
            this.Countries.Add(newCountry);
            this.SaveChanges();
        }

        internal void UpdateCostForMinutes(CountryHandler country)
        {
            CountryHandler countryInDataBase = this.Countries.Find(country.CountryHandlerId);
            countryInDataBase.CostForMinutes = country.CostForMinutes;
            this.SaveChanges();
        }
    }
}

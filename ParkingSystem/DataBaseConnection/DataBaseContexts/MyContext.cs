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

        public MyContext() : base("MyContext")
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseIfModelChanges<MyContext>());
        }

        public List<Account> ReturnListOfAccounts()
        {
            return this.Accounts.Include("Country").Include("Country.ValidatorOfPhone")
                     .Include("Country.ValidatorOfMessage").ToList();
        }

        public List<CountryHandler> ReturnListOfCountries()
        {
            return Countries.Include("ValidatorOfMessage").Include("ValidatorOfPhone").ToList();
        }

        public List<Purchase> ReturnListOfPurchases()
        {
            return this.Purchases.Include("AccountOfPurchase").Include("EnrollmentOfPurchase")
                    .Include("AccountOfPurchase.Country").Include("AccountOfPurchase.Country.ValidatorOfMessage").
                    Include("AccountOfPurchase.Country.ValidatorOfPhone").ToList();
        }

        public List<Enrollment> ReturnListOfEnrollments()
        {
            return this.Enrollments.ToList();
        }

        public void AddAccount(Account NewAccount)
        {
            this.Countries.Attach(NewAccount.Country);
            this.Accounts.Add(NewAccount);
            this.SaveChanges();
        }

        public void AddBalanceToAccount(Account Account, int balanceToAdd)
        {
            Account AccountInDataBase = this.Accounts.Find(Account.AccountId);
            AccountInDataBase.Balance += balanceToAdd;
            this.SaveChanges();
        }

        public void SubstractBalanceToAccount(Account Account, int BalanceToSubstract)
        {
            Account AccountInDataBase = this.Accounts.Find(Account.AccountId);
            AccountInDataBase.Balance -= BalanceToSubstract;
            this.SaveChanges();
        }

        public void AddEnrollment(Enrollment NewEnrollment)
        {
            this.Enrollments.Add(NewEnrollment);
            this.SaveChanges();
        }

        public void AddPurchase(Purchase NewPurchase)
        {
            this.Enrollments.Attach(NewPurchase.EnrollmentOfPurchase);
            this.Accounts.Attach(NewPurchase.AccountOfPurchase);
            this.Purchases.Add(NewPurchase);
            this.SaveChanges();
        }

        public void AddCountry(CountryHandler NewCountry)
        {
            this.Countries.Add(NewCountry);
            this.SaveChanges();
        }

        public void UpdateCostForMinutes(CountryHandler Country)
        {
            CountryHandler CountryInDataBase = this.Countries.Find(Country.CountryHandlerId);
            CountryInDataBase.CostForMinutes = Country.CostForMinutes;
            this.SaveChanges();
        }
    }
}

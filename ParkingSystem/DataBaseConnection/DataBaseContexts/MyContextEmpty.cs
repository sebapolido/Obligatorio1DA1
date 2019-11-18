using ParkingSystem;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseConnection
{
    public class MyContextEmpty : DbContext
    {
        public DbSet<ValidatorOfPhone> ValidatorsOfPhone { get; set; }
        public DbSet<ValidatorOfMessage> ValidatorsOfMessage { get; set; }
        public DbSet<CountryHandler> Countries { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public MyContextEmpty() : base("MyContextEmpty")
        {
            Database.SetInitializer<MyContextEmpty>(new DropCreateDatabaseIfModelChanges<MyContextEmpty>());
        }
    }
}

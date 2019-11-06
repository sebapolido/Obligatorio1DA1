using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Account
    {
        public int AccountId { get; set; }
        public int Balance { get; set; }
        public string Mobile { get; set; }
        public CountryHandler Country { get; set; }
        
        public Account(int newBalance, string newMobile, CountryHandler newCountry)
        {
            Balance = newBalance;
            Mobile = newMobile;
            Country = newCountry;
        }

        public Account()
        {
            this.Balance = 0;
            this.Mobile = "";
        }

        public override string ToString()
        {
            return Mobile;
        }
    }
}

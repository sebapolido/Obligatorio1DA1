using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Account
    {
        public int balance { get; set; }
        public string mobile { get; set; }

        
        public Account(int newBalance, string newMobile)
        {
            balance = newBalance;
            mobile = newMobile;
        }

        public Account()
        {
            this.balance = 0;
            this.mobile = "";
        }

        public void AddBalance(int balanceToAdd)
        {
            if(balanceToAdd > 0)
                balance += balanceToAdd;
        }

        public void SubstractBalance(int balanceToSubstract)
        {
            if(balanceToSubstract > 0 && this.balance >= balanceToSubstract)
                balance -= balanceToSubstract;
        }
    }
}

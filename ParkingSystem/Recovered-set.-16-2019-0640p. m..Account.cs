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

        public Mobile mobile { get; set; }

        public void addBalance(int newBalance)
        {
            balance += newBalance;
        }

    }
}

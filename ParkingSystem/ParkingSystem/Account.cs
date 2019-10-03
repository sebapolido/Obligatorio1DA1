﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Account:IAccount
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

        public void AddBalance(int newBalance)
        {
            if(newBalance > 0)
                balance += newBalance;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public interface IAccount
    {
        int balance { get; set; }
        string mobile { get; set; }

        void AddBalance(int newBalance);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class  ValidatorOfDate:Validator
    {
        public bool ValidateValidHour(DateTime date)
        {
            const int MIN_HOUR = 10;
            const int MAX_HOUR = 17;
            return date.Hour >= MIN_HOUR && date.Hour <= MAX_HOUR && ValidateTimeThatHasPassed(date);
        }

        public bool ValidateTimeThatHasPassed(DateTime Date)
        {
            if (Date.Hour == DateTime.Now.Hour)
                return Date.Minute >= DateTime.Now.Minute;
            else
                return Date.Hour > DateTime.Now.Hour;
        }

        public bool CheckDateWithTimeOfPurchase(DateTime Date, Purchase Purchase)
        {
            DateTime DateWithTime = Purchase.DateOfPurchase;
            DateWithTime = DateWithTime.AddMinutes(Purchase.TimeOfPurchase);
            if (Date >= Purchase.DateOfPurchase &&
                Date <= DateWithTime)
                return true;
            else
                return false;
        }
    }
}

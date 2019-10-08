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
            return date.Hour >= 10 && date.Hour < 18 && date.Minute >= 0 && date.Minute < 60 && ValidateTimeThatHasPassed(date);
        }

        public bool ValidateTimeThatHasPassed(DateTime date)
        {
            if (date.Hour == DateTime.Now.Hour)
                return date.Minute >= DateTime.Now.Minute;
            else
                return date.Hour > DateTime.Now.Hour;
        }

        public bool CheckDateWithTimeOfPurchase(DateTime date, Purchase purchase)
        {
            DateTime dateWithTime = purchase.dateOfPurchase;
            dateWithTime = dateWithTime.AddMinutes(purchase.timeOfPurchase);
            if (date >= purchase.dateOfPurchase &&
                date <= dateWithTime)
                return true;
            else
                return false;
        }
    }
}

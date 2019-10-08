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

        private bool ValidateTimeThatHasPassed(DateTime date)
        {
            if (date.Hour == DateTime.Now.Hour)
                return date.Minute >= DateTime.Now.Minute;
            else
                if (date.Hour > DateTime.Now.Hour)
                return true;
            else
                return false;
        }

        public bool CheckDateWithTimeOfPurchase(DateTime date, IPurchase purchase)
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

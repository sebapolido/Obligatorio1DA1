using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public Enrollment EnrollmentOfPurchase { get; set;}
        public int TimeOfPurchase { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Account AccountOfPurchase { get; set; }

        public Purchase()
        {
            EnrollmentOfPurchase = null;
            TimeOfPurchase = 0;
        }

        public Purchase(Enrollment enrollment, int time, DateTime dateTime, Account account)
        {
            EnrollmentOfPurchase = enrollment;
            TimeOfPurchase = time;
            DateOfPurchase = dateTime;
            AccountOfPurchase = account;
        }
    }
}

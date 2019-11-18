using System;

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

        public Purchase(Enrollment Enrollment, int Time, DateTime DateTime, Account Account)
        {
            EnrollmentOfPurchase = Enrollment;
            TimeOfPurchase = Time;
            DateOfPurchase = DateTime;
            AccountOfPurchase = Account;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    [Serializable]
    public class Purchase
    {
        public Enrollment enrollmentOfPurchase { get; set;}
        public int timeOfPurchase { get; set; }

        public Purchase()
        {
            enrollmentOfPurchase = null;
            timeOfPurchase = 0;
        }

        public Purchase(Enrollment enrollment, int time)
        {
            enrollmentOfPurchase = enrollment;
            timeOfPurchase = time;
        }
    }
}

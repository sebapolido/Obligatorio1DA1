using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public interface IPurchase
    {
        IEnrollment enrollmentOfPurchase { get; set; }
        int timeOfPurchase { get; set; }
        DateTime dateOfPurchase { get; set; }
    }
}

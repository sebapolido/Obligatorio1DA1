using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public interface IEnrollment
    {
        string lettersOfEnrollment { get; set; }
        int numbersOfEnrollment { get; set; }

        bool Equals(Object obj);
    }
}

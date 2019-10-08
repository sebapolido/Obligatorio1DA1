using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Enrollment
    {
        public string lettersOfEnrollment { get; set; }
        public int numbersOfEnrollment { get; set; }

        public Enrollment()
        {
            this.lettersOfEnrollment = "";
            this.numbersOfEnrollment = 0;
        }

        public Enrollment(string newLetter, int newNumbers)
        {
            lettersOfEnrollment = newLetter;
            numbersOfEnrollment = newNumbers;
        }

        public override bool Equals(Object obj)
        {
            Enrollment enrollment = (Enrollment)obj;
            return numbersOfEnrollment == enrollment.numbersOfEnrollment && lettersOfEnrollment.Equals(enrollment.lettersOfEnrollment);
        }

    }
}

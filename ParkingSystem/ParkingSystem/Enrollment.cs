using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Enrollment
    {
        [Key]
        public int IdEnrollment { get; set; }
        public string LettersOfEnrollment { get; set; }
        public int NumbersOfEnrollment { get; set; }

        public Enrollment()
        {
            this.LettersOfEnrollment = "";
            this.NumbersOfEnrollment = 0;
        }

        public Enrollment(string newLetter, int newNumbers)
        {
            LettersOfEnrollment = newLetter;
            NumbersOfEnrollment = newNumbers;
        }

        public override bool Equals(Object obj)
        {
            Enrollment enrollment = (Enrollment)obj;
            return NumbersOfEnrollment == enrollment.NumbersOfEnrollment && LettersOfEnrollment.Equals(enrollment.LettersOfEnrollment);
        }
    }
}

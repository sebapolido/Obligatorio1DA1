using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfEnrollment:Validator
    {
        public bool IsCorrectSeparationOfEnrollmentMessageWithSpace(string[] LineOfMessage)
        {
            const int LENGTH_OF_Letters_Enrollment = 3;
            const int LENGTH_OF_Numbers_Enrollment = 4;
            return LineOfMessage[0].Length == LENGTH_OF_Letters_Enrollment && 
                LineOfMessage.Length > 1 && LineOfMessage[1].Length == LENGTH_OF_Numbers_Enrollment;
        }

        public bool IsCorrectSeparationOfEnrollmentMessageWithOutSpace(string[] LineOfMessage)
        {
            const int LENGTH_OF_Enrollment = 7;
            return LineOfMessage[0].Length == LENGTH_OF_Enrollment;
        }

        public bool ValidateFormatOfEnrollment(string TextOfEnrollment)
        {
            const int LENGTH_WHIT_SPACE = 8;
            const int LENGTH_WITHOUT_SPACE = 7;
            if (TextOfEnrollment.Length == LENGTH_WHIT_SPACE || TextOfEnrollment.Length == LENGTH_WITHOUT_SPACE)
            {
                string[] line = TextOfEnrollment.Split(' ');
                if (IsCorrectSeparationOfEnrollmentMessageWithSpace(line) || IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line))
                    return ValidateDataFromEnrollment(TextOfEnrollment);
                else
                    return false;
            }
            else
                return false;
        }

        private bool ValidateDataFromEnrollment(string TextOfEnrollment)
        {
            TextOfEnrollment = TextOfEnrollment.Replace(" ", "");
            string LettersOfEnrollment = TextOfEnrollment.Substring(0, 3).ToUpper();
            string NumbersOfEnrollment = TextOfEnrollment.Substring(3, 4);
            if (!ValidateIsNumeric(LettersOfEnrollment) && ValidateIsNumeric(NumbersOfEnrollment))
                return true;
            else
                return false;
        }
    }
}

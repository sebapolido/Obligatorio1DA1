using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfEnrollment:Validator
    {
        public bool IsCorrectSeparationOfEnrollmentMessageWithSpace(string[] lineOfMessage)
        {
            const int LENGTH_OF_LETTERS_ENROLLMENT = 3;
            const int LENGTH_OF_NUMBERS_ENROLLMENT = 4;
            return lineOfMessage[0].Length == LENGTH_OF_LETTERS_ENROLLMENT && 
                lineOfMessage.Length > 1 && lineOfMessage[1].Length == LENGTH_OF_NUMBERS_ENROLLMENT;
        }

        public bool IsCorrectSeparationOfEnrollmentMessageWithOutSpace(string[] lineOfMessage)
        {
            const int LENGTH_OF_ENROLLMENT = 7;
            return lineOfMessage[0].Length == LENGTH_OF_ENROLLMENT;
        }

        public bool ValidateFormatOfEnrollment(string textOfEnrollment)
        {
            const int LENGTH_WHIT_SPACE = 8;
            const int LENGTH_WITHOUT_SPACE = 7;
            if (textOfEnrollment.Length == LENGTH_WHIT_SPACE || textOfEnrollment.Length == LENGTH_WITHOUT_SPACE)
            {
                string[] line = textOfEnrollment.Split(' ');
                if (IsCorrectSeparationOfEnrollmentMessageWithSpace(line) || IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line))
                    return ValidateDataFromEnrollment(textOfEnrollment);
                else
                    return false;
            }
            else
                return false;
        }

        private bool ValidateDataFromEnrollment(string textOfEnrollment)
        {
            textOfEnrollment = textOfEnrollment.Replace(" ", "");
            string lettersOfEnrollment = textOfEnrollment.Substring(0, 3).ToUpper();
            string numbersOfEnrollment = textOfEnrollment.Substring(3, 4);
            if (!ValidateIsNumeric(lettersOfEnrollment) && ValidateIsNumeric(numbersOfEnrollment))
                return true;
            else
                return false;
        }
    }
}

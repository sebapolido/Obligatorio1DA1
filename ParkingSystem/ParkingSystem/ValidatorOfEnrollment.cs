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
            return lineOfMessage[0].Length == 3 && lineOfMessage.Length > 1 && lineOfMessage[1].Length == 4;
        }

        public bool IsCorrectSeparationOfEnrollmentMessageWithOutSpace(string[] lineOfMessage)
        {
            return lineOfMessage[0].Length == 7;
        }

        public bool ValidateFormatOfEnrollment(string text)
        {
            if (text.Length > 6)
            {
                string[] line = text.Split(' ');
                if (IsCorrectSeparationOfEnrollmentMessageWithSpace(line) || IsCorrectSeparationOfEnrollmentMessageWithOutSpace(line))
                {
                    text = text.Replace(" ", "");
                    string lettersOfEnrollment = text.Substring(0, 3).ToUpper();
                    string numbersOfEnrollment = text.Substring(3, 4);
                    if (!ValidateIsNumeric(lettersOfEnrollment) && ValidateIsNumeric(numbersOfEnrollment))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }
    }
}

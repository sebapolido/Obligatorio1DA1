using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfPhoneInArgentina:ValidatorOfPhone
    {
        public bool ValidateFormatNumber(ref string textOfPhone)
        {
            return CorrectScripts(ref textOfPhone);
        }

        private bool CorrectScripts(ref string textOfPhone)
        {
            int length = textOfPhone.Length-1;
            if (textOfPhone.ElementAt(0).Equals('-') || textOfPhone.ElementAt(length).Equals('-'))
                return false;
            else
                textOfPhone = textOfPhone.Replace("-","");
            return IsFormatOfLengthOfSix(textOfPhone) ||
                IsFormatOfLengthOfSeven(textOfPhone) || 
                IsFormatOfLengthOfEigth(textOfPhone);
        }

        private bool IsFormatOfLengthOfSix(string textOfPhone)
        {            
            const int LENGTH_FORMAT_OF_SIX = 6;
            return textOfPhone.Length == LENGTH_FORMAT_OF_SIX;
        }

        private bool IsFormatOfLengthOfSeven(string textOfPhone)
        {
            const int LENGTH_FORMAT_OF_SEVEN = 7;
            return textOfPhone.Length == LENGTH_FORMAT_OF_SEVEN;
        }

        private bool IsFormatOfLengthOfEigth(string textOfPhone)
        {
            const int LENGTH_FORMAT_OF_EIGTH = 8;
            return textOfPhone.Length == LENGTH_FORMAT_OF_EIGTH;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfPhoneInArgentina:ValidatorOfPhone
    {
        public override bool ValidateFormatNumber(ref string TextOfPhone)
        {
            return CorrectScripts(ref TextOfPhone);
        }

        private bool CorrectScripts(ref string TextOfPhone)
        {
            int Length = TextOfPhone.Length-1;
            if (TextOfPhone.ElementAt(0).Equals('-') || TextOfPhone.ElementAt(Length).Equals('-'))
                return false;
            else
                TextOfPhone = TextOfPhone.Replace("-","");
            return IsFormatOfLengthOfSix(TextOfPhone) ||
                IsFormatOfLengthOfSeven(TextOfPhone) || 
                IsFormatOfLengthOfEigth(TextOfPhone);
        }

        private bool IsFormatOfLengthOfSix(string TextOfPhone)
        {            
            const int LENGTH_FORMAT_OF_SIX = 6;
            return TextOfPhone.Length == LENGTH_FORMAT_OF_SIX;
        }

        private bool IsFormatOfLengthOfSeven(string TextOfPhone)
        {
            const int LENGTH_FORMAT_OF_SEVEN = 7;
            return TextOfPhone.Length == LENGTH_FORMAT_OF_SEVEN;
        }

        private bool IsFormatOfLengthOfEigth(string TextOfPhone)
        {
            const int LENGTH_FORMAT_OF_EIGTH = 8;
            return TextOfPhone.Length == LENGTH_FORMAT_OF_EIGTH;
        }
    }
}

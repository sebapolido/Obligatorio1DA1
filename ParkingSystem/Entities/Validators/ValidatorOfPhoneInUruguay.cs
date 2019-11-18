using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfPhoneInUruguay:ValidatorOfPhone
    {
        public override bool ValidateFormatNumber(ref string TextOfPhone)
        {
            if (IsFormatOfLengthOfNine(TextOfPhone))
                return true;
            else if (IsFormatOfLengthOfEigth(TextOfPhone))
            {
                TextOfPhone = TextOfPhone.Insert(0, "0");
                return true;
            }
            else
                return false;
        }

        private bool IsFormatOfLengthOfNine(string TextOfPhone)
        {
            const int LENGTH_FORMAT_OF_NINE = 9;
            return TextOfPhone.Length == LENGTH_FORMAT_OF_NINE && TextOfPhone[0].Equals('0')
                && TextOfPhone[1].Equals('9');
        }

        private bool IsFormatOfLengthOfEigth(string TextOfPhone)
        {
            const int LENGTH_FORMAT_OF_EIGTH = 8;
            return TextOfPhone.Length == LENGTH_FORMAT_OF_EIGTH && TextOfPhone[0].Equals('9');
        }
    }
}

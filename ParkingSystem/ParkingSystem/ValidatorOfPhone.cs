using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class  ValidatorOfPhone:Validator
    {
        public bool ValidateFormatNumber(ref string textOfPhone)
        {
            if (IsFormatOfLengthOfNine(textOfPhone))
                return true;
            else if (IsFormatOfLengthOfEigth(textOfPhone))
            {
                textOfPhone = textOfPhone.Insert(0, "0");
                return true;
            }
            else
                return false;
        }

        public bool IsFormatOfLengthOfNine(string textOfPhone)
        {
            const int LENGTH_FORMAT_OF_NINE = 9;
            return textOfPhone.Length == LENGTH_FORMAT_OF_NINE && textOfPhone[0].Equals('0') 
                && textOfPhone[1].Equals('9');
        }

        public bool IsFormatOfLengthOfEigth(string textOfPhone)
        {
            const int LENGTH_FORMAT_OF_EIGTH = 8;
            return textOfPhone.Length == LENGTH_FORMAT_OF_EIGTH && textOfPhone[0].Equals('9');
        }
    }
}

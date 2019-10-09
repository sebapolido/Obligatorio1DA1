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

        public bool IsFormatOfLengthOfNine(string text)
        {
            return text.Length == 9 && text[0].Equals('0') && text[1].Equals('9');
        }

        public bool IsFormatOfLengthOfEigth(string text)
        {
            return text.Length == 8 && text[0].Equals('9');
        }
    }
}

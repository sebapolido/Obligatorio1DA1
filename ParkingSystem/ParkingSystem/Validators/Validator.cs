using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Validator
    {
        public bool ValidateIsNumeric(string text)
        {
            return (Int32.TryParse(text, out int isNumeric));
        }

        public bool ValidateIsEmpty(string text)
        {
            return text.Length == 0;
        }
    }
}

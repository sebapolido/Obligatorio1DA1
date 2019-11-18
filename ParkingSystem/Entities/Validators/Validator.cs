using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public abstract class Validator
    {
        public bool ValidateIsNumeric(string Text)
        {
            return (Int32.TryParse(Text, out int isNumeric));
        }

        public bool ValidateIsEmpty(string Text)
        {
            return Text.Length == 0;
        }
    }
}

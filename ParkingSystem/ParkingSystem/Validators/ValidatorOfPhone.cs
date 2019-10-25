using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public abstract class ValidatorOfPhone:Validator
    {
        public abstract bool ValidateFormatNumber(ref string textOfPhone);
    }
}

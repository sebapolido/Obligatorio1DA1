    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfMessageInArgentina:ValidatorOfMessage
    {
        public override bool WroteHourAndMinutes(string[] LineOfMessage)
        {
            return LineOfMessage.Length == 3 && LineOfMessage[1].Contains(':') &&
                LineOfMessage[1].Length == 5;
        }

        public override bool ValidateMessageData(string RestOfMessage)
        {
            const int CORRECT_LENGTH_OF_LINE_MESSAGE = 3;
            string[] LineOfMessage = RestOfMessage.Split(' ');
            string Time;
            if (LineOfMessage.Length == CORRECT_LENGTH_OF_LINE_MESSAGE)
            {
                Time = LineOfMessage[2];
                return ValidateHourAndMinutesData(Time, LineOfMessage);
            }
            else
                return false;            
        }

        private bool ValidateHourAndMinutesData(string Time, string[] LineOfMessage)
        {
            string[] LineOfHours = LineOfMessage[1].Split(':');
            if (LineOfHours.Length == 2)
            {
                string Hour = LineOfHours[0];
                string Minutes = LineOfHours[1];
                if (Hour.Length == 2 && Minutes.Length == 2
                    && ValidateIsNumeric(Hour) && ValidateIsNumeric(Minutes) && ValidateIsNumeric(Time))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public override bool ValideTimeOfPurchase(int TimeOfPurchase)
        {
            return TimeOfPurchase > 0;
        }

        internal override int AssignHour(string[] LineOfRestOfMessage)
        {
            return int.Parse(LineOfRestOfMessage[1].Split(':')[0]);
        }

        internal override int AssignMinutes(string[] LineOfRestOfMessage)
        {
            return int.Parse(LineOfRestOfMessage[1].Split(':')[1]);
        }

        internal override int AssignTime(string[] LineOfRestOfMessage)
        {
            if(WroteHourAndMinutes(LineOfRestOfMessage))
                return int.Parse(LineOfRestOfMessage[2]);
            else
                return int.Parse(LineOfRestOfMessage[1]);
        }
    }
}

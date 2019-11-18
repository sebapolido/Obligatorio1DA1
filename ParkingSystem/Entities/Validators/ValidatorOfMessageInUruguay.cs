using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfMessageInUruguay:ValidatorOfMessage
    {

        public override bool WroteHourAndMinutes(string[] LineOfMessage)
        {
            return LineOfMessage.Length == 3 && LineOfMessage[2].Contains(':') &&
                LineOfMessage[2].Length == 5;
        }

        public override bool ValidateMessageData(string RestOfMessage)
        {
            const int CORRECT_LENGTH_OF_LINE_MESSAGE = 3;
            string[] LineOfMessage = RestOfMessage.Split(' ');
            if (IsCorrectSeparationOfRestOfMessage(LineOfMessage))
            {
                string Time = LineOfMessage[1];
                if (LineOfMessage.Length == CORRECT_LENGTH_OF_LINE_MESSAGE)
                    return ValidateHourAndMinutesData(Time, LineOfMessage);
                else
                    return ValidateIsNumeric(Time);
            }
            else
                return false;
        }

        private bool ValidateHourAndMinutesData(string Time, string[] LineOfMessage)
        {
            string[] LineOfHours = LineOfMessage[2].Split(':');
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
            const int EMPTY_TIME = 0;
            const int TIME_THAT_MUST_BE_MULTIPLE = 30;
            if (TimeOfPurchase > EMPTY_TIME)
                if (TimeOfPurchase % TIME_THAT_MUST_BE_MULTIPLE == 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        internal override int AssignHour(string[] LineOfRestOfMessage)
        {
            return int.Parse(LineOfRestOfMessage[2].Split(':')[0]);
        }

        internal override int AssignMinutes(string[] LineOfRestOfMessage)
        {
            return int.Parse(LineOfRestOfMessage[2].Split(':')[1]);
        }

        internal override int AssignTime(string[] LineOfRestOfMessage)
        {
            return int.Parse(LineOfRestOfMessage[1]);
        }
    }
}

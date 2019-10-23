using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfMessageInUruguay:ValidatorOfMessage
    {

        public bool WroteHourAndMinutes(string[] lineOfMessage)
        {
            return lineOfMessage.Length == 3 && lineOfMessage[2].Contains(':') &&
                lineOfMessage[2].Length == 5;
        }

        public bool ValidateMessageData(string restOfMessage)
        {
            const int CORRECT_LENGTH_OF_LINE_MESSAGE = 3;
            string[] lineOfMessage = restOfMessage.Split(' ');
            if (IsCorrectSeparationOfRestOfMessage(lineOfMessage))
            {
                string time = lineOfMessage[1];
                if (lineOfMessage.Length == CORRECT_LENGTH_OF_LINE_MESSAGE)
                    return ValidateHourAndMinutesData(time, lineOfMessage);
                else
                    return ValidateIsNumeric(time);
            }
            else
                return false;
        }

        private bool ValidateHourAndMinutesData(string time, string[] lineOfMessage)
        {
            string[] lineOfHours = lineOfMessage[2].Split(':');
            if (lineOfHours.Length == 2)
            {
                string hour = lineOfHours[0];
                string minutes = lineOfHours[1];
                if (hour.Length == 2 && minutes.Length == 2
                    && ValidateIsNumeric(hour) && ValidateIsNumeric(minutes) && ValidateIsNumeric(time))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public bool ValideTimeOfPurchase(int timeOfPurchase)
        {
            const int EMPTY_TIME = 0;
            const int TIME_THAT_MUST_BE_MULTIPLE = 30;
            if (timeOfPurchase > EMPTY_TIME)
                if (timeOfPurchase % TIME_THAT_MUST_BE_MULTIPLE == 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        internal int AssignHour(string[] lineOfRestOfMessage)
        {
            return int.Parse(lineOfRestOfMessage[2].Split(':')[0]);
        }

        internal int AssignMinutes(string[] lineOfRestOfMessage)
        {
            return int.Parse(lineOfRestOfMessage[2].Split(':')[1]);
        }

        internal int AssignTime(string[] lineOfRestOfMessage)
        {
            return int.Parse(lineOfRestOfMessage[1]);
        }
    }
}

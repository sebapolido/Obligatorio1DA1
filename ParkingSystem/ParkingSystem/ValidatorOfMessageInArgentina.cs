using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfMessageInArgentina:ValidatorOfMessage
    {
        public bool WroteHourAndMinutes(string[] lineOfMessage) //arreglar
        {
            return lineOfMessage.Length == 3 && lineOfMessage[1].Contains(':') &&
                lineOfMessage[1].Length == 5;
        }

        public bool ValidateMessageData(string restOfMessage)
        {
            const int CORRECT_LENGTH_OF_LINE_MESSAGE = 3;
            string[] lineOfMessage = restOfMessage.Split(' ');
            if (IsCorrectSeparationOfRestOfMessage(lineOfMessage))
            {
                string time;
                if (lineOfMessage.Length == CORRECT_LENGTH_OF_LINE_MESSAGE)
                {
                    time = lineOfMessage[2];
                    return ValidateHourAndMinutesData(time, lineOfMessage);
                }
                else
                {
                    time = lineOfMessage[1];
                    return ValidateIsNumeric(time);
                }
            }
            else
                return false;
        }

        private bool ValidateHourAndMinutesData(string time, string[] lineOfMessage)
        {
            string[] lineOfHours = lineOfMessage[1].Split(':');
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
            return timeOfPurchase > 0;
        }
    }
}

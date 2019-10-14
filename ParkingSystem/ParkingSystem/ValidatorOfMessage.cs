using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ValidatorOfMessage:Validator
    {
        public bool IsLengthOfMessageCorrect(int length)
        {
            const int MIN_LENGTH_OF_MESSAGE = 9;
            const int MAX_LENGTH_OF_MESSAGE = 19;
            return length >= MIN_LENGTH_OF_MESSAGE && length <= MAX_LENGTH_OF_MESSAGE;
        }
        
        public bool WroteHourAndMinutes(string[] lineOfMessage)
        {
            return lineOfMessage.Length == 3 && lineOfMessage[2].Contains(':') &&
                lineOfMessage[2].Length == 5;
        }

        public bool IsCorrectSeparationOfRestOfMessage(string[] lineOfMessage)
        {
            return lineOfMessage.Length >= 2 && lineOfMessage.Length <= 3;
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

        private bool ValidateHourAndMinutesData(string time, string [] lineOfMessage)
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

        public int CalculateFinalTimeOfPurchase(int timeOfPurchase, DateTime dateOfPurchse)
        {
            const int MAX_HOUR = 17;
            const int ONE_HOUR_IN_MINUTES = 60;
            int timeOfTheRestOfDay = ONE_HOUR_IN_MINUTES - dateOfPurchse.Minute;
            for (int i = dateOfPurchse.Hour; i < MAX_HOUR; i++)
                timeOfTheRestOfDay += ONE_HOUR_IN_MINUTES;
            if (timeOfPurchase > timeOfTheRestOfDay)
                return timeOfTheRestOfDay;
            else
                return timeOfPurchase;
        }
    }
}

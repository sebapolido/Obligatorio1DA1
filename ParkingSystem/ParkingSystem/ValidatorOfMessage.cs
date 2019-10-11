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
            return length > 8 && length < 20;
        }
        
        public bool WroteHourAndMinutes(string[] line)
        {
            return line.Length == 3 && line[2].Contains(':') && line[2].Length == 5;
        }

        public bool IsCorrectSeparationOfRestOfMessage(string[] line)
        {
            return line.Length >= 2 && line.Length <= 3;
        }
        
        public bool ValidateMessageData(string restOfMessage)
        {
            string[] lineOfMessage = restOfMessage.Split(' ');
            if (IsCorrectSeparationOfRestOfMessage(lineOfMessage))
            {
                string time = lineOfMessage[1];
                if (lineOfMessage.Length == 3)
                {
                    return ValidateHourAndMinutesData(time, lineOfMessage);
                }
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
            if (timeOfPurchase > 0)
                if (timeOfPurchase % 30 == 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        public int CalculateFinalTimeOfPurchase(int timeOfPurchase, DateTime dateOfPurchse)
        {
            if (dateOfPurchse.Hour >= 10 && dateOfPurchse.Hour < 18)
            {
                int finalTimeOfPurchase = 0;
                finalTimeOfPurchase = 60 - dateOfPurchse.Minute;
                for (int i = dateOfPurchse.Hour; i < 17; i++)
                    finalTimeOfPurchase += 60;
                if (timeOfPurchase > finalTimeOfPurchase)
                    return finalTimeOfPurchase;
                else
                    return timeOfPurchase;
            }
            else
                return 0;
        }

    }
}

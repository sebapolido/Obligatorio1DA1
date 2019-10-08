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
        
        public bool WroteTime(string[] line)
        {
            return line.Length == 3 && line[2].Contains(':') && line[2].Length == 5;
        }

        public bool IsCorrectSeparationOfRestOfMessage(string[] line)
        {
            return line.Length >= 2 && line.Length <= 3;
        }
        
        public bool ValidateMinutes(string restOfMessage)
        {
            string[] lineOfMessage = restOfMessage.Split(' ');
            if (lineOfMessage.Length >= 2 && lineOfMessage.Length <= 3)
            {
                string time = lineOfMessage[1];
                string hour = "";
                string minutes = "";
                if (lineOfMessage.Length == 3)
                {
                    string[] lineOfHours = lineOfMessage[2].Split(':');
                    if (lineOfHours.Length == 2)
                    {
                        hour = lineOfHours[0];
                        minutes = lineOfHours[1];
                        if (hour.Length == 2 && minutes.Length == 2
                            && ValidateIsNumeric(hour) && ValidateIsNumeric(minutes) && ValidateIsNumeric(time))
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return ValidateIsNumeric(time);
            }
            else
                return false;
        }

        public bool ValideTimeOfPurchase(int timeOfPurchase)
        {
            if (timeOfPurchase > 0)
            {
                if (timeOfPurchase % 30 == 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public int CalculateFinalTimeOfPurchase(int timeOfPurchase, int hourOfPurchase, int minsOfPurchase)
        {
            if (hourOfPurchase >= 10 && hourOfPurchase < 18 && minsOfPurchase >= 0 && minsOfPurchase < 60)
            {
                int finalTimeOfPurchase = 0;
                finalTimeOfPurchase = 60 - minsOfPurchase;
                for (int i = hourOfPurchase; i < 17; i++)
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

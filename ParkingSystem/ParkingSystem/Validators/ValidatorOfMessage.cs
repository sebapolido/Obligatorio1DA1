using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public abstract class ValidatorOfMessage:Validator
    {
        public abstract bool WroteHourAndMinutes(string[] lineOfMessage);

        public abstract bool ValidateMessageData(string restOfMessage);

        public abstract bool ValideTimeOfPurchase(int timeOfPurchase);

        internal abstract int AssignHour(string[] lineOfRestOfMessage);

        internal abstract int AssignMinutes(string[] lineOfRestOfMessage);

        internal abstract int AssignTime(string[] lineOfRestOfMessage);

        public bool IsLengthOfMessageCorrect(int length)
        {
            const int MIN_LENGTH_OF_MESSAGE = 9;
            const int MAX_LENGTH_OF_MESSAGE = 19;
            return length >= MIN_LENGTH_OF_MESSAGE && length <= MAX_LENGTH_OF_MESSAGE;
        }

        public bool IsCorrectSeparationOfRestOfMessage(string[] lineOfMessage)
        {
            return lineOfMessage.Length >= 2 && lineOfMessage.Length <= 3;
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

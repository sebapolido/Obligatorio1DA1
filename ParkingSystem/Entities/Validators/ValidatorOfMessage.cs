using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public abstract class ValidatorOfMessage:Validator
    {
        public int ValidatorOfMessageId { get; set; }

        public abstract bool WroteHourAndMinutes(string[] LineOfMessage);

        public abstract bool ValidateMessageData(string RestOfMessage);

        public abstract bool ValideTimeOfPurchase(int TimeOfPurchase);

        internal abstract int AssignHour(string[] LineOfRestOfMessage);

        internal abstract int AssignMinutes(string[] LineOfRestOfMessage);

        internal abstract int AssignTime(string[] LineOfRestOfMessage);

        public bool IsLengthOfMessageCorrect(int Length)
        {
            const int MIN_LENGTH_OF_MESSAGE = 9;
            const int MAX_LENGTH_OF_MESSAGE = 19;
            return Length >= MIN_LENGTH_OF_MESSAGE && Length <= MAX_LENGTH_OF_MESSAGE;
        }

        public bool IsCorrectSeparationOfRestOfMessage(string[] LineOfMessage)
        {
            return LineOfMessage.Length >= 2 && LineOfMessage.Length <= 3;
        }        

        public int CalculateFinalTimeOfPurchase(int TimeOfPurchase, DateTime DateOfPurchase)
        {
            const int MAX_HOUR = 17;
            const int ONE_HOUR_IN_MINUTES = 60;
            int TimeOfTheRestOfDay = ONE_HOUR_IN_MINUTES - DateOfPurchase.Minute;
            for (int i = DateOfPurchase.Hour; i < MAX_HOUR; i++)
                TimeOfTheRestOfDay += ONE_HOUR_IN_MINUTES;
            if (TimeOfPurchase > TimeOfTheRestOfDay)
                return TimeOfTheRestOfDay;
            else
                return TimeOfPurchase;
        }
    }
}

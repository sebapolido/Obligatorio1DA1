using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class CountryHandler
    {
        public int IdCountry { get; set; }
        public string NameOfCountry { get; set; }
        public int CostForMinutes { get; set; }
        private ValidatorOfPhone validatorOfPhone;
        private ValidatorOfMessage validatorOfMessage;

        public CountryHandler(string actualCountry, int NewCostForMinutes)
        {
            this.NameOfCountry = actualCountry;
            this.CostForMinutes = NewCostForMinutes;
        }

           
        public void SetValidators(ValidatorOfPhone newValidatorOfPhone, ValidatorOfMessage newValidatorOfMessage)
        {
            validatorOfPhone = newValidatorOfPhone;
            validatorOfMessage = newValidatorOfMessage;
        }

        public bool ValidateIsEmptyByCountry(string textOfPhone)
        {
            return validatorOfPhone.ValidateIsEmpty(textOfPhone);           
        }

        public bool ValidateIsNumericByCountry(string textOfPhone)
        {
            return validatorOfPhone.ValidateIsNumeric(textOfPhone);            
        }

        public bool ValidateFormatNumberByCountry(ref string textOfPhone)
        {
            return validatorOfPhone.ValidateFormatNumber(ref textOfPhone);
        }

        public bool ValidateMessageDataByCountry(string restOfMessage)
        {
            return validatorOfMessage.ValidateMessageData(restOfMessage);
        }

        public bool WroteHourAndMinutesByCountry(string[] lineOfRestOfMessage)
        {
            return validatorOfMessage.WroteHourAndMinutes(lineOfRestOfMessage);
        }

        public bool ValidateTimeOfPurchaseByCountry(int timeOfPurchase)
        {
            return validatorOfMessage.ValideTimeOfPurchase(timeOfPurchase);
        }

        public bool IsLengthOfMessageCorrectByCountry(int length)
        {
            return validatorOfMessage.IsLengthOfMessageCorrect(length);
        }

        public int CalculateFinalTimeOfPurchaseByCountry(int timeOfPurchase, DateTime dateOfPurchse)
        {
            return validatorOfMessage.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
        }

        public int AssignHour(string[] lineOfRestOfMessage)
        {
            return validatorOfMessage.AssignHour(lineOfRestOfMessage);
        }

        public int AssignMinutes(string[] lineOfRestOfMessage)
        {
            return validatorOfMessage.AssignMinutes(lineOfRestOfMessage);
        }

        public int AssignTime(string[] lineOfRestOfMessage)
        {
            return validatorOfMessage.AssignTime(lineOfRestOfMessage);
        }
    }
}

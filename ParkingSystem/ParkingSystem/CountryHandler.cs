using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class CountryHandler
    {
        public int CountryHandlerId { get; set; }
        public string NameOfCountry { get; set; }
        public int CostForMinutes { get; set; }
        public ValidatorOfPhone ValidatorOfPhone { get; set; }
        public ValidatorOfMessage ValidatorOfMessage { get; set; }

        public CountryHandler(string actualCountry, int NewCostForMinutes)
        {
            this.NameOfCountry = actualCountry;
            this.CostForMinutes = NewCostForMinutes;
        }

        public CountryHandler()
        {

        }
           
        public void SetValidators(ValidatorOfPhone newValidatorOfPhone, ValidatorOfMessage newValidatorOfMessage)
        {
            ValidatorOfPhone = newValidatorOfPhone;
            ValidatorOfMessage = newValidatorOfMessage;
        }

        public bool ValidateIsEmptyByCountry(string textOfPhone)
        {
            return ValidatorOfPhone.ValidateIsEmpty(textOfPhone);           
        }

        public bool ValidateIsNumericByCountry(string textOfPhone)
        {
            return ValidatorOfPhone.ValidateIsNumeric(textOfPhone);            
        }

        public bool ValidateFormatNumberByCountry(ref string textOfPhone)
        {
            return ValidatorOfPhone.ValidateFormatNumber(ref textOfPhone);
        }

        public bool ValidateMessageDataByCountry(string restOfMessage)
        {
            return ValidatorOfMessage.ValidateMessageData(restOfMessage);
        }

        public bool WroteHourAndMinutesByCountry(string[] lineOfRestOfMessage)
        {
            return ValidatorOfMessage.WroteHourAndMinutes(lineOfRestOfMessage);
        }

        public bool ValidateTimeOfPurchaseByCountry(int timeOfPurchase)
        {
            return ValidatorOfMessage.ValideTimeOfPurchase(timeOfPurchase);
        }

        public bool IsLengthOfMessageCorrectByCountry(int length)
        {
            return ValidatorOfMessage.IsLengthOfMessageCorrect(length);
        }

        public int CalculateFinalTimeOfPurchaseByCountry(int timeOfPurchase, DateTime dateOfPurchse)
        {
            return ValidatorOfMessage.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
        }

        public int AssignHourByCountry(string[] lineOfRestOfMessage)
        {
            return ValidatorOfMessage.AssignHour(lineOfRestOfMessage);
        }

        public int AssignMinutesByCountry(string[] lineOfRestOfMessage)
        {
            return ValidatorOfMessage.AssignMinutes(lineOfRestOfMessage);
        }

        public int AssignTimeByCountry(string[] lineOfRestOfMessage)
        {
            return ValidatorOfMessage.AssignTime(lineOfRestOfMessage);
        }
    }
}

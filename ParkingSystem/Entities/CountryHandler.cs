using System;

namespace ParkingSystem
{
    public class CountryHandler
    {
        public int CountryHandlerId { get; set; }
        public string NameOfCountry { get; set; }
        public int CostForMinutes { get; set; }
        public ValidatorOfPhone ValidatorOfPhone { get; set; }
        public ValidatorOfMessage ValidatorOfMessage { get; set; }

        public CountryHandler(string ActualCountry, int NewCostForMinutes)
        {
            this.NameOfCountry = ActualCountry;
            this.CostForMinutes = NewCostForMinutes;
        }

        public CountryHandler()
        {

        }
           
        public void SetValidators(ValidatorOfPhone NewValidatorOfPhone, ValidatorOfMessage NewValidatorOfMessage)
        {
            ValidatorOfPhone = NewValidatorOfPhone;
            ValidatorOfMessage = NewValidatorOfMessage;
        }

        public bool ValidateIsEmptyByCountry(string TextOfPhone)
        {
            return ValidatorOfPhone.ValidateIsEmpty(TextOfPhone);           
        }

        public bool ValidateIsNumericByCountry(string TextOfPhone)
        {
            return ValidatorOfPhone.ValidateIsNumeric(TextOfPhone);            
        }

        public bool ValidateFormatNumberByCountry(ref string TextOfPhone)
        {
            return ValidatorOfPhone.ValidateFormatNumber(ref TextOfPhone);
        }

        public bool ValidateMessageDataByCountry(string RestOfMessage)
        {
            return ValidatorOfMessage.ValidateMessageData(RestOfMessage);
        }

        public bool WroteHourAndMinutesByCountry(string[] LineOfRestOfMessage)
        {
            return ValidatorOfMessage.WroteHourAndMinutes(LineOfRestOfMessage);
        }

        public bool ValidateTimeOfPurchaseByCountry(int TimeOfPurchase)
        {
            return ValidatorOfMessage.ValideTimeOfPurchase(TimeOfPurchase);
        }

        public bool IsLengthOfMessageCorrectByCountry(int Length)
        {
            return ValidatorOfMessage.IsLengthOfMessageCorrect(Length);
        }

        public int CalculateFinalTimeOfPurchaseByCountry(int TimeOfPurchase, DateTime DateOfPurchase)
        {
            return ValidatorOfMessage.CalculateFinalTimeOfPurchase(TimeOfPurchase, DateOfPurchase);
        }

        public int AssignHourByCountry(string[] LineOfRestOfMessage)
        {
            return ValidatorOfMessage.AssignHour(LineOfRestOfMessage);
        }

        public int AssignMinutesByCountry(string[] LineOfRestOfMessage)
        {
            return ValidatorOfMessage.AssignMinutes(LineOfRestOfMessage);
        }

        public int AssignTimeByCountry(string[] LineOfRestOfMessage)
        {
            return ValidatorOfMessage.AssignTime(LineOfRestOfMessage);
        }
    }
}

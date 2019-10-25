using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class CountryHandler
    {
        public Country country { get; set; }
        private ValidatorOfPhone validatorOfPhone;
        private ValidatorOfMessage validatorOfMessage;

        public CountryHandler(Country actualCountry)
        {
            this.country = actualCountry;
        }

        private ValidatorOfPhone VerifyCountryForPhone()
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return new ValidatorOfPhoneInArgentina();
            else
                return new ValidatorOfPhoneInUruguay();
        }

        private ValidatorOfMessage VerifyCountryForMessage()
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return new ValidatorOfMessageInArgentina();
            else
                return new ValidatorOfMessageInUruguay();
        }

        public bool ValidateIsEmptyByCountry(string textOfPhone)
        {
            validatorOfPhone = VerifyCountryForPhone();
            return validatorOfPhone.ValidateIsEmpty(textOfPhone);           
        }

        public bool ValidateIsNumericByCountry(string textOfPhone)
        {
            validatorOfPhone = VerifyCountryForPhone();
            return validatorOfPhone.ValidateIsNumeric(textOfPhone);            
        }

        public bool ValidateFormatNumberByCountry(ref string textOfPhone)
        {
            validatorOfPhone = VerifyCountryForPhone();
            return validatorOfPhone.ValidateFormatNumber(ref textOfPhone);
        }

        public bool ValidateMessageDataByCountry(string restOfMessage)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.ValidateMessageData(restOfMessage);
        }

        public bool WroteHourAndMinutesByCountry(string[] lineOfRestOfMessage)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.WroteHourAndMinutes(lineOfRestOfMessage);
        }

        public bool ValidateTimeOfPurchaseByCountry(int timeOfPurchase)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.ValideTimeOfPurchase(timeOfPurchase);
        }

        public bool IsLengthOfMessageCorrectByCountry(int length)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.IsLengthOfMessageCorrect(length);
        }

        public int CalculateFinalTimeOfPurchaseByCountry(int timeOfPurchase, DateTime dateOfPurchse)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
        }

        public int AssignHour(string[] lineOfRestOfMessage)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.AssignHour(lineOfRestOfMessage);
        }

        public int AssignMinutes(string[] lineOfRestOfMessage)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.AssignMinutes(lineOfRestOfMessage);
        }

        public int AssignTime(string[] lineOfRestOfMessage)
        {
            validatorOfMessage = VerifyCountryForMessage();
            return validatorOfMessage.AssignTime(lineOfRestOfMessage);
        }
    }
}

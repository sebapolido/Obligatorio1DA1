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
        private ValidatorOfPhoneInArgentina validatorOfPhoneInArgentina = new ValidatorOfPhoneInArgentina();
        private ValidatorOfPhoneInUruguay validatorOfPhoneInUruguay = new ValidatorOfPhoneInUruguay();
        private ValidatorOfMessageInArgentina validatorOfMessageInArgentina = new ValidatorOfMessageInArgentina();
        private ValidatorOfMessageInUruguay validatorOfMessageInUruguay = new ValidatorOfMessageInUruguay();

        public CountryHandler(Country actualCountry)
        {
            this.country = actualCountry;
        }

        public bool ValidateIsEmptyByCountry(string textOfPhone)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))           
                return validatorOfPhoneInArgentina.ValidateIsEmpty(textOfPhone);
            else
                return validatorOfPhoneInUruguay.ValidateIsEmpty(textOfPhone);            
        }

        public bool ValidateIsNumericByCountry(string textOfPhone)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))            
                return validatorOfPhoneInArgentina.ValidateIsNumeric(textOfPhone);
            else
                return validatorOfPhoneInUruguay.ValidateIsNumeric(textOfPhone);
            
        }

        public bool ValidateFormatNumberByCountry(ref string textOfPhone)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfPhoneInArgentina.ValidateFormatNumber(ref textOfPhone);
            else
                return validatorOfPhoneInUruguay.ValidateFormatNumber(ref textOfPhone);
        }

        public bool ValidateMessageDataByCountry(string restOfMessage)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.ValidateMessageData(restOfMessage);
            else
                return validatorOfMessageInUruguay.ValidateMessageData(restOfMessage);
        }

        public bool WroteHourAndMinutesByCountry(string[] lineOfRestOfMessage)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.WroteHourAndMinutes(lineOfRestOfMessage);
            else
                return validatorOfMessageInUruguay.WroteHourAndMinutes(lineOfRestOfMessage);
        }

        public bool ValidateTimeOfPurchaseByCountry(int timeOfPurchase)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.ValideTimeOfPurchase(timeOfPurchase);
            else
                return validatorOfMessageInUruguay.ValideTimeOfPurchase(timeOfPurchase);
        }

        public bool IsLengthOfMessageCorrectByCountry(int length)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.IsLengthOfMessageCorrect(length);
            else
                return validatorOfMessageInUruguay.IsLengthOfMessageCorrect(length);
        }

        public int CalculateFinalTimeOfPurchaseByCountry(int timeOfPurchase, DateTime dateOfPurchse)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
            else
                return validatorOfMessageInUruguay.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
        }

        public int AssignHour(string[] lineOfRestOfMessage)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.AssignHour(lineOfRestOfMessage);
            else
                return validatorOfMessageInUruguay.AssignHour(lineOfRestOfMessage);
        }

        public int AssignMinutes(string[] lineOfRestOfMessage)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.AssignMinutes(lineOfRestOfMessage);
            else
                return validatorOfMessageInUruguay.AssignMinutes(lineOfRestOfMessage);
        }

        public int AssignTime(string[] lineOfRestOfMessage)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
                return validatorOfMessageInArgentina.AssignTime(lineOfRestOfMessage);
            else
                return validatorOfMessageInUruguay.AssignTime(lineOfRestOfMessage);
        }
    }
}

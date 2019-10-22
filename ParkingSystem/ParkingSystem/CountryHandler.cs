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

        public CountryHandler(Country actualCountry)
        {
            this.country = actualCountry;
        }

        public bool ValidateIsEmptyByCountry(string textOfPhone)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfPhoneInArgentina validator = new ValidatorOfPhoneInArgentina();
                return validator.ValidateIsEmpty(textOfPhone);
            }
            else
            {
                ValidatorOfPhoneInUruguay validator = new ValidatorOfPhoneInUruguay();
                return validator.ValidateIsEmpty(textOfPhone);
            }
        }

        public bool ValidateIsNumericByCountry(string textOfPhone)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfPhoneInArgentina validator = new ValidatorOfPhoneInArgentina();
                return validator.ValidateIsNumeric(textOfPhone);
            }
            else
            {
                ValidatorOfPhoneInUruguay validator = new ValidatorOfPhoneInUruguay();
                return validator.ValidateIsNumeric(textOfPhone);
            }
        }

        public bool ValidateFormatNumberByCountry(ref string textOfPhone)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfPhoneInArgentina validator = new ValidatorOfPhoneInArgentina();
                return validator.ValidateFormatNumber(ref textOfPhone);
            }
            else
            {
                ValidatorOfPhoneInUruguay validator = new ValidatorOfPhoneInUruguay();
                return validator.ValidateFormatNumber(ref textOfPhone);
            }
        }

        public bool ValidateMessageDataByCountry(string restOfMessage)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfMessageInArgentina validator = new ValidatorOfMessageInArgentina();
                return validator.ValidateMessageData(restOfMessage);
            }
            else
            {
                ValidatorOfMessageInUruguay validator = new ValidatorOfMessageInUruguay();
                return validator.ValidateMessageData(restOfMessage);
            }
        }

        public bool WroteHourAndMinutesByCountry(string[] lineOfRestOfMessage)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfMessageInArgentina validator = new ValidatorOfMessageInArgentina();
                return validator.WroteHourAndMinutes(lineOfRestOfMessage);
            }
            else
            {
                ValidatorOfMessageInUruguay validator = new ValidatorOfMessageInUruguay();
                return validator.WroteHourAndMinutes(lineOfRestOfMessage);
            }
        }

        public bool ValidateTimeOfPurchaseByCountry(int timeOfPurchase)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfMessageInArgentina validator = new ValidatorOfMessageInArgentina();
                return validator.ValideTimeOfPurchase(timeOfPurchase);
            }
            else
            {
                ValidatorOfMessageInUruguay validator = new ValidatorOfMessageInUruguay();
                return validator.ValideTimeOfPurchase(timeOfPurchase);
            }
        }

        public bool IsLengthOfMessageCorrectByCountry(int length)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfMessageInArgentina validator = new ValidatorOfMessageInArgentina();
                return validator.IsLengthOfMessageCorrect(length);
            }
            else
            {
                ValidatorOfMessageInUruguay validator = new ValidatorOfMessageInUruguay();
                return validator.IsLengthOfMessageCorrect(length);
            }
        }

        public int CalculateFinalTimeOfPurchaseByCountry(int timeOfPurchase, DateTime dateOfPurchse)
        {
            if (country.nameOfCountry.ToUpper().Equals("ARGENTINA"))
            {
                ValidatorOfMessageInArgentina validator = new ValidatorOfMessageInArgentina();
                return validator.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
            }
            else
            {
                ValidatorOfMessageInUruguay validator = new ValidatorOfMessageInUruguay();
                return validator.CalculateFinalTimeOfPurchase(timeOfPurchase, dateOfPurchse);
            }
        }
    }
}

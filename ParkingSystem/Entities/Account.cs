namespace ParkingSystem
{
    public class Account
    {
        public int AccountId { get; set; }
        public int Balance { get; set; }
        public string Mobile { get; set; }
        public CountryHandler Country { get; set; }
        
        public Account(int NewBalance, string NewMobile, CountryHandler NewCountry)
        {
            Balance = NewBalance;
            Mobile = NewMobile;
            Country = NewCountry;
        }

        public Account()
        {
            this.Balance = 0;
            this.Mobile = "";
        }

        public override string ToString()
        {
            return Mobile;
        }
    }
}

using System;

namespace ParkingSystem
{
    public class Country
    {
        public string nameOfCountry { get; set; }
        public int costForMinutes { get; set; }


        public Country(string newNameOfCountry, int newCostForMinutes)
        {
            nameOfCountry = newNameOfCountry;
            costForMinutes = newCostForMinutes;
        }
    }
}
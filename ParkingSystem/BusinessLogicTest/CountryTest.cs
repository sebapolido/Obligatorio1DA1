using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingSystem;

namespace BusinessLogicTest
{
    [TestClass]
    public class CountryTest
    {
        Country country;

        [TestCleanup]
        public void testClean()
        {
            country = null;
        }

        [TestInitialize]
        public void testInit()
        {
            country = new Country("Uruguay", 1);
        }

        [TestMethod]
        public void CreateCountryName()
        {
            Assert.AreEqual("Uruguay", country.nameOfCountry);
        }

        [TestMethod]
        public void CreateCountryCostForMinutes()
        {
            Assert.AreEqual(1, country.costForMinutes);
        }
    }
}

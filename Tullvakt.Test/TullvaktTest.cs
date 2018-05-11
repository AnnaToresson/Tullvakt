using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tullvakt.Test
{
    [TestClass]
    public class TullvaktTest
    {
        private readonly int excpectedPriceEco = 0;
        private double _expectedTotalPrice;


        [TestMethod]
        public void TestInput_Under1000kg()
        {
            var testFordon = new Vehicle(VehicleType.Motorcycle, new DateTime(2018, 05, 09), false,
                Weight.Under1000Kg);

            var actual = new CalculateToll().CalculateTotalTollPrice(testFordon);
            Assert.AreEqual(350, actual);
        }

        [TestMethod]
        public void TestCarInput_Eco()
        {
            var testFordon = new Vehicle(VehicleType.Car, DateTime.Today, true, Weight.Under1000Kg);
            var actual = new CalculateToll().CalculateTotalTollPrice(testFordon);
            Assert.AreEqual(excpectedPriceEco, actual);
        }

        [TestMethod]
        public void TestTruck_Sunday()
        {
            double expectedTotalPriceTruck_sunday = 4000;
            var testFordon = new Vehicle(VehicleType.Truck, new DateTime(2018, 05, 12), false, Weight.Over1000Kg);
            var actual = new CalculateToll().CalculateTotalTollPrice(testFordon);
            Assert.AreEqual(expectedTotalPriceTruck_sunday, actual);

           
            var testFordonEco = new Vehicle(VehicleType.Truck, new DateTime(2018, 05, 12), true, Weight.Over1000Kg);
            var actualEco = new CalculateToll().CalculateTotalTollPrice(testFordonEco);
            Assert.AreEqual(0, actualEco);
        }

        [TestMethod]
        public void TestCar_Heavy()
        {
            
            var testFordonEco = new Vehicle(VehicleType.Car, new DateTime(2018, 05, 11), true, Weight.Over1000Kg);
            var actualEco = new CalculateToll().CalculateTotalTollPrice(testFordonEco);
            Assert.AreEqual(0, actualEco);

            var testFordonSunday = new Vehicle(VehicleType.Car, new DateTime(2018, 05, 13), false,
                Weight.Over1000Kg);
            _expectedTotalPrice = 2000;
            var actual = new CalculateToll().CalculateTotalTollPrice(testFordonSunday);
            Assert.AreEqual(_expectedTotalPrice, actual);
        }
    }
}
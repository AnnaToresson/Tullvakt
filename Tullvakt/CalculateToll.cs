using System;

namespace Tullvakt
{
    public class CalculateToll
    {
        private double _price;
        private double _priceModifier;
        private double _totalTollPrice;

        private readonly double reducedPriceMotorcycle = 0.7;

        private const double PriceForTruck = 2000;
        private const double PriceOver1000Kg = 1000;
        private const double PriceUnder1000Kg = 500;
        private const double EcoVehiclePrice = 0;


        private const double LowTraffic = 0.5;
        private const double HolidayPrice = 2.0;


        public double CalculateTotalTollPrice(Vehicle vehicle)
        {
            _price = CalculatePrice(vehicle); 
            _priceModifier = CalculatePriceModifier(vehicle);
            _totalTollPrice = _price * _priceModifier;
            return _totalTollPrice;
        }

        public double CalculatePriceModifier(Vehicle vehicle)
        {
           // if (vehicle.IsEcoVehicle) return _priceModifier = EcoVehiclePrice;
            if (IsHoliday(vehicle.DateTime)) return _priceModifier = HolidayPrice;
            if (IsLowTraffic(vehicle.DateTime)) return _priceModifier = LowTraffic;
            return _priceModifier = 1;
            
        }

        private double CalculatePrice(Vehicle vehicle)
        {
            if (vehicle.IsEcoVehicle)
                return _price = 0;
            if (vehicle.VehicleType == VehicleType.Truck)
                _price = PriceForTruck;
            else if (vehicle.VehicleType == VehicleType.Motorcycle && vehicle.Weight == Weight.Over1000Kg)
                _price = reducedPriceMotorcycle * PriceOver1000Kg;
            else if (vehicle.VehicleType == VehicleType.Motorcycle && vehicle.Weight == Weight.Under1000Kg)
                _price = reducedPriceMotorcycle * PriceUnder1000Kg;
            else if (vehicle.VehicleType == VehicleType.Car && vehicle.Weight == Weight.Over1000Kg)
                _price = PriceOver1000Kg;
            else if (vehicle.VehicleType == VehicleType.Car && vehicle.Weight == Weight.Under1000Kg)
                _price = PriceUnder1000Kg;


            return _price;
        }

        public bool IsHoliday(DateTime dateTime)
        {
            if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
                return true;
            if (dateTime.DayOfYear == 157 || dateTime.DayOfYear == 360 || dateTime.DayOfYear == 359)
                return true;

            return false;
        }

        public bool IsLowTraffic(DateTime dateTime)
        {
            if (dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday &&
                dateTime.Hour > 18 && dateTime.Hour < 06) //inte lördag eller söndag och kl 18-6
                return true;
            return false;
        }
    }
}
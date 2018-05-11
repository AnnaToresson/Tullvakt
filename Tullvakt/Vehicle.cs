using System;

namespace Tullvakt
{
    public class Vehicle
    {
        public Vehicle(VehicleType vehicleType, DateTime dateTime, bool isEcoVehicle, Weight weight)
        {
            VehicleType = vehicleType;
            DateTime = dateTime;
            IsEcoVehicle = isEcoVehicle;
            Weight = weight;
        }

        public Vehicle Id { get; set; }
        public VehicleType VehicleType { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsEcoVehicle { get; set; }
        public Weight Weight { get; set; }
    }
}

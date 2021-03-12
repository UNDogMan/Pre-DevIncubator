using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator
{
    public class Vehicle : IComparable<Vehicle>
    {
        public VehicleType VehicleType { get; init; }
        public string ModelName { get; init; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; init; }
        public int Mileage { get; set; }
        public Color Color { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(
            VehicleType vehicleType, 
            string modelName, 
            string registrationNumber, 
            int weight, 
            int manufactureYear, 
            int mileage, 
            Color color
            )
        {
            VehicleType = vehicleType;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = color;
        }

        public override string ToString() => 
            $"{VehicleType}, {RegistrationNumber}, {Weight}, {ManufactureYear}, {Mileage}, {Color}";
        
        public double GetCalcTasPerMonth() => 
            Weight * 0.0013 + VehicleType.TaxCoefficient * 30 + 5;

        public int CompareTo(Vehicle other)
        {
            return GetCalcTasPerMonth().CompareTo(other.GetCalcTasPerMonth());
        }
    }
}

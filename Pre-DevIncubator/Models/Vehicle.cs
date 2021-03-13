using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pre_DevIncubator.Models.Engine;

namespace Pre_DevIncubator.Models
{
    public class Vehicle : IComparable<Vehicle>
    {
        public VehicleType VehicleType { get; init; }
        public AbstractEngine Engine { get; init; }
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
            AbstractEngine engine,
            string modelName, 
            string registrationNumber, 
            int weight, 
            int manufactureYear, 
            int mileage, 
            Color color
            )
        {
            VehicleType = vehicleType;
            Engine = engine;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = color;
        }

        public override string ToString() => 
            $"{VehicleType},{ModelName},{RegistrationNumber},{Weight},{ManufactureYear},{Mileage},{Color},{Engine}";
        
        public double GetCalcTasPerMonth() => 
            Weight * 0.0013 + VehicleType.TaxCoefficient * Engine.TaxCoefficient * 30 + 5;

        public int CompareTo(Vehicle other)
        {
            return GetCalcTasPerMonth().CompareTo(other.GetCalcTasPerMonth());
        }

        public override bool Equals(object obj)
        {
            return obj is Vehicle vehicle &&
                   VehicleType.Equals(vehicle.VehicleType) &&
                   Engine.Equals(vehicle.Engine) &&
                   ModelName == vehicle.ModelName &&
                   RegistrationNumber == vehicle.RegistrationNumber &&
                   Weight == vehicle.Weight &&
                   ManufactureYear == vehicle.ManufactureYear &&
                   Mileage == vehicle.Mileage &&
                   Color == vehicle.Color;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(VehicleType, Engine, ModelName, RegistrationNumber, Weight, ManufactureYear, Mileage, Color);
        }
    }
}

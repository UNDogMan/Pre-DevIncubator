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
        public VehicleType VehicleType { get; set; }
        public AbstractEngine Engine { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; set; }
        public int Mileage { get; set; }
        public Color Color { get; set; }
        public double TankCapacity { get; set; }

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
            Color color,
            double tankCapacity
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
            TankCapacity = tankCapacity;
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
            HashCode hash = new HashCode();
            hash.Add(VehicleType);
            hash.Add(Engine);
            hash.Add(ModelName);
            hash.Add(RegistrationNumber);
            hash.Add(Weight);
            hash.Add(ManufactureYear);
            hash.Add(Mileage);
            hash.Add(Color);
            hash.Add(TankCapacity);
            return hash.ToHashCode();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator
{
    public class Vehicle : IComparable<Vehicle>
    {
        private readonly VehicleType vehicleType;
        private readonly string modelName;
        private string registrationNumber;
        private int weight;
        private readonly int manufactureYear;
        private int mileage;
        private Color color;

        public VehicleType VehicleType => vehicleType;

        public string ModelName => modelName;

        public string RegistrationNumber { get => registrationNumber; set => registrationNumber = value; }
        public int Weight { get => weight; set => weight = value; }

        public int ManufactureYear => manufactureYear;

        public int Mileage { get => mileage; set => mileage = value; }
        public Color Color { get => color; set => color = value; }

        public Vehicle()
        {
            vehicleType = new VehicleType();
            modelName = string.Empty;
            registrationNumber = string.Empty;
            weight = 0;
            manufactureYear = 0;
            mileage = 0;
            color = Color.Blue;
        }

        public Vehicle(VehicleType vehicleType, string modelName, string registrationNumber, int weight, int manufactureYear, int mileage, Color color)
        {
            this.vehicleType = vehicleType;
            this.modelName = modelName;
            this.registrationNumber = registrationNumber;
            this.weight = weight;
            this.manufactureYear = manufactureYear;
            this.mileage = mileage;
            this.color = color;
        }

        public override string ToString()
        {
            return $"{vehicleType}, \"{registrationNumber}\", {weight}, {manufactureYear}, {mileage}, {color}";
        }
        public double GetCalcTasPerMonth() => 
            weight * 0.0013 + vehicleType.TaxCoefficient * 30 + 5;

        public int CompareTo(Vehicle other)
        {
            return this.GetCalcTasPerMonth().CompareTo(other.GetCalcTasPerMonth());
        }
    }
}

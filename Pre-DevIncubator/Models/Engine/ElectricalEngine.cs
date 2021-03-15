using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models.Engine
{
    public class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; set; }
        public int HorsePowers { get; set; }

        public ElectricalEngine(double electricityConsumption, int battaryCapacity)
            : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
            HorsePowers = battaryCapacity;
        }

        public override double GetMaxKilometers(double batterySize)
            => batterySize / ElectricityConsumption;

        public override string ToString() => $"Electrical,,\"{ElectricityConsumption}\",{HorsePowers}";

        public override bool Equals(object obj)
        {
            return obj is ElectricalEngine engine &&
                   ElectricityConsumption == engine.ElectricityConsumption &&
                   HorsePowers == engine.HorsePowers;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ElectricityConsumption, HorsePowers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models.Engine
{
    public class ElectricalEngine : AbstractEngine
    {
        public double ElectricityConsumption { get; init; }
        public int HorsePowers { get; set; }

        public ElectricalEngine(double electricityConsumption, int horsePowers):
            base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
            HorsePowers = horsePowers;
        }

        public double GetMaxKilometers(double batterySize) 
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

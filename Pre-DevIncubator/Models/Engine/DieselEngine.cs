using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models.Engine
{
    public class DieselEngine : CombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100, int horsePowers)
            : base("Diesel", 1.2)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
            HorsePowers = horsePowers;
        }
    }
}

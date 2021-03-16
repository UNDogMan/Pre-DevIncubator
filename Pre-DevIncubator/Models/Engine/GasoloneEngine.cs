using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models.Engine
{
    public class GasoloneEngine : CombustionEngine
    {
        public GasoloneEngine(double engineCapacity, double fuelConsumptionPer100, int horsePowers)
            : base("Gasolone", 1)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
            HorsePowers = horsePowers;
        }
        
    }
}

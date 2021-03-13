using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models.Engine
{
    public class CombustionEngine : AbstractEngine
    {
        public double EngineCapacity { get; set; }
        public double FuelConsumptionPer100 { get; set; }
        public int HorsePowers { get; set; }
        public CombustionEngine(string typeName, double taxCoefficient) :
            base(typeName, taxCoefficient) { }

        public override string ToString()
            => $"{Model},\"{EngineCapacity}\",\"{FuelConsumptionPer100}\",{HorsePowers}";

        public override bool Equals(object obj)
        {
            return obj is CombustionEngine engine &&
                   EngineCapacity == engine.EngineCapacity &&
                   FuelConsumptionPer100 == engine.FuelConsumptionPer100 &&
                   HorsePowers == engine.HorsePowers && 
                   TaxCoefficient == engine.TaxCoefficient &&
                   Model == engine.Model;
        }

        public override int GetHashCode() => 
            HashCode.Combine(Model, TaxCoefficient, EngineCapacity, FuelConsumptionPer100, HorsePowers);

        public override double GetMaxKilometers(double fuelTank)
            => fuelTank * 100 / FuelConsumptionPer100;
    }
}


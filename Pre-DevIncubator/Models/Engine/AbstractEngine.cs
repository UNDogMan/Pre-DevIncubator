using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models.Engine
{
    public abstract class AbstractEngine
    {
        public string Model { get; set; }
        public double TaxCoefficient { get; set; }

        public AbstractEngine(string model, double taxCoefficient)
        {
            Model = model;
            TaxCoefficient = taxCoefficient;
        }

        public abstract double GetMaxKilometers(double fuelTank);
    }
}

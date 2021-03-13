using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models.Engine
{
    public class AbstractEngine
    {
        public string Model { get; init; }
        public double TaxCoefficient { get; set; }

        public AbstractEngine(string model, double taxCoefficient)
        {
            Model = model;
            TaxCoefficient = taxCoefficient;
        }
    }
}

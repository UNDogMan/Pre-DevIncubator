using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator
{
    public class VehicleType
    {
        private string typeName;
        private double taxCoefficient;

        public string TypeName { get => typeName; set => typeName = value; }
        public double TaxCoefficient { get => taxCoefficient; set => taxCoefficient = value; }
    
        public VehicleType()
        {
            typeName = string.Empty;
            taxCoefficient = 0d;
        }

        public VehicleType(string typeName, double taxCoefficient)
        {
            this.typeName = typeName;
            this.taxCoefficient = taxCoefficient;
        }

        public void Display()
        {
            Console.WriteLine($"TypeName = {TypeName}\nTaxCoefficient = {TaxCoefficient}");
        }

        public override string ToString()
        {
            return $"{TypeName}, \"{TaxCoefficient}\"";
        }
    }
}

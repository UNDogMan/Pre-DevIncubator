using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator
{
    public class VehicleType
    {
        public string TypeName { get;  set; }
        public double TaxCoefficient { get; set; }
    
        public VehicleType()
        {

        }

        public VehicleType(string typeName, double taxCoefficient)
        {
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
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

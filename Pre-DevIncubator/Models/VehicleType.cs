using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.Models
{
    public class VehicleType
    {
        public int ID { get; set; }
        public string TypeName { get;  set; }
        public double TaxCoefficient { get; set; }
    
        public VehicleType()
        {

        }

        public VehicleType(int id, string typeName, double taxCoefficient)
        {
            ID = id;
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

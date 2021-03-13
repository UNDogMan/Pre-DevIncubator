using System;
using System.Linq;
using Pre_DevIncubator.Models;

namespace Pre_DevIncubator
{
    class Program
    {
        static void Main(string[] args)
        {

            VehicleType[] vehicleTypes =
                {
                    new VehicleType("Bus", 1.2),
                    new VehicleType("Car", 1),
                    new VehicleType("Rink", 1.5),
                    new VehicleType("Tractor", 1.2),
                };

            double sumTax = vehicleTypes[0].TaxCoefficient;
            VehicleType maxTaxVehicleType = vehicleTypes[0];
            for(int i = 1; i < vehicleTypes.Length; ++i)
            {
                vehicleTypes[i].Display();
                if (i == vehicleTypes.Length - 1)
                    vehicleTypes[i].TaxCoefficient = 1.3;
                if (maxTaxVehicleType.TaxCoefficient < vehicleTypes[i].TaxCoefficient)
                    maxTaxVehicleType = vehicleTypes[i];
                sumTax += vehicleTypes[i].TaxCoefficient;
            }

            Console.WriteLine($"Max TaxCofficient VehicleType is {maxTaxVehicleType}");
            Console.WriteLine($"Averrage TaxCofficient is {sumTax / vehicleTypes.Length}");

            foreach(VehicleType vehicleType in vehicleTypes)
            {
                Console.WriteLine(vehicleType.ToString());
            }

            Vehicle[] vehicles =
            {
                new Vehicle(vehicleTypes[0], new GasoloneEngine(2, 8.1, 75), "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, Color.Blue),
                new Vehicle(vehicleTypes[0], new GasoloneEngine(2.18, 8.5, 75),"Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227000, Color.White),
                new Vehicle(vehicleTypes[0], new ElectricalEngine(50, 150),"Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, Color.Green),
                new Vehicle(vehicleTypes[1], new DieselEngine(1.6, 7.2, 55),"Golf 5", "8682 AX-7", 1200, 2006, 230451, Color.Gray),
                new Vehicle(vehicleTypes[1], new ElectricalEngine(25, 70),"Tesla Model S 70D", "E001 AX-7", 2200, 2019, 10454, Color.Whit),
                new Vehicle(vehicleTypes[2], new DieselEngine(3.2, 25, 20),"Hamm HD 12 VV", null, 3000, 2016, 122, Color.Yellow),
                new Vehicle(vehicleTypes[3], new DieselEngine(4.75, 20.1, 135),"МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red),
                new Vehicle(vehicleTypes[3], new DieselEngine(4.75, 20.1, 135),"МТЗ Беларус-1025.4", "1145 AB-7", 1200, 2020, 109, Color.Red),
            };

            vehicles.PrintAllToConsole();
            Array.Sort(vehicles);
            vehicles.PrintAllToConsole();

            Console.WriteLine($"Min Mileage Vehicle is {vehicles.Min(x => x.Mileage)}");
            Console.WriteLine($"Max Mileage Vehicle is {vehicles.Max(x => x.Mileage)}");


            var query = vehicles.GroupBy(x => x).Where(g => g.Count() > 1).Select(y => new { Vehicle = y.Key, Count = y.Count() });
            Console.WriteLine("Same Vehicle are : ");
            query.PrintAllToConsole();
        }
    }
}

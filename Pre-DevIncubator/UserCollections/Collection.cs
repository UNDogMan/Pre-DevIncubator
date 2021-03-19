using Pre_DevIncubator.Models;
using Pre_DevIncubator.Models.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator.UserCollections
{
    class Collection
    {
        public List<VehicleType> VehicleTypes { get; private set; }
        public List<Vehicle> Vehicles { get; private set; }

        public Collection(string typesFile, string vehiclesFile, string rentsFile)
        {
            VehicleTypes = LoadTypes(typesFile);
            Vehicles = LoadVehicles(vehiclesFile);
            LoadRents(rentsFile);
        }

        public VehicleType CreateType(string csvString)
        {
            NumberFormatInfo format = new NumberFormatInfo() { NumberDecimalSeparator = "."};
            string[] data = csvString.Split(',');
            return new VehicleType(
                int.Parse(data[0]),
                data[1],
                double.Parse(data[2], format));
        }

        public Vehicle CreateVehicle(string csvString)
        {
            NumberFormatInfo format = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            string[] data = csvString.Split(',');
            Vehicle vehicle = new Vehicle();
            vehicle.ID = int.Parse(data[0]);
            vehicle.VehicleType = VehicleTypes.First(x => x.ID == int.Parse(data[1]));
            vehicle.ModelName = data[2];
            vehicle.RegistrationNumber = data[3];
            vehicle.Weight = int.Parse(data[4]);
            vehicle.ManufactureYear = int.Parse(data[5]);
            vehicle.Mileage = int.Parse(data[6]);
            vehicle.Color = (Color)Enum.Parse(typeof(Color), data[7]);
            vehicle.TankCapacity = double.Parse(data[11], format);
            switch (data[8])
            {
                case "Gasoline":
                    vehicle.Engine = new GasoloneEngine(double.Parse(data[9], format), double.Parse(data[10], format), int.Parse(data[11], format));
                    break;
                case "Diesel":
                    vehicle.Engine = new DieselEngine(double.Parse(data[9], format), double.Parse(data[10], format), int.Parse(data[11], format));
                    break;
                case "Electrical":
                    vehicle.Engine = new ElectricalEngine(double.Parse(data[10], format), int.Parse(data[11], format));
                    break;
            }
            return vehicle;
        }

        List<VehicleType> LoadTypes(string inFile)
        {
            string[] lines;
            List<VehicleType> loadedVehicleTypes = new List<VehicleType>();
            if(File.Exists(inFile) && (lines = File.ReadAllLines(inFile)).Count() != 0)
            {
                foreach(string line in lines)
                {
                    loadedVehicleTypes.Add(this.CreateType(line));
                }
            }
            return loadedVehicleTypes;
        }

        List<Vehicle> LoadVehicles(string inFile)
        {
            List<Vehicle> loadedVehicles = new List<Vehicle>();
            string[] lines;
            if (File.Exists(inFile) && (lines = File.ReadAllLines(inFile)).Count() != 0)
            {
                foreach (string line in lines)
                {
                    loadedVehicles.Add(CreateVehicle(line));
                }
            }
            return loadedVehicles;
        }

        void LoadRents(string inFile)
        {
            NumberFormatInfo format = new NumberFormatInfo() { NumberDecimalSeparator = "." };
            string[] lines;
            if (File.Exists(inFile) && (lines = File.ReadAllLines(inFile)).Count() != 0)
            {
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    Vehicles.First(x => x.ID == int.Parse(data[0])).Rents.Add(new Rent(
                        DateTime.Parse(data[1]),
                        double.Parse(data[2], format)));
                }
            }
        }
        public void Insert(int index, Vehicle v)
        {
            Vehicles.Insert(index, v);
        }

        public int Delete(int index)
        {
            if (Vehicles.Count <= index)
                return -1;
            Vehicles.RemoveAt(index);
            return index;
        }

        public double SumTotalProfit() =>
            Vehicles.Sum(x => x.GetTotalProfit());

        public void Print()
        {
            Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                          "ID",
                          "Type",
                          "ModelName",
                          "RegistrationNumber",
                          "Weight",
                          "Year",
                          "Mileage",
                          "Color",
                          "Income",
                          "Tax",
                          "Profit");
            foreach (Vehicle vehicle in Vehicles)
            {
                Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}", 
                    vehicle.ID,
                    vehicle.VehicleType.TypeName,
                    vehicle.ModelName,
                    vehicle.RegistrationNumber,
                    vehicle.Weight,
                    vehicle.ManufactureYear,
                    vehicle.Mileage,
                    vehicle.Color,
                    vehicle.GetTotalIncome().ToString("0.00"),
                    vehicle.GetCalcTasPerMonth().ToString("0.00"),
                    vehicle.GetTotalProfit().ToString("0.00"));
            }
            Console.WriteLine("Total {0, 120}", SumTotalProfit().ToString("0.00"));
        }

        public void Sort(IComparer<Vehicle> comparer)
        {
            Vehicles.Sort(comparer);
        }
    }
}

using Autopark.Vehicle;
using Autopark.Engine;
using System.Globalization;

namespace Autopark
{
    public sealed class Collections
    {
        public Collections(
            string vehiclesTypesPath,
            string vehiclePath,
            string rentsPath
            )
        {
            try
            {
                _vehicleTypes = ParseVehicleTypes(vehiclesTypesPath);
                LoadRents(rentsPath);
                _vehicles = ParseVehicles(vehiclePath);
            }
            catch (FormatException)
            { }
            catch (FileNotFoundException)
            { }
        }
        public List<VehicleType> ParseVehicleTypes(string path)
        {
            List<VehicleType> vehicleTypes = new List<VehicleType>();
            if (File.Exists(path))
            {
                foreach (var csvString in File.ReadLines(path, System.Text.Encoding.Unicode))
                {
                    try
                    {
                        vehicleTypes.Add(CreateVehicleType(csvString));
                    }
                    catch (FormatException)
                    {
                        throw;
                    }
                }
            }
            else
                throw new FileNotFoundException($"File with {path} name doesn't exists");

            return vehicleTypes;
        }
        public List<Vehicle.Vehicle> ParseVehicles(string path)
        {
            List<Vehicle.Vehicle> vehicles = new List<Vehicle.Vehicle>();
            if (File.Exists(path))
            {
                foreach (var csvString in File.ReadLines(path))
                {
                    try
                    {
                        vehicles.Add(CreateVehicle(csvString));
                    }
                    catch (FormatException)
                    {
                        throw;
                    }
                }
            }
            else
                throw new FileNotFoundException($"File with {path} name doesn't exists");

            return vehicles;
        }
        public void LoadRents(string path)
        {
            if (File.Exists(path))
            {
                foreach (var csvString in File.ReadLines(path))
                {
                    _rents.Add(_createRent(csvString));
                }
            }
            else
                throw new FileNotFoundException($"File with {path} name doesn't exists");

        }
        public VehicleType CreateVehicleType(string csvString)
        {
            string[] values = csvString.Split(',');

            try
            {
                return new VehicleType(
                    Convert.ToInt32(values[0]),
                    values[1],
                    Convert.ToDouble(values[2])
                    );
            }
            catch (InvalidCastException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
            catch (IndexOutOfRangeException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
        }
        public Vehicle.Vehicle CreateVehicle(string csvString)
        {
            Vehicle.Vehicle vehicle = new Vehicle.Vehicle();
            string[] values = csvString.Split(",");
            double? engineCapacity;
            try
            {
                engineCapacity = Convert.ToDouble(values[9]);
            }
            catch (FormatException)
            {
                engineCapacity=null;
            }
            Engine.Engine engine = EngineFactory.CreateInstance(
                    (Engine.Engine.EngineTypes)Enum.Parse(typeof(Engine.Engine.EngineTypes), values[8], true),
                    Convert.ToDouble(values[10]),
                    engineCapacity
                );
            try
            {
                vehicle = new Vehicle.Vehicle(
                    Convert.ToInt32(values[0]),
                    _vehicleTypes.First(item => item.Id == Convert.ToInt32(values[1])),
                    values[2],
                    values[3],
                    Convert.ToInt32(values[4]),
                    Convert.ToInt32(values[5]),
                    Convert.ToDouble(values[6]),
                    (Colors)Enum.Parse(typeof(Colors), values[7], true),
                    engine,
                    Convert.ToDouble(values[11])
                    );
            }
            catch (IndexOutOfRangeException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
            catch (InvalidCastException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
            catch (NullReferenceException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
            catch (ArgumentException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
            foreach (var rent in _rents)
            {
                if (rent.Id == vehicle.Id)
                {
                    vehicle.Orders.Add(rent);
                }
            }

            return vehicle;
        }
        public void InsertVehicle(int index, Vehicle.Vehicle vehicle)
        {
            try
            {
                _vehicles.Insert(index, vehicle);
            }
            catch (ArgumentOutOfRangeException)
            {
                _vehicles.Add(vehicle);
            }
        }
        public bool DeleteVehicle(int index)
        {
            try
            {
                _vehicles.RemoveAt(index);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
        public double SumTotalProfit()
        {
            double sum = 0.0;
            foreach (var vehicle in _vehicles)
            {
                sum +=vehicle.GetTotalProfit();
            }

            return sum;
        }
        public void Print()
        {
            foreach (var vehicle in _vehicles)
            {
                Console.WriteLine("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                    vehicle.Id,
                    vehicle.Type.TypeName,
                    vehicle.Model,
                    vehicle.RegistrationNumber,
                    vehicle.Weight,
                    vehicle.ManufactureYear,
                    vehicle.Mileage,
                    vehicle.Color.ToString(),
                    vehicle.GetTotalIncome().ToString("0.00"),
                    vehicle.GetCalcTaxPerMonth().ToString("0.00"),
                    vehicle.GetTotalProfit().ToString("0.00"));
            }

        }
        public void Sort(IComparer<Vehicle.Vehicle> comparator) =>
            _vehicles.Sort(comparator);
        private Rent _createRent(string csvString)
        {
            string[] values = csvString.Split(",");
            try
            {
                return new Rent(
                        Convert.ToInt32(values[0]),
                        DateTime.ParseExact(values[1], "dd.MM.yyyy", CultureInfo.CurrentCulture),
                        Convert.ToDouble(values[2])
                    );
            }
            catch (IndexOutOfRangeException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
            catch (InvalidCastException)
            {
                throw new FormatException($"File {csvString} has incorrect format");
            }
        }

        private List<VehicleType> _vehicleTypes = new List<VehicleType>();

        private List<Vehicle.Vehicle> _vehicles = new List<Vehicle.Vehicle>();

        private List<Rent> _rents = new List<Rent>();
    }
}

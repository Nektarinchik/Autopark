using Autopark;
using Autopark.Engine;
using Autopark.Vehicle;
using System.Collections;
using System.Globalization;

static void PrintVehicles(IEnumerable<Vehicle> items)
{
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static List<Vehicle> GetDublicates(Vehicle[] vehicles)
{
    List<Vehicle> dublicates = new List<Vehicle>();
    Dictionary<Vehicle, bool> uniques = new Dictionary<Vehicle, bool>();
    foreach (var vehicle in vehicles)
    {
        try
        {
            uniques.Add(vehicle, true);
        }
        catch (ArgumentException)
        {
            dublicates.Add(vehicle);
        }
    }

    return dublicates;
}

CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

// LEVEL 1
Console.WriteLine();
Console.WriteLine("----------------LEVEL 1-----------------");
Console.WriteLine();
// 1 part
VehicleType[] vehicles = new VehicleType[4];
vehicles[0] = (new VehicleType(1, "Bus", 1.2));
vehicles[1] = (new VehicleType(2, "Car", 1.0));
vehicles[2] = (new VehicleType(3, "Rink", 1.5));
vehicles[3] = (new VehicleType(4, "Tractor", 1.2));
// 1 part

//3 part
vehicles[3].TaxCoefficient = 1.3;
//3 part

// 2, 4, 5, 6 part
double? max = vehicles[0].TaxCoefficient;
double? sum = 0.0;
foreach (var vehicle in vehicles) 
{
    vehicle.Display();
    max = vehicle.TaxCoefficient > max ? vehicle.TaxCoefficient : max;
    sum += vehicle.TaxCoefficient;
}
Console.WriteLine($"Max tax = {max}");
double? average = sum / vehicles.Length;
Console.WriteLine($"Average tax coefficient = {average}");
// 2, 4, 5, 6 part

// 7 part
foreach (var vehicle in vehicles)
{
    Console.WriteLine(vehicle);
}
// 7 part

// LEVEL 2
Console.WriteLine();
Console.WriteLine("----------------LEVEL 2-----------------");
Console.WriteLine();
// 1, 2 part 
Vehicle[] vehicles1 = new Vehicle[]
{
    new Vehicle(1, vehicles[0], "Volkswagen Crafter", "5427 AX-7",
    2022, 2015, 376000.0, Colors.BLUE, new GasolineEngine(2, 8.1), 75.0
    ),
    new Vehicle(2, vehicles[0], "Volkswagen Crafter", "6427 AA-7",
    2500, 2014, 227010.0, Colors.WHITE, new GasolineEngine(2.18, 8.5), 75.0
    ),
    new Vehicle(3, vehicles[0], "Electric Bus E321", "6785 BA-7",
    12080, 2019, 20451.0, Colors.GREEN, new ElectricalEngine(50), 150.0
    ),
    new Vehicle(4, vehicles[1], "Golf 5", "8682 AX-7",
    1200, 2006, 230451.0, Colors.GRAY, new DieselEngine(1.6, 7.2), 55.0
    ),
    new Vehicle(5, vehicles[1], "Tesla Model S 70D", "E001 AA-7",
    2200, 2019, 10454.0, Colors.WHITE, new ElectricalEngine(25), 70.0
    ),
    new Vehicle(6, vehicles[2], "Hamm HD 12 VV", null,
    3000, 2016, 122.0, Colors.YELLOW, new DieselEngine(3.2, 25), 20.0
    ),
    new Vehicle(7, vehicles[3], "МТЗ Беларус-1025.4", "1145 AB-7",
    1200, 2020, 109.0, Colors.RED, new DieselEngine(4.75, 20.1), 135.0
    )
};
// 1, 2 part


// 3 part
PrintVehicles(vehicles1);
// 3 part
Console.WriteLine();

// 4, 5 part
Array.Sort(vehicles1);
PrintVehicles(vehicles1);
// 4, 5 part

// 6 part
Console.WriteLine($"Max mileage: {vehicles1.Max(item => item.Mileage)}");

Console.WriteLine($"Min mileage: {vehicles1.Min(item => item.Mileage)}");
// 6 part

// LEVEL 3
Console.WriteLine();
Console.WriteLine("----------------LEVEL 2-----------------");
Console.WriteLine();
// 3 part
PrintVehicles(vehicles1);
// 3 part
Console.WriteLine();

// 4 part
List<Vehicle> dublicates = GetDublicates(vehicles1);
Console.WriteLine("Dublicates:");
PrintVehicles(dublicates);
// 4 part

// LEVEL 4
Console.WriteLine();
Console.WriteLine("----------------LEVEL 4-----------------");
Console.WriteLine();
var maxMileageVehicles = vehicles1.OrderBy(item => item?.Engine?.GetMaxKilometers(item.TankCapacity)).Take(1);
Console.WriteLine("Car thar can drive max distance on full tank:");
foreach (var vehicle in maxMileageVehicles)
    Console.WriteLine(vehicle);

// LEVEL 5
string relativeVehiclesPath = @"Files\vehicles.csv";
string relativeVehiclesTypesPath = @"Files\types.csv";
string relativeRentsPath = @"Files\rents.csv";

Collections collection = new Collections(relativeVehiclesTypesPath, relativeVehiclesPath, relativeRentsPath);

collection.InsertVehicle(-1,
    new Vehicle(
        8,
        new VehicleType(2, "Car", 1.0),
        "Mercedes W211",
        "6582 EP-2",
        1800,
        2009,
        177000,
        Colors.WHITE,
        new DieselEngine(3.0, 10.0),
        80.0
        )
    );
collection.DeleteVehicle(1);
collection.DeleteVehicle(4);
collection.Print();
Console.WriteLine();
collection.Sort(new VehiclesModelAscendingComparer());
collection.Print();

// LEVEL 5

// LEVEL 6
Console.WriteLine();
Console.WriteLine("----------------LEVEL 6-----------------");
Console.WriteLine();
List<Vehicle> vehiclesFromFile = collection.ParseVehicles(relativeVehiclesPath);

var carWash = new Autopark.CustomCollections.Queue<Vehicle>();
foreach (var item in vehiclesFromFile)
{
    Console.WriteLine(item.ToString() + " - enter the wash");
    carWash.Enqueue(item);
}
while (true)
{
    try
    {
        Console.WriteLine(carWash.Dequeue() + " - is washed");
    }
    catch (IndexOutOfRangeException)
    {
        break;
    }
}

// LEVEL 6

// LEVEL 7 
Console.WriteLine();
Console.WriteLine("----------------LEVEL 7-----------------");
Console.WriteLine();

var garage = new Autopark.CustomCollections.Stack<Vehicle>();
foreach (var item in vehiclesFromFile)
{
    Console.WriteLine(item.ToString() + " - enter the garage");
    garage.Push(item);
}
while (garage.Length != 0)
{
    Console.WriteLine(garage.Pop().ToString() + " - exit from the garage");
}
// LEVEL 7

// LEVEL 8
Console.WriteLine();
Console.WriteLine("----------------LEVEL 8-----------------");
Console.WriteLine();
string relativeOrdersPath = @"Files\orders.csv";
var orders = new Autopark.CustomCollections.CustomDictionary(relativeOrdersPath);
orders.Print();


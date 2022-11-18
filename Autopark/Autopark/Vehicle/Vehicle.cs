using Autopark.Engine;

namespace Autopark.Vehicle
{
    public class Vehicle : IComparable<Vehicle>, IEquatable<Vehicle>
    {
        public int Id { get; private set; }
        public List<Rent> Orders { get; private set; } = new List<Rent>();
        public Engine.Engine? Engine { get; set; }
        public int Weight { get; set; }
        public string? RegistrationNumber { get; set; }
        public string Model { get; } = "";
        public VehicleType Type { get; set; } = new VehicleType();
        public int ManufactureYear { get; }
        public double Mileage { get; set; }
        public Colors Color { get; set; } = Colors.DEFAULT;
        public double TankCapacity { get; set; }
        public Vehicle()
        { }
        public Vehicle(
            int id, VehicleType type, string model, string? registrationNumber,
            int weight, int manufactureYear, double mileage,
            Colors color, Engine.Engine engine, double tankCapacity
            )
        {
            Id = id;
            Weight = weight;
            RegistrationNumber = registrationNumber;
            Model = model;
            Type = type;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            Color = color;
            TankCapacity = tankCapacity;
            Engine = engine;
        }
        public int CompareTo(Vehicle? obj)
        {
            if (obj == null) throw new NullReferenceException("argument is null");
            double? leftTax = GetCalcTaxPerMonth();
            double? rightTax = obj.GetCalcTaxPerMonth();
            if (leftTax == rightTax) return 0;
            else if (leftTax > rightTax) return 1;
            else return -1;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;

            try
            {
                return Equals((Vehicle)obj);
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
        public bool Equals(Vehicle? other)
        {
            if (other == null) return false;

            if (other == this) return true;

            if (Model == null || Type == null)
                return false;
            else
                if (Model.Equals(other.Model) && Type.Equals(other.Type)) return true;

            return false;
        }
        public double GetCalcTaxPerMonth()
        {
            if (ReferenceEquals(Engine, null))
                throw new NullReferenceException($"{nameof(Engine)} is null");

            return Weight * Constants.weightCoefficient +
                Type.TaxCoefficient * Constants.coefficientOnTaxCoefficient * Engine.Coefficient +
                Constants.taxPerMonthAddingValue;
        }
        public override string ToString()
        {
            string? buffColor = Color.ToString();
            return $"\"{Weight}\", {RegistrationNumber}, {Model}, {Type}, " +
                $"\"{ManufactureYear}\", \"{Mileage}\", {buffColor}, \"{TankCapacity}\", " +
                $"\"{GetCalcTaxPerMonth()}\"";
        }
        public override int GetHashCode()
        {
            if (!ReferenceEquals(null, Model) && !ReferenceEquals(null, Type))
            {
                int hashCode = Model.GetHashCode() + Type.GetHashCode();
                return hashCode;
            }

            return 0;
        }
        public double GetTotalIncome() => Orders.Sum(order => order.Cost);
        public double GetTotalProfit() => GetTotalIncome() - GetCalcTaxPerMonth();

    }
}

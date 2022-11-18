namespace Autopark.Vehicle
{
    public class VehicleType : IEquatable<VehicleType>
    {
        public int Id { get; private set; }
        public string TypeName { get; set; } = "";
        public double TaxCoefficient { get; set; }
        public VehicleType()
        { }
        public VehicleType(int id, string typeName, double taxCoefficient = 1.0)
        {
            Id = id;
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }
        public void Display()
        {
            Console.WriteLine($"TypeName: {TypeName} TaxCoefficient: {TaxCoefficient}");
        }
        public override string ToString() => $"{TypeName}, \"{TaxCoefficient}\"";

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            try
            {
                return Equals((VehicleType)obj);
            }
            catch (InvalidCastException)
            {
                return false;
            }
        }
        public bool Equals(VehicleType? other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            if (TypeName == null)
                return false;
            else
                if (TypeName.Equals(other.TypeName) && TaxCoefficient.Equals(other.TaxCoefficient))
                return true;

            return false;
        }
        public override int GetHashCode()
        {
            if (!ReferenceEquals(null, TypeName))
                return TaxCoefficient.GetHashCode() + TypeName.GetHashCode();

            return 0;
        }

    }
}

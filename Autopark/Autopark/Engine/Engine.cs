using System.ComponentModel;

namespace Autopark.Engine
{
    public abstract class Engine
    {
        public EngineTypes Type { get; private set; }
        public double Coefficient { get; private set; }
        public Engine(EngineTypes engineType, double coefficient)
        {
            Type = engineType;
            Coefficient = coefficient;
        }
        public enum EngineTypes
        {
            [Description("Electrical")]
            ELECTRICAL,

            [Description("Diesel")]
            DIESEL,

            [Description("Gasoline")]
            GASOLINE
        }

        public abstract double GetMaxKilometers(double fuelTank);

    }
}

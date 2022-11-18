namespace Autopark.Engine
{
    public sealed class DieselEngine : CombustionEngine
    {
        public override double EngineCapacity
        {
            get => engineCapacity;
            protected set
            {
                if (value <= 0.0) throw new ArgumentException("Engine capacity must be positive number");
                engineCapacity = value;
            }
        }
        public override double FuelConsumption
        {
            get => fuelConsumption;
            protected set
            {
                if (value <= 0.0) throw new ArgumentException("Fuel consumption must be positive number");
                fuelConsumption = value;
            }
        }
        public DieselEngine(double engineCapacity, double fuelConsumption) : 
            base(EngineTypes.DIESEL, Constants.dieselEngineCoefficient)
        {
            EngineCapacity = engineCapacity;
            FuelConsumption = fuelConsumption;
        }

    }
}

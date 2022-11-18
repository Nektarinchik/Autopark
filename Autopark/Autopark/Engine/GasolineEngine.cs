using Autopark;

namespace Autopark.Engine
{
    public sealed class GasolineEngine : CombustionEngine
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
        public GasolineEngine(double engineCapacity, double fuelConsumption) : 
            base(EngineTypes.GASOLINE, Constants.gasolineEngineCoefficient)
        {
            EngineCapacity = engineCapacity;
            FuelConsumption = fuelConsumption;
        }

    }
}

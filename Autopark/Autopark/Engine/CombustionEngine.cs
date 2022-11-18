namespace Autopark.Engine
{
    public abstract class CombustionEngine : Engine
    {
        public abstract double EngineCapacity { get; protected set; }
        public abstract double FuelConsumption { get; protected set; }
        public CombustionEngine(EngineTypes engineType, double coefficient)
            : base(engineType, coefficient) { }
        public override double GetMaxKilometers(double fuelCapacity) => (fuelCapacity / FuelConsumption) * 100;

        protected double engineCapacity;

        protected double fuelConsumption;
    }
}

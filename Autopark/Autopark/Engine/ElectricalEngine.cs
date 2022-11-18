using Autopark;

namespace Autopark.Engine
{
    public sealed class ElectricalEngine : Engine
    {
        public ElectricalEngine(double consumption) : 
            base(EngineTypes.ELECTRICAL, Constants.electricalEngineCoefficient)
        {
            ElectricityConsumption = consumption;
        }
        public override double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;
        public double ElectricityConsumption
        {
            get { return electricityConsumption; }
            set 
            {
                if (value <= 0.0) throw new ArgumentException("Consumption must be positive number");
                electricityConsumption = value;
            }
        }
        private double electricityConsumption;
    }
}

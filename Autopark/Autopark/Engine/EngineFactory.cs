using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Engine
{
    public static class EngineFactory
    {
        public static Engine CreateInstance(
            Engine.EngineTypes engineType,
            double consumption,
            double? engineCapacity
            )
        {
            switch (engineType)
            {
                case Engine.EngineTypes.ELECTRICAL:
                    return new ElectricalEngine(consumption);
                case Engine.EngineTypes.DIESEL:
                    if (engineCapacity.HasValue)
                        return new DieselEngine((double)engineCapacity, consumption);
                    throw new ArgumentException("Requiered argument engineCapacity is null");
                case Engine.EngineTypes.GASOLINE:
                    if (engineCapacity.HasValue)
                        return new GasolineEngine((double)engineCapacity, consumption);
                    throw new ArgumentException("Requiered argument engineCapacity is null");
                default:
                    throw new ArgumentException($"Invalid enum object {engineType}");
            }
        }
    }
}

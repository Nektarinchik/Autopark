using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark
{
    public static class Constants
    {

        // Vehicle coefficients
        public const double weightCoefficient = 0.0013;
        public const int coefficientOnTaxCoefficient = 30;
        public const int taxPerMonthAddingValue = 5;

        // Engine coefficients
        public const double electricalEngineCoefficient = 0.1;
        public const double gasolineEngineCoefficient = 1.0;
        public const double dieselEngineCoefficient = 1.2;

    }
}

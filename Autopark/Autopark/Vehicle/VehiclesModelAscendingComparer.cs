using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Vehicle
{
    public class VehiclesModelAscendingComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle? x, Vehicle? y)
        {
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                throw new NullReferenceException();

            return x.Model.CompareTo(y.Model);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDelivery.Domain
{
    public static class Neighborhood
    {
        private const int _range = 10;
        private const int _oppositeRange = _range * -1;

        public static bool IsInRange(Location location)
        {
            return (_range >= location.X && location.X >= _oppositeRange) && (_range >= location.Y && location.Y >= _oppositeRange);
        }
    }
}
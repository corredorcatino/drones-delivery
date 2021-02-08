using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DronesDelivery.Domain.Exceptions
{
    public class LocationOutOfRangeException : ApplicationException
    {
        public LocationOutOfRangeException(Location location) : base($"Ubicación fuera del rango de cobertura: {location}")
        {
        }
    }
}
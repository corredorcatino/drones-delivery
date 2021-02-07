using System;

namespace DronesDelivery.Domain
{
    public class Location : IEquatable<Location>
    {
        public int X { get; set; } = 0;

        public int Y { get; set; } = 0;

        public Orientation Orientation { get; set; } = Orientation.North;

        public bool Equals(Location other)
        {
            return this.X == other.X && this.Y == other.Y && this.Orientation == other.Orientation;
        }
    }
}
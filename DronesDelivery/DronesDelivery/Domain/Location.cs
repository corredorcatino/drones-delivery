﻿using System;

namespace DronesDelivery.Domain
{
    public struct Location
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Orientation Orientation { get; set; }

        public Location(int x, int y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}) {2}", X, Y, Orientation.ToFriendlyString());
        }
    }
}
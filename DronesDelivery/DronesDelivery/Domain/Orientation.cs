using System;
using System.ComponentModel.DataAnnotations;

namespace DronesDelivery.Domain
{
    public enum Orientation
    {
        North,
        East,
        West,
        South
    }

    public static class OrientationExtentions
    {
        public static string ToFriendlyString(this Orientation orientation)
        {
            return orientation switch
            {
                Orientation.North => "dirección Norte",
                Orientation.East => "dirección Oriente",
                Orientation.South => "dirección Sur",
                Orientation.West => "dirección Occidente",
                _ => throw new ArgumentException($"\"{orientation}\" no es una orientación válida."),
            };
        }
    }
}
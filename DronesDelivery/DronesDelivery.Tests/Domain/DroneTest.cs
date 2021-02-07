using DronesDelivery.Domain;
using System.Collections.Generic;
using Xunit;

namespace DronesDelivery.Tests.Domain
{
    public class DroneTest
    {
        [Fact]
        public void CanFly()
        {
            //Arrange
            var drone = new Drone("01");

            var instructions = new List<Instruction>
            {
                Instruction.Create('A'),
                Instruction.Create('A'),
                Instruction.Create('A'),
                Instruction.Create('A'),
                Instruction.Create('I'),
                Instruction.Create('A'),
                Instruction.Create('A')
            };

            var routes = new List<Route>
            {
                new Route(instructions)
            };

            drone.SetRoutes(routes);

            //Act
            drone.Fly();

            //Assert
            Assert.Equal(drone.Location, new Location() { X = -2, Y = 4, Orientation = Orientation.West });
        }
    }
}
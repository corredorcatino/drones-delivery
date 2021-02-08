using DronesDelivery.Domain;
using System.Collections.Generic;
using Xunit;

namespace DronesDelivery.Tests.Domain
{
    public class DroneTest : IClassFixture<DroneFixture>
    {
        private readonly DroneFixture _droneFixture;

        public DroneTest(DroneFixture droneFixture)
        {
            _droneFixture = droneFixture;
        }

        [Fact]
        public void CanFly()
        {
            //Arrange
            var drone = new Drone("01");

            var routes = new List<Route>
            {
                _droneFixture.Route
            };

            drone.SetRoutes(routes);

            //Act
            drone.Fly();

            //Assert
            Assert.Equal(drone.Location, new Location(-2, 4, Orientation.West));
        }

        [Fact]
        public void CanFlyMultipleRoutes()
        {
            //Arrange
            var drone = new Drone("01");

            drone.SetRoutes(_droneFixture.Routes);

            //Act
            drone.Fly();

            //Assert
            Assert.Equal(drone.Location, new Location(0, 0, Orientation.West));
        }
    }
}
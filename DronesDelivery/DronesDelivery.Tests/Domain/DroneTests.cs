using DronesDelivery.Domain;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DronesDelivery.Tests.Domain
{
    public class DroneTests : IClassFixture<DroneFixture>
    {
        private readonly DroneFixture _droneFixture;

        public DroneTests(DroneFixture droneFixture)
        {
            _droneFixture = droneFixture;
        }

        [Fact]
        public void Delivers()
        {
            //Arrange
            var drone = new Drone("01");

            drone.SetRoutes(_droneFixture.Routes);

            //Act
            drone.Deliver();

            //Assert
            var expected = new List<Location>
            {
                new Location(-2, 4, Orientation.West),
                new Location(-1, 3, Orientation.South),
                new Location(0, 0, Orientation.West)
            };

            Assert.Equal(expected, drone.DeliveryLocations);
        }

        [Fact]
        public void SetRoutes_WillNotAcceptRoutesBeyondDroneCapacity()
        {
            //Arrange
            var drone = new Drone("01");

            var fourthRoute = _droneFixture.Route;
            var routes = _droneFixture.Routes.Select(r => r).ToList();
            routes.Add(fourthRoute);

            //Act
            drone.SetRoutes(routes);

            //Assert
            var expected = routes.GetRange(0, drone.Capacity);
            Assert.Equal(expected, drone.Routes);
        }

        [Theory]
        [ClassData(typeof(OutOfRangeRoutesTestData))]
        public void Deliver_DronIsFaulted_WhenRouteGoesOutOfRange(Route route)
        {
            //Arrange
            var drone = new Drone("01");

            var routes = new List<Route>
            {
                route
            };

            drone.SetRoutes(routes);

            //Act
            drone.Deliver();

            //Assert
            Assert.True(drone.IsFaulted);
        }

        [Fact]
        public void Deliver_DroneIsNotFaulted_WhenAllRoutesAreInRange()
        {
            //Arrange
            var drone = new Drone("01");

            drone.SetRoutes(_droneFixture.Routes);

            //Act
            drone.Deliver();

            //Assert
            Assert.False(drone.IsFaulted);
        }

        [Fact]
        public void Deliver_DroneReturnsToBase_WhenIsFaulted()
        {
            //Arrange
            var drone = new Drone("01");

            var routes = new List<Route>
            {
                _droneFixture.OutOfRangeRoute
            };

            drone.SetRoutes(routes);

            //Act
            drone.Deliver();

            //Arrange
            Assert.Equal(new Location(0, 0, Orientation.North), drone.Location);
        }
    }
}
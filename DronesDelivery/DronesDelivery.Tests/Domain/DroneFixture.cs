using DronesDelivery.Domain;
using System.Collections.Generic;

namespace DronesDelivery.Tests.Domain
{
    public class DroneFixture
    {
        public Route Route { get; set; }

        public List<Route> Routes { get; set; } = new List<Route>();

        public Route OutOfRangeRoute { get; set; }

        public DroneFixture()
        {
            var firstRouteInstructions = new List<Instruction>
            {
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.TurnLeft,
                Instructions.MoveForward,
                Instructions.MoveForward,
            };

            Route = new Route(firstRouteInstructions);

            Routes.Add(new Route(firstRouteInstructions));

            var secondRouteInstructions = new List<Instruction>
            {
                Instructions.TurnRight,
                Instructions.TurnRight,
                Instructions.TurnRight,
                Instructions.MoveForward,
                Instructions.TurnLeft,
                Instructions.MoveForward,
                Instructions.TurnRight
            };

            Routes.Add(new Route(secondRouteInstructions));

            var thirdRouteInstructions = new List<Instruction>
            {
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.TurnLeft,
                Instructions.MoveForward,
                Instructions.TurnRight,
                Instructions.MoveForward,
                Instructions.TurnRight
            };

            Routes.Add(new Route(thirdRouteInstructions));

            var outOfRangeRouteInstructions = new List<Instruction>
            {
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward,
                Instructions.MoveForward
            };

            OutOfRangeRoute = new Route(outOfRangeRouteInstructions);
        }
    }
}
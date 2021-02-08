using DronesDelivery.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDelivery.Tests.Fixtures
{
    public class FirstDroneFixture
    {
        public Dictionary<string, List<Route>> Config { get; set; } = new Dictionary<string, List<Route>>();

        public FirstDroneFixture()
        {
            var routes = new List<Route>();

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

            routes.Add(new Route(firstRouteInstructions));

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

            routes.Add(new Route(secondRouteInstructions));

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

            routes.Add(new Route(thirdRouteInstructions));

            Config.Add("01", routes);
        }
    }
}
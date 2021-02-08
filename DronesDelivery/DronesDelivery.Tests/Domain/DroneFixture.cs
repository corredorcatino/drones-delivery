using DronesDelivery.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDelivery.Tests.Domain
{
    public class DroneFixture
    {
        public Route Route { get; set; }

        public List<Route> Routes { get; set; }

        public DroneFixture()
        {
            var moveForwardInstruction = Instruction.Create('A');
            var turnLeftInstruction = Instruction.Create('I');
            var turnRightInstruction = Instruction.Create('D');

            var firstRouteInstructions = new List<Instruction>
            {
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                turnLeftInstruction,
                moveForwardInstruction,
                moveForwardInstruction
            };

            var secondRouteInstructions = new List<Instruction>
            {
                turnRightInstruction,
                turnRightInstruction,
                turnRightInstruction,
                moveForwardInstruction,
                turnLeftInstruction,
                moveForwardInstruction,
                turnRightInstruction
            };

            var thirdRouteInstructions = new List<Instruction>
            {
                moveForwardInstruction,
                moveForwardInstruction,
                turnLeftInstruction,
                moveForwardInstruction,
                turnRightInstruction,
                moveForwardInstruction,
                turnRightInstruction
            };

            var firstRoute = new Route(firstRouteInstructions);
            var secondRoute = new Route(secondRouteInstructions);
            var thirdRoute = new Route(thirdRouteInstructions);

            Route = firstRoute;

            Routes = new List<Route>
            {
                firstRoute,
                secondRoute,
                thirdRoute
            };
        }
    }
}
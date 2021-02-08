using DronesDelivery.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DronesDelivery.Tests.Domain
{
    public class OutOfRangeRoutesTestData : IEnumerable<object[]>
    {
        private readonly List<Route> OutOfRangeRoutes;

        public OutOfRangeRoutesTestData()
        {
            var outOfRangeInstructions = new List<Instruction>
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

            var outOfRangeInstructionsNorth = outOfRangeInstructions.Select(i => i).ToList();

            var outOfRangeInstructionsWest = new List<Instruction> { Instructions.TurnLeft };
            outOfRangeInstructionsWest.AddRange(outOfRangeInstructions.Select(i => i));

            var outOfRangeInstructionsEast = new List<Instruction> { Instructions.TurnRight };
            outOfRangeInstructionsEast.AddRange(outOfRangeInstructions.Select(i => i));

            var outOfRangeInstructionsSouth = new List<Instruction> { Instructions.TurnRight, Instructions.TurnRight };
            outOfRangeInstructionsSouth.AddRange(outOfRangeInstructions.Select(i => i));

            OutOfRangeRoutes = new List<Route>
            {
                new Route(outOfRangeInstructionsNorth),
                new Route(outOfRangeInstructionsWest),
                new Route(outOfRangeInstructionsSouth),
                new Route(outOfRangeInstructionsEast)
            };
        }

        public IEnumerator<object[]> GetEnumerator()
        {
            foreach (var route in OutOfRangeRoutes)
            {
                yield return new object[] { route };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
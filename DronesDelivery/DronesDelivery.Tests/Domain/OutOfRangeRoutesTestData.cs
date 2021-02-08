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
            var moveForwardInstruction = Instruction.Create('A');
            var turnLeftInstruction = Instruction.Create('I');
            var turnRightInstruction = Instruction.Create('D');

            var outOfRangeInstructions = new List<Instruction>
            {
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction,
                moveForwardInstruction
            };

            var outOfRangeInstructionsNorth = outOfRangeInstructions.Select(i => i).ToList();

            var outOfRangeInstructionsWest = new List<Instruction> { turnLeftInstruction };
            outOfRangeInstructionsWest.AddRange(outOfRangeInstructions.Select(i => i));

            var outOfRangeInstructionsEast = new List<Instruction> { turnRightInstruction };
            outOfRangeInstructionsEast.AddRange(outOfRangeInstructions.Select(i => i));

            var outOfRangeInstructionsSouth = new List<Instruction> { turnRightInstruction, turnRightInstruction };
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
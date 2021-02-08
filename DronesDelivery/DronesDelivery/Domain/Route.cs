using System.Collections.Generic;

namespace DronesDelivery.Domain
{
    public class Route
    {
        private readonly List<Instruction> _instructions;

        public Route(List<Instruction> instructions)
        {
            _instructions = instructions;
        }

        public IEnumerable<Instruction> GetInstructions()
        {
            foreach (var instruction in _instructions)
            {
                yield return instruction;
            }
        }
    }
}
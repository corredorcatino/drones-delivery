using System;
using System.Threading.Tasks;

namespace DronesDelivery.Domain
{
    public abstract class Instruction
    {
        public static Instruction Create(char instruction)
        {
            return instruction switch
            {
                'A' => new MoveForwardInstruction(),
                'I' => new TurnLeftInstruction(),
                'D' => new TurnRightInstruction(),
                _ => throw new ArgumentException($"\"{instruction}\" no es una instrucción válida."),
            };
        }

        public Location Execute(Location location)
        {
            return location.Orientation switch
            {
                Orientation.North => ExecuteInstructionWhenFacingNorth(location),
                Orientation.East => ExecuteInstructionWhenFacingEast(location),
                Orientation.South => ExecuteInstructionWhenFacingSouth(location),
                Orientation.West => ExecuteInstructionWhenFacingWest(location),
                _ => throw new ArgumentException($"\"{location.Orientation}\" no es una orientación válida."),
            };
        }

        protected abstract Location ExecuteInstructionWhenFacingNorth(Location location);

        protected abstract Location ExecuteInstructionWhenFacingEast(Location location);

        protected abstract Location ExecuteInstructionWhenFacingSouth(Location location);

        protected abstract Location ExecuteInstructionWhenFacingWest(Location location);
    }
}
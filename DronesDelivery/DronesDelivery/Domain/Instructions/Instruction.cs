using System;

namespace DronesDelivery.Domain
{
    public abstract class Instruction
    {
        public static Instruction Create(char instruction)
        {
            switch (instruction)
            {
                case 'A':
                    return new MoveForwardInstruction();

                case 'I':
                    return new TurnLeftInstruction();

                case 'D':
                    return new TurnRightInstruction();

                default:
                    throw new ArgumentException($"\"{instruction}\" no es una instrucción válida.");
            }
        }

        public Location Execute(Location location)
        {
            switch (location.Orientation)
            {
                case Orientation.North:
                    return ExecuteInstructionWhenFacingNorth(location);

                case Orientation.East:
                    return ExecuteInstructionWhenFacingEast(location);

                case Orientation.South:
                    return ExecuteInstructionWhenFacingSouth(location);

                case Orientation.West:
                    return ExecuteInstructionWhenFacingWest(location);

                default:
                    throw new ArgumentException($"\"{location.Orientation}\" no es una orientación válida.");
            }
        }

        protected abstract Location ExecuteInstructionWhenFacingNorth(Location location);

        protected abstract Location ExecuteInstructionWhenFacingEast(Location location);

        protected abstract Location ExecuteInstructionWhenFacingSouth(Location location);

        protected abstract Location ExecuteInstructionWhenFacingWest(Location location);
    }
}
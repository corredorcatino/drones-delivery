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

        public void Execute(Location location)
        {
            switch (location.Orientation)
            {
                case Orientation.North:
                    ExecuteInstructionWhenFacingNorth(location);
                    break;

                case Orientation.East:
                    ExecuteInstructionWhenFacingEast(location);
                    break;

                case Orientation.South:
                    ExecuteInstructionWhenFacingSouth(location);
                    break;

                case Orientation.West:
                    ExecuteInstructionWhenFacingWest(location);
                    break;

                default:
                    throw new ArgumentException($"\"{location.Orientation}\" no es una orientación válida.");
            }
        }

        protected abstract void ExecuteInstructionWhenFacingNorth(Location location);

        protected abstract void ExecuteInstructionWhenFacingEast(Location location);

        protected abstract void ExecuteInstructionWhenFacingSouth(Location location);

        protected abstract void ExecuteInstructionWhenFacingWest(Location location);
    }
}
using DronesDelivery.Domain;

namespace DronesDelivery.Tests.Domain
{
    public static class Instructions
    {
        public static readonly Instruction MoveForward = Instruction.Create('A');

        public static readonly Instruction TurnLeft = Instruction.Create('I');

        public static readonly Instruction TurnRight = Instruction.Create('D');
    }
}
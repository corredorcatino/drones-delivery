namespace DronesDelivery.Domain
{
    public class MoveForwardInstruction : Instruction
    {
        protected override void ExecuteInstructionWhenFacingNorth(Location location)
        {
            location.Y++;
        }

        protected override void ExecuteInstructionWhenFacingEast(Location location)
        {
            location.X++;
        }

        protected override void ExecuteInstructionWhenFacingSouth(Location location)
        {
            location.Y--;
        }

        protected override void ExecuteInstructionWhenFacingWest(Location location)
        {
            location.X--;
        }
    }
}
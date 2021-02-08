namespace DronesDelivery.Domain
{
    public class MoveForwardInstruction : Instruction
    {
        protected override Location ExecuteInstructionWhenFacingNorth(Location location)
        {
            location.Y++;

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingEast(Location location)
        {
            location.X++;

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingSouth(Location location)
        {
            location.Y--;

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingWest(Location location)
        {
            location.X--;

            return location;
        }
    }
}
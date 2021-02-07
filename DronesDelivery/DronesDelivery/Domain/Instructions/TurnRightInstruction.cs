namespace DronesDelivery.Domain
{
    public class TurnRightInstruction : Instruction
    {
        protected override void ExecuteInstructionWhenFacingNorth(Location location)
        {
            location.Orientation = Orientation.East;
        }

        protected override void ExecuteInstructionWhenFacingEast(Location location)
        {
            location.Orientation = Orientation.South;
        }

        protected override void ExecuteInstructionWhenFacingSouth(Location location)
        {
            location.Orientation = Orientation.West;
        }

        protected override void ExecuteInstructionWhenFacingWest(Location location)
        {
            location.Orientation = Orientation.North;
        }
    }
}
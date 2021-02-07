namespace DronesDelivery.Domain
{
    public class TurnLeftInstruction : Instruction
    {
        protected override void ExecuteInstructionWhenFacingNorth(Location location)
        {
            location.Orientation = Orientation.West;
        }

        protected override void ExecuteInstructionWhenFacingEast(Location location)
        {
            location.Orientation = Orientation.North;
        }

        protected override void ExecuteInstructionWhenFacingSouth(Location location)
        {
            location.Orientation = Orientation.East;
        }

        protected override void ExecuteInstructionWhenFacingWest(Location location)
        {
            location.Orientation = Orientation.South;
        }
    }
}
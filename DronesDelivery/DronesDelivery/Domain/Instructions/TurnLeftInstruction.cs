namespace DronesDelivery.Domain
{
    public class TurnLeftInstruction : Instruction
    {
        protected override Location ExecuteInstructionWhenFacingNorth(Location location)
        {
            location.Orientation = Orientation.West;

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingEast(Location location)
        {
            location.Orientation = Orientation.North;

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingSouth(Location location)
        {
            location.Orientation = Orientation.East;

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingWest(Location location)
        {
            location.Orientation = Orientation.South;

            return location;
        }
    }
}
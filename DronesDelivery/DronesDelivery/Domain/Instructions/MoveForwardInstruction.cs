using DronesDelivery.Domain.Exceptions;

namespace DronesDelivery.Domain
{
    public class MoveForwardInstruction : Instruction
    {
        protected override Location ExecuteInstructionWhenFacingNorth(Location location)
        {
            location.Y++;

            ValidateLocation(location);

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingEast(Location location)
        {
            location.X++;

            ValidateLocation(location);

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingSouth(Location location)
        {
            location.Y--;

            ValidateLocation(location);

            return location;
        }

        protected override Location ExecuteInstructionWhenFacingWest(Location location)
        {
            location.X--;

            ValidateLocation(location);

            return location;
        }

        private void ValidateLocation(Location location)
        {
            if (!Neighborhood.IsInRange(location))
            {
                throw new LocationOutOfRangeException(location);
            }
        }
    }
}
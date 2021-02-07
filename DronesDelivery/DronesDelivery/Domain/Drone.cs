using System.Collections.Generic;

namespace DronesDelivery.Domain
{
    public class Drone
    {
        public Location Location { get; }

        private readonly string _id;

        private List<Route> _routes;

        public Drone(string id)
        {
            _id = id;

            Location = new Location();
        }

        public void SetRoutes(List<Route> routes)
        {
            _routes = routes;
        }

        public void Fly()
        {
            foreach (var route in _routes)
            {
                foreach (var instruction in route.GetInstructions())
                {
                    instruction.Execute(Location);
                }
            }
        }
    }
}
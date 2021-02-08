using System;
using System.Collections.Generic;
using System.Linq;

namespace DronesDelivery.Domain
{
    public class Drone
    {
        public string Id { get; }

        public Location Location { get; private set; }

        public int Capacity { get; } = 3;

        private List<Route> _routes = new List<Route>();

        public List<Route> Routes
        {
            get { return _routes.Select(r => r).ToList(); }
        }

        private List<Location> _deliveryLocations = new List<Location>();

        public List<Location> DeliveryLocations
        {
            get { return _deliveryLocations.Select(dl => dl).ToList(); }
        }

        public Drone(string id)
        {
            Id = id;

            Location = new Location(0, 0, Orientation.North);
        }

        public void SetRoutes(List<Route> routes)
        {
            if (routes.Count > Capacity)
            {
                _routes = routes.GetRange(0, Capacity);
            }
            else
            {
                _routes = routes;
            }
        }

        public void Deliver()
        {
            try
            {
                foreach (var route in _routes)
                {
                    foreach (var instruction in route.GetInstructions())
                    {
                        Location = instruction.Execute(Location);
                    }

                    MakeDelivery();
                }
            }
            finally
            {
                ReturnToBase();
            }
        }

        private void MakeDelivery()
        {
            _deliveryLocations.Add(Location);
        }

        private void ReturnToBase()
        {
            Location = new Location(0, 0, Orientation.North);
        }
    }
}
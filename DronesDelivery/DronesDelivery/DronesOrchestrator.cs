using DronesDelivery.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDelivery
{
    public class DronesOrchestrator
    {
        private readonly IDronesConfigReader _dronesConfigReader;
        private readonly IDronesReportWriter _dronesReportWriter;

        public DronesOrchestrator() : this(new TextFileDronesConfigReader(), new TextFileDronesReportWriter())
        {
        }

        public DronesOrchestrator(IDronesConfigReader dronesConfigReader, IDronesReportWriter dronesReportWriter)
        {
            _dronesConfigReader = dronesConfigReader;
            _dronesReportWriter = dronesReportWriter;
        }

        public async Task Run()
        {
            var dronesConfig = _dronesConfigReader.ReadConfig();

            var drones = ConfigureDrones(dronesConfig);

            var dronesDeliveryTasks = DispatchDrones(drones);

            await AwaitForDronesToCompleteDeliveryTasks(dronesDeliveryTasks);

            _dronesReportWriter.WriteReport(drones);
        }

        private List<Drone> ConfigureDrones(Dictionary<string, List<Route>> input)
        {
            Console.WriteLine("Configurando drones.");

            var drones = new List<Drone>();

            foreach (var item in input)
            {
                var drone = new Drone(item.Key);

                drone.SetRoutes(item.Value);

                drones.Add(drone);
            }

            return drones;
        }

        private static List<Task> DispatchDrones(List<Drone> drones)
        {
            Console.WriteLine("Despachando drones.");
            var deliverTaks = new List<Task>();

            foreach (var drone in drones)
            {
                deliverTaks.Add(Task.Run(() => drone.Deliver()));
            }
            Console.WriteLine("Drones despachados.");

            return deliverTaks;
        }

        private async Task AwaitForDronesToCompleteDeliveryTasks(List<Task> dronesDeliveryTasks)
        {
            await Task.WhenAll(dronesDeliveryTasks);
            Console.WriteLine("Drones de regreso en el restaurante.");
        }
    }
}
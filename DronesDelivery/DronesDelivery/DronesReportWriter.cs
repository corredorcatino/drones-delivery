using DronesDelivery.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DronesDelivery
{
    public interface IDronesReportWriter
    {
        void WriteReport(List<Drone> drones);
    }

    public class TextFileDronesReportWriter : IDronesReportWriter
    {
        public void WriteReport(List<Drone> drones)
        {
            Console.WriteLine("Escribiendo reportes.");

            var outputPath = GetOutputPath();

            Directory.CreateDirectory(outputPath);

            foreach (var drone in drones)
            {
                var reportContent = new List<string> { "== Reporte de entregas ==" };

                foreach (var deliveryLocation in drone.DeliveryLocations)
                {
                    reportContent.Add("");
                    reportContent.Add(deliveryLocation.ToString());
                }

                if (drone.IsFaulted)
                {
                    reportContent.Add("");
                    reportContent.Add(drone.ErrorMessage);
                }

                var filename = Path.Combine(outputPath, $"out{drone.Id}.txt");
                File.WriteAllLines(filename, reportContent);
            }
        }

        private string GetOutputPath()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDirectory, "Output");

            return path;
        }
    }
}
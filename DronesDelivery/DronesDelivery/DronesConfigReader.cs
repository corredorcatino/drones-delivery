using DronesDelivery.Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace DronesDelivery
{
    public interface IDronesConfigReader
    {
        Dictionary<string, List<Route>> ReadConfig();
    }

    public class TextFileDronesConfigReader : IDronesConfigReader
    {
        public Dictionary<string, List<Route>> ReadConfig()
        {
            Console.WriteLine("Leyendo configuración de los drones.");

            var input = new Dictionary<string, List<Route>>();

            string[] files = GetInputFilenames();

            foreach (var file in files)
            {
                var filename = Path.GetFileNameWithoutExtension(file);

                var droneId = filename.Substring(2);

                var routes = new List<Route>();

                foreach (var instructions in File.ReadLines(file))
                {
                    if (string.IsNullOrWhiteSpace(instructions.Trim()))
                    {
                        continue;
                    }

                    routes.Add(ParseInstructions(instructions));
                }

                input.Add(droneId, routes);
            }

            return input;
        }

        private static string[] GetInputFilenames()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var path = Path.Combine(currentDirectory, "Input");
            var files = Directory.GetFiles(path, "in*.txt");
            return files;
        }

        private Route ParseInstructions(string line)
        {
            var instructions = new List<Instruction>();

            foreach (var i in line.ToCharArray())
            {
                instructions.Add(Instruction.Create(i));
            }

            return new Route(instructions);
        }
    }
}
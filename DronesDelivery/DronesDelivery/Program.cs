using System.Threading.Tasks;

namespace DronesDelivery
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var orchestrator = new DronesOrchestrator();

            await orchestrator.Run();
        }
    }
}
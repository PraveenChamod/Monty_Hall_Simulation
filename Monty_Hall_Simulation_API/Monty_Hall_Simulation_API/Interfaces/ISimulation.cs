using Monty_Hall_Simulation_API.Models;

namespace Monty_Hall_Simulation_API.Interfaces
{
    public interface ISimulation
    {
        Result StartSimulations(int simulationCount, bool switchStatus);
    }
}

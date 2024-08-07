using Monty_Hall_Simulation_API.Enums;

namespace Monty_Hall_Simulation_API.Models
{
    public class Door
    {
        public DoorState DoorState { get; set; }
        public string? Prize { get; set; }
    }
}

using Monty_Hall_Simulation_API.Enums;
using Monty_Hall_Simulation_API.Models;

namespace Monty_Hall_Simulation_API.Interfaces
{
    public interface IGameService
    {
        Door UserChoosenDoor(int doorIndex);

        Door UserChoosesDoor(DoorState doorState);

        Door SpeakerOpensDoor();

        void ResetGame();
    }
}

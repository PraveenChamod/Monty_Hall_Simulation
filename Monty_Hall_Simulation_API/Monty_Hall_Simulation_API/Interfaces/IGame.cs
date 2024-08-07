using Monty_Hall_Simulation_API.Enums;
using Monty_Hall_Simulation_API.Models;

namespace Monty_Hall_Simulation_API.Interfaces
{
    public interface IGame
    {
        Door UserChoosesDoor(int doorIndex);

        Door UserChoosesDoor(DoorState doorState);

        int IndexOfDoor(Door door);

        Door SpeakerOpensDoor();

        void ResetGame();
    }
}

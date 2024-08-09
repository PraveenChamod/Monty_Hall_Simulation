using Monty_Hall_Simulation_API.Constants;
using Monty_Hall_Simulation_API.Enums;
using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Models;

namespace Monty_Hall_Simulation_API.Services
{
    public class GameService : IGameService
    {
        private List<Door> _doors =
        [
            new() { DoorState = DoorState.Initial, Prize = AppConstants.GOAT },
            new() { DoorState = DoorState.Initial, Prize = AppConstants.GOAT },
            new() { DoorState = DoorState.Initial, Prize = AppConstants.CAR }
        ];

        public Door UserChoosenDoor(int doorIndex)
        {
            if (doorIndex < 0 || doorIndex > 2)
            {
                throw new InvalidOperationException($"Door {doorIndex} doesn't exist.");
            }

            if (_doors[doorIndex].DoorState == DoorState.Opened)
            {
                throw new InvalidOperationException(AppConstants.DOOR_ALREADY_OPEN_ERROR_MESSAGE);
            }

            _doors[doorIndex].DoorState = DoorState.Chosen;
            return _doors[doorIndex];
        }

        public Door UserChoosesDoor(DoorState state)
        {
            var door = _doors.First(x => x.DoorState == state);

            door.DoorState = DoorState.Chosen;

            return door;
        }

        public Door SpeakerOpensDoor()
        {
            var door = _doors.First(x => x.Prize == AppConstants.GOAT && x.DoorState != DoorState.Chosen);

            door.DoorState = DoorState.Opened;

            return door;
        }

        public void ResetGame()
        {
            _doors.ForEach(x => x.DoorState = DoorState.Initial);

            _doors = _doors.OrderBy(x => new Random().Next()).ToList();
        }
    }
}

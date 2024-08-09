
using Monty_Hall_Simulation_API.Constants;
using Monty_Hall_Simulation_API.Enums;
using Monty_Hall_Simulation_API.Models;
using Monty_Hall_Simulation_API.Services;

namespace Test.Services
{
    [TestClass]
    public class GameServiceTests
    {
        private GameService _gameService;

        [TestInitialize]
        public void Setup()
        {
            _gameService = new GameService();
        }

        [TestMethod]
        public void UserChoosenDoor_ShouldSetDoorStateToChosen_WhenValidIndex()
        {
            int doorIndex = 1;

            var door = _gameService.UserChoosenDoor(doorIndex);

            Assert.AreEqual(DoorState.Chosen, door.DoorState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UserChoosenDoor_ShouldThrowException_WhenInvalidIndex()
        {
            _gameService.UserChoosenDoor(3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UserChoosenDoor_ShouldThrowException_WhenDoorAlreadyOpened()
        {
            _gameService.UserChoosenDoor(0);
            _gameService.SpeakerOpensDoor();

            var doors = _gameService.GetType()
                                    .GetField("_doors", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                                    .GetValue(_gameService) as List<Door>;

            int openedDoorIndex = doors.FindIndex(d => d.DoorState == DoorState.Opened);

            _gameService.UserChoosenDoor(openedDoorIndex);
        }

        [TestMethod]
        public void UserChoosesDoor_ShouldSetDoorStateToChosen_WhenValidState()
        {
            var initialState = DoorState.Initial;

            var door = _gameService.UserChoosesDoor(initialState);

            Assert.AreEqual(DoorState.Chosen, door.DoorState);
        }

        [TestMethod]
        public void SpeakerOpensDoor_ShouldOpenGoatDoor_WhenAvailable()
        {
            _gameService.UserChoosenDoor(0);
            var door = _gameService.SpeakerOpensDoor();

            Assert.AreEqual(DoorState.Opened, door.DoorState);
            Assert.AreEqual(AppConstants.GOAT, door.Prize);
        }

        [TestMethod]
        public void ResetGame_ShouldResetAllDoorsToInitial()
        {
            _gameService.UserChoosenDoor(0);
            _gameService.SpeakerOpensDoor();

            _gameService.ResetGame();

            var doors = _gameService.GetType().GetField("_doors", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                          .GetValue(_gameService) as List<Door>;

            Assert.IsTrue(doors.All(door => door.DoorState == DoorState.Initial));
        }
    }
}

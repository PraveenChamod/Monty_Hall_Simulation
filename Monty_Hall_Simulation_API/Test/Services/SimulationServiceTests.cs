using Monty_Hall_Simulation_API.Constants;
using Monty_Hall_Simulation_API.Enums;
using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Models;
using Monty_Hall_Simulation_API.Services;
using Moq;

namespace Test.Services
{
    [TestClass]
    public class SimulationServiceTests
    {
        private Mock<IGameService> _mockGameService;
        private Mock<Random> _mockRandom;
        private SimulationService _simulationService;

        [TestInitialize]
        public void Setup()
        {
            _mockGameService = new Mock<IGameService>();
            _mockRandom = new Mock<Random>();
            _simulationService = new SimulationService(_mockRandom.Object, _mockGameService.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StartSimulations_ShouldThrowException_WhenSimulationCountIsZero()
        {
            _simulationService.StartSimulations(0, true);
        }

        [TestMethod]
        public void StartSimulations_ShouldReturnCorrectResult_WhenSwitchingDoors()
        {
            int simulationCount = 1;
            bool switchStatus = true;

            _mockRandom.Setup(r => r.Next(0, 3)).Returns(0);
            _mockGameService.Setup(g => g.UserChoosenDoor(It.IsAny<int>()));
            _mockGameService.Setup(g => g.SpeakerOpensDoor()).Returns(new Door { DoorState = DoorState.Opened, Prize = AppConstants.GOAT });
            _mockGameService.Setup(g => g.UserChoosesDoor(DoorState.Initial)).Returns(new Door { DoorState = DoorState.Chosen, Prize = AppConstants.CAR });

            var result = _simulationService.StartSimulations(simulationCount, switchStatus);

            Assert.AreEqual(simulationCount, result.GameCount);
            Assert.AreEqual(1, result.WinCount);
            Assert.AreEqual(1.0, result.WinRate);
            Assert.AreEqual(100.00, result.WinRatePercentage);
        }
    }
}

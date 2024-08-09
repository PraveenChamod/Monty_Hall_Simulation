using Microsoft.AspNetCore.Mvc;
using Monty_Hall_Simulation_API.Controllers;
using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Models;
using Moq;

namespace Test.Controllers
{
    [TestClass]
    public class SimulationControllerTests
    {
        private Mock<ISimulationService> _mockSimulationService;
        private SimulationController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockSimulationService = new Mock<ISimulationService>();
            _controller = new SimulationController(_mockSimulationService.Object);
        }

        [TestMethod]
        public void StartSimulations_ShouldReturnOk_WhenValidParameters()
        {
  
            int simulationCount = 1000;
            bool switchStatus = true;
            var resultMock = new Result
            {
                GameCount = 1000,
                WinCount = 700,
                WinRate = 0.7,
                WinRatePercentage = 70
            };
            _mockSimulationService.Setup(service => service.StartSimulations(simulationCount, switchStatus))
                                  .Returns(resultMock);


            var result = _controller.StartSimulations(simulationCount, switchStatus) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(resultMock, result.Value);
        }

        [TestMethod]
        public void StartSimulations_ShouldReturnInternalServerError_WhenExceptionThrown()
        {

            int simulationCount = 1000;
            bool switchStatus = true;
            _mockSimulationService.Setup(service => service.StartSimulations(simulationCount, switchStatus))
                                  .Throws(new Exception("Some error"));

            var result = _controller.StartSimulations(simulationCount, switchStatus) as ObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(500, result.StatusCode);
            Assert.AreEqual("Internal server error: Some error", result.Value);
        }
    }
}

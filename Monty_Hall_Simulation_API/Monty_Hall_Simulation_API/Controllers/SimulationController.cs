using Microsoft.AspNetCore.Mvc;
using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Models;

namespace Monty_Hall_Simulation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        private readonly ISimulation _simulationService;

        public SimulationController(ISimulation simulationService)
        {
            _simulationService = simulationService;
        }

        [HttpPost("Start")]
        public IActionResult StartSimulations([FromQuery] int simulationCount, [FromQuery] bool switchStatus)
        {
            try
            {
                Result result = _simulationService.StartSimulations(simulationCount, switchStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}

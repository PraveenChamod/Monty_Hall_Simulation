using Microsoft.AspNetCore.Mvc;
using Monty_Hall_Simulation_API.Interfaces;
using Monty_Hall_Simulation_API.Models;

namespace Monty_Hall_Simulation_API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class SimulationController : ControllerBase
    {
        private readonly ISimulationService _simulationService;

        public SimulationController(ISimulationService simulationService)
        {
            _simulationService = simulationService;
        }

        [HttpPost]
        [Route("Start")]
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

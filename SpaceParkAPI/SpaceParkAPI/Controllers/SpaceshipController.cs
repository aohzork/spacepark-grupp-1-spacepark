using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repos;
using System;
using System.Threading.Tasks;

namespace SpaceParkAPI.Controllers
{
    [Route("spapi/v1.0/[controller]")]
    [ApiController]
    public class SpaceshipController : ControllerBase
    {
        private readonly ISpaceshipRepo _spaceshipRepo;

        public SpaceshipController(ISpaceshipRepo spaceshipRepo)
        {
            _spaceshipRepo = spaceshipRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpaceshipModel>> GetSpaceshipById(int id)
        {
            try
            {
                var result = await _spaceshipRepo.GetSpaceshipById(id);
                if (result == null)
                {
                    return NotFound($"Spaceship with ID: {id} could not be found");
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }
    }
}

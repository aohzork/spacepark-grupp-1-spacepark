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

        //spapi/v1.0/Spaceship/##
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

        //spapi/v1.0/Spaceship
        [HttpPost]
        public async Task<ActionResult<PersonModel>> PostEvent(SpaceshipModel spaceshipModel)
        {
            try
            {
                _spaceshipRepo.Add(spaceshipModel);
                if (await _spaceshipRepo.Save())
                {
                    return Created($"/api/v1.0/Spaceship/{spaceshipModel.ID}", spaceshipModel);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
            return BadRequest();
        }
    }
}

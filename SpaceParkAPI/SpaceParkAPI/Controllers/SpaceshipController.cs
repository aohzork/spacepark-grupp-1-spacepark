using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Controllers
{
    public class SpaceshipController : ControllerBase
    {
        private readonly ISpaceshipRepo _spaceshipRepo;
        //private readonly IMapper _mapper;

        public SpaceshipController(ISpaceshipRepo spaceshipRepo /*IMapper mapper*/)
        {
            _spaceshipRepo = spaceshipRepo;
            //_mapper = mapper;
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

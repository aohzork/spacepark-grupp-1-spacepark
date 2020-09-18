using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repos;

namespace SpaceParkAPI.Controllers
{
    [ApiController]
    [Route("api/v1.0/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepo _personRepo;
        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<PersonModel>> GetPersonByName(string name)
        {
            try
            {
                var personResult = await _personRepo.GetPersonByName(name);
                if (personResult==null)
                {
                    return NotFound($"Person with Name: {name} could not be found");
                }

                return Ok(personResult);
            }
            catch (Exception e)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Failure: {e.Message}");
            }
        }
    }
}
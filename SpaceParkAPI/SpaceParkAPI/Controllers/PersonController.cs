using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repos;

namespace SpaceParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
            return new PersonModel { ID = 2, Name = $"{name}" };
        }
    }
}
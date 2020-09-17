using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        [HttpGet("{name}")]
        public async Task<ActionResult<PersonModel>> GetPersonByName()
        {
            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceshipModelsController : ControllerBase
    {
        private readonly SpaceParkContext _context;

        public SpaceshipModelsController(SpaceParkContext context)
        {
            _context = context;
        }

        // GET: api/SpaceshipModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpaceshipModel>>> GetSpaceships()
        {
            return await _context.Spaceships.ToListAsync();
        }

        // GET: api/SpaceshipModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpaceshipModel>> GetSpaceshipModel(long id)
        {
            var spaceshipModel = await _context.Spaceships.FindAsync(id);

            if (spaceshipModel == null)
            {
                return NotFound();
            }

            return spaceshipModel;
        }

        // PUT: api/SpaceshipModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpaceshipModel(long id, SpaceshipModel spaceshipModel)
        {
            if (id != spaceshipModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(spaceshipModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceshipModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SpaceshipModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SpaceshipModel>> PostSpaceshipModel(SpaceshipModel spaceshipModel)
        {
            _context.Spaceships.Add(spaceshipModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpaceshipModel", new { id = spaceshipModel.ID }, spaceshipModel);
        }

        // DELETE: api/SpaceshipModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpaceshipModel>> DeleteSpaceshipModel(long id)
        {
            var spaceshipModel = await _context.Spaceships.FindAsync(id);
            if (spaceshipModel == null)
            {
                return NotFound();
            }

            _context.Spaceships.Remove(spaceshipModel);
            await _context.SaveChangesAsync();

            return spaceshipModel;
        }

        private bool SpaceshipModelExists(long id)
        {
            return _context.Spaceships.Any(e => e.ID == id);
        }
    }
}

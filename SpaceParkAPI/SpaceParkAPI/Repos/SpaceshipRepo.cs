using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repos
{
    public class SpaceshipRepo : Repository, ISpaceshipRepo
    {
        public SpaceshipRepo(SpaceParkContext spaceParkContext, ILogger<SpaceshipRepo> logger) : base(spaceParkContext, logger)
        { }

        private static IQueryable<SpaceshipModel> SpaceshipQuery(IQueryable<SpaceshipModel> query)
        {
            return query;
        }

        public async Task<SpaceshipModel> GetSpaceshipById(long id)
        {
            _logger.LogInformation($"Getting Spaceship with ID: {id}");

            IQueryable<SpaceshipModel> query = _spaceParkContext.Spaceships.Where(s => s.ID == id).Include(p => p.Person);
            query = query.Select(s => new SpaceshipModel
            {
                ID = s.ID,
                ParkingSpaceID = s.ParkingSpaceID,
                Person = new PersonModel
                {
                    ID = s.Person.ID,
                    Name = s.Person.Name,
                    SpaceshipID = s.Person.SpaceshipID
                }
            });

            query = SpaceshipQuery(query);

            return await query.SingleOrDefaultAsync();
        }
    }
}

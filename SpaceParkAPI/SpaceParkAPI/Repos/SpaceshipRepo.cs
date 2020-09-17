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

        public async Task<SpaceshipModel> GetSpaceshipById(int id)
        {
            _logger.LogInformation($"Getting Spaceship with ID: {id}");

            IQueryable<SpaceshipModel> query = _spaceParkContext.SpaceshipModels.Where(s => s.ID == id);

            query = SpaceshipQuery(query);

            return await query.SingleOrDefaultAsync();
        }
    }
}

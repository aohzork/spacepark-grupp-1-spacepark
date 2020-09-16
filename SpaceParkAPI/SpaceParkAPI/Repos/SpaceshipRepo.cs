using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repos
{
    public class SpaceshipRepo : ISpaceshipRepo
    {
        public SpaceshipRepo(SpaceParkContext spaceParkContext) : base (spaceParkContext)
        { }

        public async Task<SpaceshipModel> GetSpaceshipById(int id)
        {
            //_logger.LogInformation($"Getting Spaceship with ID: {id}");

            IQueryable<SpaceshipModel> query = spaceParkContext
        }

        public async Task<SpaceshipModel> GetSpaceshipByName()
        {
            throw new NotImplementedException();
        }
    }
}

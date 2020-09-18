using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repos
{
    public class ParkingSpaceRepo : Repository, IParkingSpaceRepo
    {
        public ParkingSpaceRepo(SpaceParkContext spaceParkContext, ILogger<ParkingSpaceRepo> logger) : base(spaceParkContext, logger)
        { }

        private static IQueryable<ParkingSpaceModel> ParkingSpaceQuery(IQueryable<ParkingSpaceModel> query)
        {
            return query;
        }

      

        public async Task<ParkingSpaceModel> GetParkingSpaceById(int id)
        {
            _logger.LogInformation($"Getting ParkingSpace with ID: {id}");

            IQueryable<ParkingSpaceModel> query = _spaceParkContext.ParkingSpaces.Where(y => y.ID == id); 

            query = ParkingSpaceQuery(query);

            return await query.SingleOrDefaultAsync(); 
        }
    }
}

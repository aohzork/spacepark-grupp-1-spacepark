using Microsoft.Extensions.Logging;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace SpaceParkAPI.Repos
{
    public class PersonRepo : Repository, IPersonRepo 
    {
        public PersonRepo(SpaceParkContext spaceParkContext, ILogger<PersonRepo> logger) : base(spaceParkContext, logger)
        { }

        private static IQueryable<PersonModel> SpaceshipQuery(IQueryable<PersonModel> query)
        {
            return query;
        }
        public string GetPersonName()
        {
            throw new NotImplementedException();
        }
    }
}

﻿using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Repos
{
    interface IPersonRepo : IRepository
    {
        public Task<PersonModel> GetPersonByName(String name);
    }
}

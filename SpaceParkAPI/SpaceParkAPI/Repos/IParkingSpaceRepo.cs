using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Repos
{
    public interface IParkingSpaceRepo : IRepository
    {
        Task<ParkingSpaceModel> GetParkingSpaceById(int id);

    }
}

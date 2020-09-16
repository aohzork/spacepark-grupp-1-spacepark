using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Repos
{
    public interface ISpaceshipRepo : IDisposable
    {
        SpaceshipModel GetSpaceshipById();
    }
}

using SpaceParkAPI.Controllers;
using SpaceParkAPI.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTest
{
    class PersonControllerTest
    {
        private readonly PersonRepo _repo;
        private readonly PersonController _sut;
        public PersonControllerTest()
        {
            _sut = new PersonController(_repo);
        }

        
    }
}

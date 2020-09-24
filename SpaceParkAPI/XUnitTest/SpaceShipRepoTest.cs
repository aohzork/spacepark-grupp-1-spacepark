using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class SpaceShipRepoTest
    {
        [Fact]
        public void GetSpaceshipById_Returns_SpaceShip()
        {
            //Setup DbContext and DbSet mock  
            var dbContextMock = new Mock<SpaceParkContext>();
            var dbSetMock = new Mock<DbSet<SpaceshipModel>>();
            dbSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).Returns(Task.FromResult(new SpaceshipModel()));
            dbContextMock.Setup(s => s.Set<SpaceshipModel>()).Returns(dbSetMock.Object);

            //Setup logger mock
            var logger = Mock.Of<ILogger<SpaceshipRepo>>();
            //Execute method of SUT (ProductsRepository)  
            var spaceShipRepository = new SpaceshipRepo(dbContextMock.Object, logger);
            var spaceShip = spaceShipRepository.GetSpaceshipById(1).Result;

            //Assert  
            Assert.NotNull(spaceShip);
            Assert.IsAssignableFrom<SpaceshipModel>(spaceShip);
        }
    }
}

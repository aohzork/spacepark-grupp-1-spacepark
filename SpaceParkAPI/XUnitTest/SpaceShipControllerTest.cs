using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SpaceParkAPI.Db_Context;
using SpaceParkAPI;
using SpaceParkAPI.Models;
using Moq.EntityFrameworkCore;
using SpaceParkAPI.Repos;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SpaceParkAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace XUnitTest
{
    public class SpaceShipControllerTest
    {
        [Fact]
        public async Task GetSpaceshipById_Status200OKIsType_ReturnedIdEqualsInput()
        {
            // Arrange
            int expected = 1;
            var mockRepo = new Mock<ISpaceshipRepo>();
            mockRepo.Setup(repo => repo.GetSpaceshipById(expected)).Returns(Task.FromResult(GetTestSession()));
            var controller = new SpaceshipController(mockRepo.Object);

            // Act
            var result = await controller.GetSpaceshipById(expected);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SpaceshipModel>(okResult.Value);
            var actual = returnValue;
            Assert.Equal(expected, actual.ID);
            Assert.Contains(expected.ToString(), actual.ID.ToString());
        }

        private SpaceshipModel GetTestSession()
        {
            var session = new SpaceshipModel()
            {
                ID = 1
            };

            return session;
        }
    }
}

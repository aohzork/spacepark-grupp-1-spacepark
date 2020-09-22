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
    public class ParkingSpaceControllerTest
    {
        [Fact]
        public async Task ForSession_ReturnsIdeasForSession()
        {
            // Arrange
            int testParkingSpaceId = 1;
            var mockRepo = new Mock<IParkingSpaceRepo>();
            mockRepo.Setup(repo => repo.GetParkingSpaceById(testParkingSpaceId)).Returns(Task.FromResult(GetTestSession()));
            var controller = new ParkingSpaceController(mockRepo.Object);

            // Act
            var result = await controller.GetParkingSpaceById(testParkingSpaceId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<ParkingSpaceModel>(okResult.Value);
            var parkingSpace = returnValue;
            Assert.Equal(1, parkingSpace.ID);
        }

        private ParkingSpaceModel GetTestSession()
        {
            var session = new ParkingSpaceModel()
            {                
                ID = 1
            };

            return session;
        }

        //[Fact]
        //public async Task ForSession_ReturnsIdeasForSession()
        //{
        //    // Arrange
        //    int testSessionId = 123;
        //    var mockRepo = new Mock<IBrainstormSessionRepository>();
        //    mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId)).Returns(Task.FromResult(GetTestSession()));
        //    var controller = new IdeasController(mockRepo.Object);

        //    // Act
        //    var result = await controller.ForSession(testSessionId);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var returnValue = Assert.IsType<List<IdeaDTO>>(okResult.Value);
        //    var idea = returnValue.FirstOrDefault();
        //    Assert.Equal("One", idea.Name);
        //}

        //private BrainstormSession GetTestSession()
        //{
        //    var session = new BrainstormSession()
        //    {
        //        DateCreated = new DateTime(2016, 7, 2),
        //        Id = 1,
        //        Name = "Test One"
        //    };

        //    var idea = new Idea() { Name = "One" };
        //    session.AddIdea(idea);
        //    return session;
        //}
    }
}

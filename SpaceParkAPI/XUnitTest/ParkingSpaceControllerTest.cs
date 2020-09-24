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
        public async Task GetParkingSpaceById_Status200OKIsType_ReturnedIdEqualsInput()
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
            Assert.Contains(1.ToString(), parkingSpace.ID.ToString());
        }   

        private ParkingSpaceModel GetTestSession()
        {
            var session = new ParkingSpaceModel()
            {                
                ID = 1
            };

            return session;
        }
    }
}

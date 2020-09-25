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
    public class PersonControllerTest
    {
        [Theory]
        [InlineData("Erik", "Erik")]
        public async Task GetPersonByName_Status200OKIsType_ReturnedNameContains(string input, string expectedName)
        {
            {
                // Arrange
                var mockRepo = new Mock<IPersonRepo>();
                mockRepo.Setup(repo => repo.GetPersonByName(input)).Returns(Task.FromResult(GetTestSession()));
                var controller = new PersonController(mockRepo.Object);

                // Act
                var result = await controller.GetPersonByName(input);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result);
                var returnValue = Assert.IsType<PersonModel>(okResult.Value);
                var person = returnValue;
                Assert.Equal(expectedName, person.Name);
                Assert.Contains(expectedName, person.Name);
            }           
        }

        private PersonModel GetTestSession()
        {
            var session = new PersonModel { ID = 1, Name = "Erik" };

            return session;
        }



    }
}

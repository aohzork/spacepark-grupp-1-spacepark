using Microsoft.AspNetCore.Mvc;
using Moq;
using SpaceParkAPI.Controllers;
using SpaceParkAPI.Models;
using SpaceParkAPI.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTest
{
    public class PersonControllerTest
    {
        [Theory]
        [InlineData("Erik", "Erik")]
        [InlineData("Sofia", "Sofia")]
        [InlineData("Janne", "Janne")]
        public async Task GetPersonByName_Status200OKIsType_ReturnedNameContains(string input, string expectedName)
        {
            {
                // Arrange
                //int testParkingSpaceId = 1;
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

        private List<PersonModel> GetTestSession()
        {
            List<PersonModel> session = new List<PersonModel>();
            session.Add(new PersonModel { ID = 1, Name = "Erik" });
            session.Add(new PersonModel { ID = 2, Name = "Janne" });
            session.Add(new PersonModel { ID = 3, Name = "Sofia" });

            return session;
        }



    }
}

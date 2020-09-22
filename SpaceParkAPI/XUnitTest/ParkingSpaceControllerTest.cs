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

namespace XUnitTest
{
    class ParkingSpaceControllerTest
    {

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
}

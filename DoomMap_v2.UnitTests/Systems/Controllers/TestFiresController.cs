using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using DoomMap_v2.Services;
using DoomMap_v2.UnitTests.Fixtures;
using DoomMap_v2.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using DoomMap_v2.Models;

namespace DoomMap_v2.UnitTests.Systems.Controllers
{
    public class TestFiresController
    {

        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {

            // arrange
            var mockFiresService = new Mock<IFiresService>();
            mockFiresService.Setup(service => service.GetAllFires())
                .ReturnsAsync(FiresFixture.GetTestFires());

            var sut = new FiresController(mockFiresService.Object);


            // act
            var result = (OkObjectResult)await sut.GetAllFires();

            // assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetFireByID_OnSuccess_ReturnsStatusCode200()
        {

            // arrange
            var mockFiresService = new Mock<IFiresService>();
            var mockGid = FiresFixture.GetTestFireByID().First().Gid;

            mockFiresService.Setup(service => service.GetFireByID(mockGid))
                .ReturnsAsync(FiresFixture.GetTestFireByID());

            var sut = new FiresController(mockFiresService.Object);


            // act
            var result = (OkObjectResult)await sut.GetFireByID(mockGid.ToString());

            // assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_OnSuccess_InvokesFiresServiceOnce()
        {
            // arrange
            var mockFiresService = new Mock<IFiresService>();
            mockFiresService
                .Setup(service => service.GetAllFires())
                .ReturnsAsync(new List<Fire>());

            var sut = new FiresController(mockFiresService.Object);

            
            // act
            var result = await sut.GetAllFires();

            // assert
            mockFiresService.Verify(service => service.GetAllFires(), Times.Once());

        }


        [Fact]

        public async Task Get_OnSuccess_ReturnsListOfFires()
        {

            // arrange
            var mockFiresService = new Mock<IFiresService>();
            mockFiresService.Setup(service => service.GetAllFires())
                .ReturnsAsync(FiresFixture.GetTestFires());

            var sut = new FiresController(mockFiresService.Object);

            // act
            var result = await sut.GetAllFires();

            // assert
            result.Should().BeOfType<OkObjectResult>();

            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<Fire>>();

        }

        [Fact]
        public async Task Get_OnNoFiresFound_Returns_404()
        {
            // arrange
            var mockFiresService = new Mock<IFiresService>();
            mockFiresService.Setup(service => service.GetAllFires())
                .ReturnsAsync(new List<Fire>());


            var sut = new FiresController(mockFiresService.Object);

            // act
            var result = await sut.GetAllFires();

            // assert
            result.Should().BeOfType<NotFoundResult>();

            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);


        }



    }
}

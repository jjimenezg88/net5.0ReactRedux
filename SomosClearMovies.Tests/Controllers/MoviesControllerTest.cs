using Moq;
using System;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomosClearMovies.Controllers;
using SomosClearMovies.Core.Interfaces;
using SomosClearMovies.Models.View;
using MediatR;
using SomosClearMovies.Core.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SomosClearMovies.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTest
    {
        private Mock<IMediator> _mockMediator;
        private Mock<ILogger<MoviesController>> _mockLogger;
        private MoviesController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<MoviesController>>();
            _controller = new MoviesController(_mockMediator.Object, _mockLogger.Object);
        }

        [TestMethod]
        public void Instance_MovieRepository_Throws_ArgumentNullException()
        {
            Action action = () =>
            {
                new MoviesController(null, null);
            };

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("mediator");
        }

        [TestMethod]
        public void Instance_Logger_Throws_ArgumentNullException()
        {
            Action action = () =>
            {
                new MoviesController(_mockMediator.Object, null);
            };

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("logger");
        }

        [TestMethod]
        public async Task GetMovies_MovieRepository_Throws_Exception()
        {
            _mockMediator.Setup(mock => mock.Send(It.IsAny<GetMovieListQuery>(), default(CancellationToken)))
            .ThrowsAsync(new Exception("Exception Test"));

            var response = await _controller.GetMovies(string.Empty, string.Empty, string.Empty);
            response.Should().BeOfType<ObjectResult>();
            var result = (ObjectResult)response;
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            result.Value.Should().Be("Exception Test");
        }

        [TestMethod]
        public async Task GetMovies_Ok()
        {
            IEnumerable<MovieDetailed> testData = new List<MovieDetailed> {
                new MovieDetailed()
            };

            _mockMediator.Setup(mock => mock.Send(It.IsAny<GetMovieListQuery>(), default(CancellationToken)))
                .ReturnsAsync(testData);

            var response = await _controller.GetMovies(string.Empty, string.Empty, string.Empty);
            response.Should().BeOfType<OkObjectResult>();
            var result = (OkObjectResult)response;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}

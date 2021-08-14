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

namespace SomosClearMovies.Tests.Controllers
{
    [TestClass]
    public class MoviesControllerTest
    {
        private Mock<IMovieRepository> _mockMovieRepository;
        private Mock<ILogger<MoviesController>> _mockLogger;
        private MoviesController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockLogger = new Mock<ILogger<MoviesController>>();
            _controller = new MoviesController(_mockMovieRepository.Object, _mockLogger.Object);
        }

        [TestMethod]
        public void Instance_MovieRepository_Throws_ArgumentNullException()
        {
            Action action = () =>
            {
                new MoviesController(null, null);
            };

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("movieRepository");
        }

        [TestMethod]
        public void Instance_Logger_Throws_ArgumentNullException()
        {
            Action action = () =>
            {
                new MoviesController(_mockMovieRepository.Object, null);
            };

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("logger");
        }

        [TestMethod]
        public void GetMovies_MovieRepository_Throws_Exception()
        {
            _mockMovieRepository.Setup(mock => mock.GetMovies(It.IsAny<GetMoviesRequest>()))
                .Throws(new Exception("Exception Test"));

            var response = _controller.GetMovies(string.Empty, string.Empty, string.Empty);
            response.Should().BeOfType<ObjectResult>();
            var result = (ObjectResult)response;
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            result.Value.Should().Be("Exception Test");
        }

        [TestMethod]
        public void GetMovies_Ok()
        {
            IEnumerable<MovieDetailed> testData = new List<MovieDetailed> {
                new MovieDetailed()
            };
            _mockMovieRepository.Setup(mock => mock.GetMovies(It.IsAny<GetMoviesRequest>()))
                .Returns(testData);

            var response = _controller.GetMovies(string.Empty, string.Empty, string.Empty);
            response.Should().BeOfType<OkObjectResult>();
            var result = (OkObjectResult)response;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}

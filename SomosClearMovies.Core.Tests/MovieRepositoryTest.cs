using Moq;
using System;
using System.Linq;
using FluentAssertions;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomosClearMovies.Models.Data;
using SomosClearMovies.Models.View;
using SomosClearMovies.Infrastructure.Interfaces;

namespace SomosClearMovies.Core.Tests
{
    [TestClass]
    public class MovieRepositoryTest
    {
        private Mock<IMoviesDbContext> _mockMoviesDbContext;
        private MovieRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _mockMoviesDbContext = new Mock<IMoviesDbContext>();
            _repository = new MovieRepository(_mockMoviesDbContext.Object);
        }

        [TestMethod]
        public void Instance_Throws_ArgumentNullException()
        {
            Action action = () =>
            {
                new MovieRepository(null);
            };

            action.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("moviesDbContext");
        }

        [TestMethod]
        public void GetMovies_Ok()
        {
            List<MovieActors> testData = new List<MovieActors> {
                new MovieActors
                {
                    IdMovieActors = 1,
                    IdMovie = 1,
                    Movie = new Movie {
                        IdMovie = 1,
                        Title = "Movie 1",
                        Genre = "Genere"
                    },
                    Actor = new Actor
                    {
                        IdActor = 1,
                        Name = "Actor 1"
                    }
                },
                new MovieActors
                {
                    IdMovieActors = 2,
                    IdMovie = 1,
                    Actor = new Actor
                    {
                        IdActor = 2,
                        Name = "Actor 2"
                    }
                }
            };
            _mockMoviesDbContext.Setup(mock => mock.GetMovies(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(testData);

            var result = _repository.GetMovies(new GetMoviesRequest());
            result.Count().Should().Be(1);
            result.FirstOrDefault().Actors.Count().Should().Be(2);
        }
    }
}

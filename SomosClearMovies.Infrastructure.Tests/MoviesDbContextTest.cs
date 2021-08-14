using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SomosClearMovies.Infrastructure.Helpers;
using System;
using System.Linq;

namespace SomosClearMovies.Infrastructure.Tests
{
    [TestClass]
    public class MoviesDbContextTest
    {
        private MoviesDbContext _dbContext;
        [TestInitialize]
        public void Setup()
        {
            _dbContext = new MoviesDbContext(new DbContextOptionsBuilder<MoviesDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options);
            TestData.AddTestData(_dbContext);
        }

        [TestMethod]
        public void GetMovies_All_Empty()
        {
            var result = _dbContext.GetMovies(string.Empty, string.Empty, string.Empty);
            result.Count.Should().Be(30);
        }

        [TestMethod]
        public void GetMovies_Title_Avengers()
        {
            var txtSearch = "Avengers";
            var result = _dbContext.GetMovies(txtSearch, string.Empty, string.Empty);
            result.Count.Should().Be(9);
            result.FirstOrDefault().Movie.Title.Should().ContainEquivalentOf(txtSearch, AtLeast.Once());
        }

        [TestMethod]
        public void GetMovies_Genere_Action()
        {
            var txtSearch = "Action";
            var result = _dbContext.GetMovies(string.Empty, txtSearch, string.Empty);
            result.Count.Should().Be(3);
            result.FirstOrDefault().Movie.Genre.Should().ContainEquivalentOf(txtSearch, AtLeast.Once());
        }

        [TestMethod]
        public void GetMovies_ActorName_Robert()
        {
            var txtSearch = "Robert";
            var result = _dbContext.GetMovies(string.Empty, string.Empty, txtSearch);
            result.Count.Should().Be(4);
            result.FirstOrDefault().Actor.Name.Should().ContainEquivalentOf(txtSearch, AtLeast.Once());
        }
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using SomosClearMovies.Models.View;
using SomosClearMovies.Models.Data;
using SomosClearMovies.Core.Interfaces;
using SomosClearMovies.Infrastructure.Interfaces;

namespace SomosClearMovies.Core
{
    /// <summary>
    /// Movie Repository
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        private readonly IMoviesDbContext _moviesDbContext;

        /// <summary>
        /// Create new instance of <see cref="MovieRepository"/> class.
        /// </summary>
        /// <param name="moviesDbContext"></param>
        public MovieRepository(IMoviesDbContext moviesDbContext)
        {
            _moviesDbContext = moviesDbContext ?? throw new ArgumentNullException(nameof(moviesDbContext));
        }

        /// <summary>
        /// Add Movie
        /// </summary>
        /// <param name="movie"><see cref="Movie"/></param>
        /// <returns>A <see cref="MovieDetailed"/></returns>
        public MovieDetailed AddMovie(Movie movie) =>
            _moviesDbContext.AddMovie(movie).GroupBy(movie => movie.IdMovie)
                .Select(movie => new MovieDetailed
                {
                    Title = movie.FirstOrDefault().Movie.Title,
                    Genre = movie.FirstOrDefault().Movie.Genre,
                    Actors = movie.Select(x => x.Actor.Name)
                }).FirstOrDefault();

        /// <summary>
        /// Get Actor by Expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>An <see cref="Actor"/></returns>
        public Actor GetActorBy(Expression<Func<Actor, bool>> expression) =>
            _moviesDbContext.Context.Actors.FirstOrDefault(expression);

        /// <summary>
        /// Get Movies
        /// </summary>
        /// <param name="request">Get Movies Request</param>
        /// <returns>A List of <see cref="MovieDetailed"/></returns>
        public IEnumerable<MovieDetailed> GetMovies(GetMoviesRequest request)
        {
            var result = _moviesDbContext.GetMovies(request.MovieTitle, request.MovieGenre, request.ActorName)
                .GroupBy(movie => movie.IdMovie)
                .Select(movie => new MovieDetailed
                {
                    Title = movie.FirstOrDefault().Movie.Title,
                    Genre = movie.FirstOrDefault().Movie.Genre,
                    Actors = movie.Select(x => x.Actor.Name)
                });

            return result;
        }
    }
}

using System.Collections.Generic;
using SomosClearMovies.Models.Data;

namespace SomosClearMovies.Infrastructure.Interfaces
{
    /// <summary>
    /// Movies DbContext Contract
    /// </summary>
    public interface IMoviesDbContext
    {
        /// <summary>
        /// Movies Database Context
        /// </summary>
        MoviesDbContext Context { get; }

        /// <summary>
        /// Get Movies
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <param name="genere">Movie Genere</param>
        /// <param name="actorName">Actor Name</param>
        /// <returns>A list of <see cref="MovieActors"/></returns>
        List<MovieActors> GetMovies(string title, string genere, string actorName);

        /// <summary>
        /// Add Movie
        /// </summary>
        /// <param name="movie">An object of <see cref="Movie"/></param>
        /// <returns>An object of <see cref="MovieActors"/></returns>
        List<MovieActors> AddMovie(Movie movie);
    }
}

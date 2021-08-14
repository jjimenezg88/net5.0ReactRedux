using System.Collections.Generic;
using SomosClearMovies.Models.View;

namespace SomosClearMovies.Core.Interfaces
{
    /// <summary>
    /// Movie Repository Contract
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Get Movies
        /// </summary>
        /// <param name="request">Get Movies Request</param>
        /// <returns>A List of <see cref="MovieDetailed"/></returns>
        IEnumerable<MovieDetailed> GetMovies(GetMoviesRequest request);
    }
}

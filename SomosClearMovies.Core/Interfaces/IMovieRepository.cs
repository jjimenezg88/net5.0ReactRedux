using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SomosClearMovies.Models.Data;
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

        /// <summary>
        /// Add Movie
        /// </summary>
        /// <param name="movie"><see cref="Movie"/></param>
        /// <returns>A <see cref="MovieDetailed"/></returns>
        MovieDetailed AddMovie(Movie movie);

        /// <summary>
        /// Get Actor by Expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>An <see cref="Actor"/></returns>
        Actor GetActorBy(Expression<Func<Actor,bool>> expression);
    }
}

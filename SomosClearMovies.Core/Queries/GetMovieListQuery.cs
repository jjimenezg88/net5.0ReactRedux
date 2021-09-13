using MediatR;
using System.Collections.Generic;
using SomosClearMovies.Models.View;

namespace SomosClearMovies.Core.Queries
{
    /// <summary>
    /// Get Movie List Query Request 
    /// </summary>
    public record GetMovieListQuery(string MovieTitle, string MovieGenre, string ActorName) : IRequest<IEnumerable<MovieDetailed>>;
}

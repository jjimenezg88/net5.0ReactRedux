using MediatR;
using SomosClearMovies.Models.Data;

namespace SomosClearMovies.Core.Queries
{
    /// <summary>
    /// Get Actor By Name Query
    /// </summary>
    public record GetActorByNameQuery(string Name): IRequest<Actor>;
}

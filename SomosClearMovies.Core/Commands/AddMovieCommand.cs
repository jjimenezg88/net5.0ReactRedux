using MediatR;
using System.Collections.Generic;
using SomosClearMovies.Models.View;

namespace SomosClearMovies.Core.Commands
{
    /// <summary>
    /// Add Movie Command
    /// </summary>
    public record AddMovieCommand(string Title, string Genre, IEnumerable<string> Actors) : IRequest<MovieDetailed>;
}

using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SomosClearMovies.Models.Data;
using SomosClearMovies.Core.Queries;
using SomosClearMovies.Core.Interfaces;

namespace SomosClearMovies.Core.Handlers
{
    /// <summary>
    /// Get Actor By Name Handler
    /// </summary>
    public class GetActorByNameHandler : IRequestHandler<GetActorByNameQuery, Actor>
    {
        private readonly IMovieRepository _movieRepository;

        /// <summary>
        /// Create new instance of <see cref="GetActorByNameHandler"/>
        /// </summary>
        /// <param name="movieRepository"></param>
        public GetActorByNameHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <param name="request"><see cref="GetActorByNameQuery"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>An <see cref="Actor"/></returns>
        public Task<Actor> Handle(GetActorByNameQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_movieRepository.GetActorBy(actor => actor.Name.Equals(request.Name)));
    }
}

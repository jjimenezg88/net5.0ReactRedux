using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SomosClearMovies.Models.Data;
using SomosClearMovies.Models.View;
using SomosClearMovies.Core.Queries;
using SomosClearMovies.Core.Commands;
using SomosClearMovies.Core.Interfaces;

namespace SomosClearMovies.Core.Handlers
{
    /// <summary>
    /// Add Movie Handler
    /// </summary>
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, MovieDetailed>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMediator _mediator;
        /// <summary>
        /// Create new instance of <see cref=" AddMovieHandler"/> class.
        /// </summary>
        /// <param name="movieRepository"></param>
        /// <param name="mediator"></param>
        public AddMovieHandler(IMovieRepository movieRepository, IMediator mediator)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Handle Request
        /// </summary>
        /// <param name="request"><see cref="AddMovieCommand"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>A <see cref="MovieDetailed"/></returns>
        public async Task<MovieDetailed> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            List<Actor> actors = new();
            foreach (var name in request.Actors)
            {
                var actor = await _mediator.Send(new GetActorByNameQuery(name));
                if (actor != null)
                {
                    actors.Add(actor);
                }
                else
                {
                    actors.Add(new Actor { Name = name });
                }
            }

            return _movieRepository.AddMovie(new Movie
            {
                Title = request.Title,
                Genre = request.Genre,
                Actors = actors.Select(actor => new MovieActors { Actor = actor }).ToList()
            });
        }
    }
}

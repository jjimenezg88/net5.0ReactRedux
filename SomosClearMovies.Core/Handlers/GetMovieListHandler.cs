using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SomosClearMovies.Models.View;
using SomosClearMovies.Core.Queries;
using SomosClearMovies.Core.Interfaces;

namespace SomosClearMovies.Core.Handlers
{
    /// <summary>
    /// Get Movie List Handler
    /// </summary>
    public class GetMovieListHandler : IRequestHandler<GetMovieListQuery, IEnumerable<MovieDetailed>>
    {
        private readonly IMovieRepository _movieRepository;

        /// <summary>
        /// Create new instance of <see cref="GetMovieListHandler"/> class.
        /// </summary>
        /// <param name="movieRepository"></param>
        public GetMovieListHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
        }

        /// <summary>
        /// Handle Request
        /// </summary>
        /// <param name="request"><see cref="GetMovieListQuery"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>A <see cref="IEnumerable{T}"/> of <see cref="MovieDetailed"/></returns>
        public Task<IEnumerable<MovieDetailed>> Handle(GetMovieListQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_movieRepository.GetMovies(new GetMoviesRequest
            {
                ActorName = request.ActorName,
                MovieGenre = request.MovieGenre,
                MovieTitle = request.MovieTitle
            }));
    }
}

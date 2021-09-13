using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SomosClearMovies.Models.View;
using SomosClearMovies.Core.Queries;
using SomosClearMovies.Core.Commands;

namespace SomosClearMovies.Controllers
{
    /// <summary>
    /// Movies Controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<MoviesController> _logger;

        /// <summary>
        /// Create new instance of <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="movieRepository"></param>
        /// <param name="logger"></param>
        public MoviesController(IMediator mediator, ILogger<MoviesController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get Movies
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <param name="genere">Movie Genere</param>
        /// <param name="actorName">Actor Movie</param>
        /// <returns>Colletion of <see cref="MovieDetailed"/></returns>
        [HttpGet]
        public async Task<IActionResult> GetMovies(string title, string genere, string actorName)
        {
            IEnumerable<MovieDetailed> response;
            try
            {
                response = await _mediator.Send(new GetMovieListQuery(title, genere, actorName));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(response);
        }

        /// <summary>
        /// Add Movie
        /// </summary>
        /// <param name="movie"><see cref="MovieDetailed"/></param>
        /// <returns><see cref="MovieDetailed"/></returns>
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] MovieDetailed movie)
        {
            MovieDetailed result;
            try
            {
                result = await _mediator.Send(new AddMovieCommand(movie.Title, movie.Genre, movie.Actors));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(result);
        }
    }
}

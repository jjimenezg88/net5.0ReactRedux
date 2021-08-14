using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using SomosClearMovies.Models.View;
using SomosClearMovies.Core.Interfaces;

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
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MoviesController> _logger;

        /// <summary>
        /// Create new instance of <see cref="MoviesController"/> class.
        /// </summary>
        /// <param name="movieRepository"></param>
        /// <param name="logger"></param>
        public MoviesController(IMovieRepository movieRepository, ILogger<MoviesController> logger)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
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
        public IActionResult GetMovies(string title, string genere, string actorName)
        {
            IEnumerable<MovieDetailed> response;
            try
            {
                response = _movieRepository.GetMovies(new GetMoviesRequest
                {
                    MovieTitle = title,
                    MovieGenre = genere,
                    ActorName = actorName
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(response);
        }
    }
}

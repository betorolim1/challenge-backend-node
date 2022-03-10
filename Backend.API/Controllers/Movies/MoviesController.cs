using Backend.Handler.Handlers.Interfaces;
using Backend.Handler.Movies.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.Controllers.Movies
{
    [Route(Routes.Movies.V1)]
    public class MoviesController : ControllerBase
    {
        public IMoviesHandler _moviesHandler { get; set; }

        public MoviesController(IMoviesHandler moviesHandler)
        {
            _moviesHandler = moviesHandler;
        }

        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetMoviesByTitleAsync([FromRoute] string title, [FromQuery] int? year, [FromQuery] int plot = 0)
        {
            var command = new GetMoviesByTitleCommand
            {
                Plot = plot,
                Title = title,
                Year = year
            };

            var result = await _moviesHandler.GetMoviesByTitleAsync(command);

            if (!_moviesHandler.Valid)
                return BadRequest(_moviesHandler.Notifications);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoviesByIdAsync([FromRoute] string id, [FromQuery] int plot = 0)
        {
            var command = new GetMoviesByIdCommand
            {
                Id = id,
                Plot = plot
            };

            var result = await _moviesHandler.GetMoviesByIdAsync(command);

            if (!_moviesHandler.Valid)
                return BadRequest(_moviesHandler.Notifications);

            return Ok(result);
        }
    }
}

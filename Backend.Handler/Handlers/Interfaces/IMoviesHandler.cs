using Backend.Handler.Movies.Commands;
using Backend.Handler.Movies.Result;
using Backend.Handler.Validator.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Handler.Handlers.Interfaces
{
    public interface IMoviesHandler : INotifiable
    {
        public Task<MovieResult> GetMoviesByTitleAsync(GetMoviesByTitleCommand command);
    }
}

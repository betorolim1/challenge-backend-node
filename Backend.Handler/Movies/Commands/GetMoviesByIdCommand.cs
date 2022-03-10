using Backend.Handler.Movies.Commands.Base;

namespace Backend.Handler.Movies.Commands
{
    public class GetMoviesByIdCommand : MoviesCommandBase
    {
        public string Id { get; set; }
    }
}

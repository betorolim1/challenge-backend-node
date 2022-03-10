using Backend.Handler.Movies.Commands.Base;

namespace Backend.Handler.Movies.Commands
{
    public class GetMoviesByTitleCommand : MoviesCommandBase
    {
        public string Title { get; set; }
    }
}

using Backend.Handler.Handlers.Interfaces;
using Backend.Handler.Movies.Commands;
using Backend.Handler.Movies.Result;
using Backend.Handler.Services.OMDb;
using Backend.Handler.Services.OMDb.Response;
using Backend.Handler.Validator;
using Backend.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Handler.Handlers
{
    public class MoviesHandler : Notifiable, IMoviesHandler
    {
        private IOMDbService _IOMDbService { get; set; }

        public MoviesHandler(IOMDbService iOMDbService)
        {
            _IOMDbService = iOMDbService;
        }

        public async Task<MovieResult> GetMoviesByTitleAsync(GetMoviesByTitleCommand command)
        {
            if (string.IsNullOrEmpty(command.Title))
                AddNotification("Title must be filled");

            if (!Enum.IsDefined(typeof(PlotEnum), command.Plot))
                AddNotification("Plot is not valid");

            if (!Valid)
                return null;

            var response = await _IOMDbService.RequestMoviesAsync(command.Title, command.Year, command.Plot);

            var result = getMovieResult(response);

            return result;
        }

        private MovieResult getMovieResult(OMDbResponse response)
        {
            if (response is null)
                return null;

            var ratings = new List<RatingsResult>();

            foreach (var item in response.Ratings)
            {
                ratings.Add(new RatingsResult
                {
                    Source = item.Source,
                    Value = item.Value
                });
            }

            return new MovieResult
            {
                Actors = response.Actors,
                Awards = response.Awards,
                Country = response.Country,
                Director = response.Director,
                Genre = response.Genre,
                ImdbID = response.ImdbID,
                ImdbRating = response.ImdbRating,
                ImdbVotes = response.ImdbVotes,
                Language = response.Language,
                Metascore = response.Metascore,
                Plot = response.Plot,
                Poster = response.Poster,
                Rated = response.Rated,
                Ratings = ratings,
                Released = response.Released,
                Runtime = response.Runtime,
                Title = response.Title,
                TotalSeasons = response.TotalSeasons,
                Type = response.Type,
                Writer = response.Writer,
                Year = response.Year,
                BoxOffice = response.BoxOffice,
                DVD = response.DVD,
                Production = response.Production,
                Website = response.Website
            };
        }
    }
}

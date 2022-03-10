using Backend.Handler.Handlers;
using Backend.Handler.Movies.Commands;
using Backend.Handler.Services.OMDb;
using Backend.Handler.Services.OMDb.Response;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Test.Handlers
{
    public class MoviesHandlerTest
    {
        private Mock<IOMDbService> serviceMock = new Mock<IOMDbService>();

        // GetMoviesByTitleAsync

        [Fact]
        public async Task GetMoviesByTitleAsync_Deve_notificar_caso_titulo_seja_nulo()
        {
            var command = new GetMoviesByTitleCommand
            {
                Plot = 1,
                Year = 2020
            };

            var handler = newHander();

            var result = await handler.GetMoviesByTitleAsync(command);

            Assert.False(handler.Valid);
            Assert.Contains(handler.Notifications, nf => nf == "Title must be filled");

            verifyAll();
        }

        [Fact]
        public async Task GetMoviesByTitleAsync_Deve_notificar_caso_plot_seja_invalido()
        {
            var command = new GetMoviesByTitleCommand
            {
                Plot = 99,
                Year = 2020
            };

            var handler = newHander();

            var result = await handler.GetMoviesByTitleAsync(command);

            Assert.False(handler.Valid);
            Assert.Contains(handler.Notifications, nf => nf == "Plot is not valid");

            verifyAll();
        }

        [Fact]
        public async Task GetMoviesByTitleAsync_Deve_retornar_corretamente_quando_nao_tiver_dados()
        {
            var command = new GetMoviesByTitleCommand
            {
                Plot = 1,
                Year = 2020,
                Title = "TitleTest"
            };

            serviceMock.Setup(x => x.RequestMoviesAsync("TitleTest", 1, 2020));

            var handler = newHander();

            var result = await handler.GetMoviesByTitleAsync(command);

            Assert.True(handler.Valid);
            Assert.Null(result);

            verifyAll();
        }

        [Fact]
        public async Task GetMoviesByTitleAsync_Deve_retornar_corretamente_todos_os_dados()
        {
            var command = new GetMoviesByTitleCommand
            {
                Plot = 1,
                Year = 2020,
                Title = "TitleTest"
            };

            var ratings = new List<RatingsResponse>
            {
                new RatingsResponse
                {
                    Source = "SourceTest",
                    Value = "ValueTest"
                }
            };

            var response = new OMDbResponse
            {
                Actors = "ActorsTest",
                Awards = "AwardsTest",
                BoxOffice = "BoxOfficeTest",
                Country = "CountryTest",
                Director = "DirectorTest",
                DVD = "DVDTest",
                Error = "ErrorTest",
                Genre = "GenreTest",
                ImdbID = "ImdbIDTest",
                ImdbRating = "ImdbRatingTest",
                ImdbVotes = "ImdbVotesTest",
                Language = "LanguageTest",
                Metascore = "MetascoreTest",
                Plot = "PlotTest",
                Poster = "PosterTest",
                Production = "ProductionTest",
                Rated = "RatedTest",
                Ratings = ratings,
                Released = "ReleasedTest",
                Response = "ResponseTest",
                Runtime = "RuntimeTest",
                Title = "TitleTest",
                TotalSeasons = "TotalSeasonsTest",
                Type = "TypeTest",
                Website = "WebsiteTest",
                Writer = "WriterTest",
                Year = "YearTest"
            };

            serviceMock.Setup(x => x.RequestMoviesAsync("TitleTest", 1, 2020)).ReturnsAsync(response);

            var handler = newHander();

            var result = await handler.GetMoviesByTitleAsync(command);

            Assert.True(handler.Valid);
            Assert.NotNull(result);

            Assert.Equal("ActorsTest", result.Actors);
            Assert.Equal("AwardsTest", result.Awards);
            Assert.Equal("BoxOfficeTest", result.BoxOffice);
            Assert.Equal("CountryTest", result.Country);
            Assert.Equal("DirectorTest", result.Director);
            Assert.Equal("DVDTest", result.DVD);
            Assert.Equal("GenreTest", result.Genre);
            Assert.Equal("ImdbIDTest", result.ImdbID);
            Assert.Equal("ImdbRatingTest", result.ImdbRating);
            Assert.Equal("ImdbVotesTest", result.ImdbVotes);
            Assert.Equal("LanguageTest", result.Language);
            Assert.Equal("MetascoreTest", result.Metascore);
            Assert.Equal("PlotTest", result.Plot);
            Assert.Equal("PosterTest", result.Poster);
            Assert.Equal("ProductionTest", result.Production);
            Assert.Equal("RatedTest", result.Rated);
            Assert.Equal("ReleasedTest", result.Released);
            Assert.Equal("RuntimeTest", result.Runtime);
            Assert.Equal("TitleTest", result.Title);
            Assert.Equal("TotalSeasonsTest", result.TotalSeasons);
            Assert.Equal("TypeTest", result.Type);
            Assert.Equal("WebsiteTest", result.Website);
            Assert.Equal("WriterTest", result.Writer);
            Assert.Equal("YearTest", result.Year);

            Assert.Single(result.Ratings);
            Assert.Equal("SourceTest", result.Ratings.First().Source);
            Assert.Equal("ValueTest", result.Ratings.First().Value);

            verifyAll();
        }

        // GetMoviesByIdAsync

        [Fact]
        public async Task GetMoviesByIdAsync_Deve_notificar_caso_id_seja_nulo()
        {
            var command = new GetMoviesByIdCommand
            {
                Plot = 1
            };

            var handler = newHander();

            var result = await handler.GetMoviesByIdAsync(command);

            Assert.False(handler.Valid);
            Assert.Contains(handler.Notifications, nf => nf == "Id must be filled");

            verifyAll();
        }

        [Fact]
        public async Task GetMoviesByIdAsync_Deve_notificar_caso_plot_seja_invalido()
        {
            var command = new GetMoviesByIdCommand
            {
                Plot = 99,
                Id = "IdTest"
            };

            var handler = newHander();

            var result = await handler.GetMoviesByIdAsync(command);

            Assert.False(handler.Valid);
            Assert.Contains(handler.Notifications, nf => nf == "Plot is not valid");

            verifyAll();
        }

        [Fact]
        public async Task GetMoviesByIdAsync_Deve_retornar_corretamente_quando_nao_tiver_dados()
        {
            var command = new GetMoviesByIdCommand
            {
                Plot = 1,
                Id = "IdTest"
            };

            serviceMock.Setup(x => x.RequestMoviesAsync("IdTest", 1));

            var handler = newHander();

            var result = await handler.GetMoviesByIdAsync(command);

            Assert.True(handler.Valid);
            Assert.Null(result);

            verifyAll();
        }

        [Fact]
        public async Task GetMoviesByIdAsync_Deve_retornar_corretamente_todos_os_dados()
        {
            var command = new GetMoviesByIdCommand
            {
                Plot = 1,
                Id = "IdTest"
            };

            var ratings = new List<RatingsResponse>
            {
                new RatingsResponse
                {
                    Source = "SourceTest",
                    Value = "ValueTest"
                }
            };

            var response = new OMDbResponse
            {
                Actors = "ActorsTest",
                Awards = "AwardsTest",
                BoxOffice = "BoxOfficeTest",
                Country = "CountryTest",
                Director = "DirectorTest",
                DVD = "DVDTest",
                Error = "ErrorTest",
                Genre = "GenreTest",
                ImdbID = "ImdbIDTest",
                ImdbRating = "ImdbRatingTest",
                ImdbVotes = "ImdbVotesTest",
                Language = "LanguageTest",
                Metascore = "MetascoreTest",
                Plot = "PlotTest",
                Poster = "PosterTest",
                Production = "ProductionTest",
                Rated = "RatedTest",
                Ratings = ratings,
                Released = "ReleasedTest",
                Response = "ResponseTest",
                Runtime = "RuntimeTest",
                Title = "TitleTest",
                TotalSeasons = "TotalSeasonsTest",
                Type = "TypeTest",
                Website = "WebsiteTest",
                Writer = "WriterTest",
                Year = "YearTest"
            };

            serviceMock.Setup(x => x.RequestMoviesAsync("IdTest", 1)).ReturnsAsync(response);

            var handler = newHander();

            var result = await handler.GetMoviesByIdAsync(command);

            Assert.True(handler.Valid);
            Assert.NotNull(result);

            Assert.Equal("ActorsTest", result.Actors);
            Assert.Equal("AwardsTest", result.Awards);
            Assert.Equal("BoxOfficeTest", result.BoxOffice);
            Assert.Equal("CountryTest", result.Country);
            Assert.Equal("DirectorTest", result.Director);
            Assert.Equal("DVDTest", result.DVD);
            Assert.Equal("GenreTest", result.Genre);
            Assert.Equal("ImdbIDTest", result.ImdbID);
            Assert.Equal("ImdbRatingTest", result.ImdbRating);
            Assert.Equal("ImdbVotesTest", result.ImdbVotes);
            Assert.Equal("LanguageTest", result.Language);
            Assert.Equal("MetascoreTest", result.Metascore);
            Assert.Equal("PlotTest", result.Plot);
            Assert.Equal("PosterTest", result.Poster);
            Assert.Equal("ProductionTest", result.Production);
            Assert.Equal("RatedTest", result.Rated);
            Assert.Equal("ReleasedTest", result.Released);
            Assert.Equal("RuntimeTest", result.Runtime);
            Assert.Equal("TitleTest", result.Title);
            Assert.Equal("TotalSeasonsTest", result.TotalSeasons);
            Assert.Equal("TypeTest", result.Type);
            Assert.Equal("WebsiteTest", result.Website);
            Assert.Equal("WriterTest", result.Writer);
            Assert.Equal("YearTest", result.Year);

            Assert.Single(result.Ratings);
            Assert.Equal("SourceTest", result.Ratings.First().Source);
            Assert.Equal("ValueTest", result.Ratings.First().Value);

            verifyAll();
        }

        private MoviesHandler newHander() => new MoviesHandler(serviceMock.Object);

        private void verifyAll()
        {
            serviceMock.VerifyAll();
            serviceMock.VerifyNoOtherCalls();
        }
    }
}

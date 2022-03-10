using Backend.Controllers.Movies;
using Backend.Handler.Handlers.Interfaces;
using Backend.Handler.Movies.Commands;
using Backend.Handler.Movies.Result;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Test.Controllers
{
    public class MoviesControllerTest
    {
        private Mock<IMoviesHandler> _handler = new Mock<IMoviesHandler>();

        [Fact]
        public async Task GetMoviesByTitleAsync_Deve_retornar_OkResult()
        {
            _handler.Setup(x => x.GetMoviesByTitleAsync(It.IsAny<GetMoviesByTitleCommand>())).ReturnsAsync(new MovieResult());
            _handler.Setup(x => x.Valid).Returns(true);

            var controller = newController();

            var result = await controller.GetMoviesByTitleAsync("TitleTest", 2022, 0) as OkObjectResult;

            Assert.NotNull(result);

            _handler.VerifyAll();
            _handler.VerifyNoOtherCalls();
        }
        
        [Fact]
        public async Task GetMoviesByTitleAsync_Deve_retornar_BadRequest()
        {
            var notification = new List<string> { "NotificationTest" };

            _handler.Setup(x => x.GetMoviesByTitleAsync(It.IsAny<GetMoviesByTitleCommand>())).ReturnsAsync(new MovieResult());
            _handler.Setup(x => x.Valid).Returns(false);
            _handler.Setup(x => x.Notifications).Returns(notification);

            var controller = newController();

            var result = await controller.GetMoviesByTitleAsync("TitleTest", 2022, 0) as BadRequestObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.Equal(notification, result.Value);

            _handler.VerifyAll();
            _handler.VerifyNoOtherCalls();
        }

        private MoviesController newController() => new MoviesController(_handler.Object);
    }
}

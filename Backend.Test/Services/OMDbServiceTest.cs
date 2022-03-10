using Backend.Data.Services.OMDb;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Test.Services
{
    public class OMDbServiceTest
    {
        [Fact]
        public async Task Deve_retornar_excecao_caso_title_nao_seja_preenchido()
        {
            var service = newOMDbService();

            var exception = await Record.ExceptionAsync(() => service.RequestMoviesAsync(null, 2022, 1));

            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Title must be filled", exception.Message);
        }
        
        [Fact]
        public async Task Deve_retornar_excecao_caso_id_nao_seja_preenchido()
        {
            var service = newOMDbService();

            var exception = await Record.ExceptionAsync(() => service.RequestMoviesAsync(null, 1));

            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Id must be filled", exception.Message);
        }

        private OMDbService newOMDbService() => new OMDbService();
    }
}

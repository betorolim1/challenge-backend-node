﻿using Backend.Data.Services.OMDb;
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
            var service = NewOMDbService();

            var exception = await Record.ExceptionAsync(() => service.RequestMoviesAsync(null, 2022, 1));

            Assert.NotNull(exception);
            Assert.IsType<Exception>(exception);
            Assert.Equal("Title must be filled", exception.Message);
        }

        private OMDbService NewOMDbService() => new OMDbService();
    }
}
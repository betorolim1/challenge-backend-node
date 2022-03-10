using Backend.Data.Services.OMDb;
using Backend.Handler.Handlers;
using Backend.Handler.Handlers.Interfaces;
using Backend.Handler.Services.OMDb;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.API
{
    public static class ApplicationContainer
    {
        public static void AddApplicationContainer(this IServiceCollection service)
        {
            AddServices(service);
            AddHandlers(service);
        }

        private static void AddServices(IServiceCollection service)
        {
            service.AddTransient<IOMDbService, OMDbService>();
        }

        private static void AddHandlers(IServiceCollection service)
        {
            service.AddTransient<IMoviesHandler, MoviesHandler>();
        }
    }
}

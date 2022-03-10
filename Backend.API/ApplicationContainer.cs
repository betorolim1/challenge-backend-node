using Backend.Data.Services.OMDb;
using Backend.Handler.Services.OMDb;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.API
{
    public static class ApplicationContainer
    {
        public static void AddApplicationContainer(this IServiceCollection service)
        {
            AddServices(service);
        }

        private static void AddServices(IServiceCollection service)
        {
            service.AddTransient<IOMDbService, OMDbService>();
        }
    }
}

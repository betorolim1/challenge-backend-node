using Backend.Handler.Services.OMDb.Response;
using System.Threading.Tasks;

namespace Backend.Handler.Services.OMDb
{
    public interface IOMDbService
    {
        Task<OMDbResponse> RequestMoviesAsync(string title, int? year, byte plot);
    }
}

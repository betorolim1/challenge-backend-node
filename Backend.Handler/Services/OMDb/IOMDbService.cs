using Backend.Handler.Services.OMDb.Response;
using System.Threading.Tasks;

namespace Backend.Handler.Services.OMDb
{
    public interface IOMDbService
    {
        public Task<OMDbResponse> RequestMoviesAsync(string title, int plot, int? year);
        public Task<OMDbResponse> RequestMoviesAsync(string id, int plot);
    }
}

using Backend.Data.Services.OMDb.Request;
using Backend.Handler.Services.OMDb.Response;
using Refit;
using System.Threading.Tasks;

namespace Backend.Data.Services.OMDb.Refit
{
    public interface OMDbApi
    {
        [Get("")]
        Task<ApiResponse<OMDbResponse>> TaskOMDbAsync(OMDbMoviesRequest request);
    }
}

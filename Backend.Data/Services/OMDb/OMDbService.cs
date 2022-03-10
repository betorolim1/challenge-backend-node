using Backend.Data.Services.OMDb.Refit;
using Backend.Data.Services.OMDb.Request;
using Backend.Handler.Services.OMDb;
using Backend.Handler.Services.OMDb.Response;
using Backend.Shared.Enums;
using Backend.Shared.Logger;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Data.Services.OMDb
{
    public class OMDbService : IOMDbService
    {
        private const string ROUTE = "http://www.omdbapi.com";

        private const string API_KEY = "791413d";

        private const string MOVIE_NOT_FOUND = "Movie not found!";

        private readonly OMDbApi api;

        public OMDbService()
        {
            api = RestService.For<OMDbApi>(ROUTE);
        }

        public async Task<OMDbResponse> RequestMoviesAsync(string title, int? year, byte plot)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Title must be filled");

            var request = new OMDbMoviesRequest
            {
                plot = getPlot(plot),
                t = title,
                y = year.HasValue ? year.ToString() : string.Empty,
                Apikey = API_KEY
            };

            var response = await api.TaskOMDbAsync(request);

            if (!response.IsSuccessStatusCode)
                throw new Exception(response.Error.Message);

            if (response.Content != null && (response.Content.Response == "False" || !string.IsNullOrEmpty(response.Content.Error)))
            {
                if (response.Content.Error == MOVIE_NOT_FOUND)
                    return null;
                else
                    throw new Exception(response.Content.Error);
            }

            return response.Content;
        }

        private string getPlot(byte plot)
        {
            if (plot == (byte)PlotEnum.Full)
                return "full";

            return string.Empty;
        }
    }
}

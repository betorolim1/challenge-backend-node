﻿using System.Collections.Generic;

namespace Backend.Handler.Services.OMDb.Response
{
    public class OMDbResponse
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<RatingsResponse> Ratings { get; set; }
        public string Metascore { get; set; }
        public string ImdbRating { get; set; }
        public string ImdbVotes { get; set; }
        public string ImdbID { get; set; }
        public string Type { get; set; }
        public string TotalSeasons { get; set; }
        public string Response { get; set; }
        public string Error { get; set; }
    }

    public class RatingsResponse
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}

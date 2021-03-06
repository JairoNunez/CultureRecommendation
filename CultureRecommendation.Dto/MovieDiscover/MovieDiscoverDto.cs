﻿using System.Collections.Generic;

namespace CultureRecommendation.Dto.MovieDiscover
{

    public class MovieDiscoverDto
    {

        public int Page { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
        public List<Result> Results { get; set; }

    }

    public class Result
    {

        public double Popularity { get; set; }
        public int Vote_count { get; set; }
        public bool Video { get; set; }
        public string poster_path { get; set; }
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public List<object> Genre_ids { get; set; }
        public string Title { get; set; }
        public string Vote_average { get; set; }
        public string Overview { get; set; }
        public string Release_date { get; set; }

    }
    
}

using System.Collections.Generic;

namespace CultureRecommendation.Dto.MovieDiscover
{
    public class TvDiscoverDto
    {

        public int Page { get; set; }
        public int Total_results { get; set; }
        public int Total_pages { get; set; }
        public List<Result> Results { get; set; }

    }
   
}

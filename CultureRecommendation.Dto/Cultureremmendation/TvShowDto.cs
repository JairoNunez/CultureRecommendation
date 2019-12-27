
using System;

namespace CultureRecommendation.Dto
{

    public class TvShowDto : RecommendationDto
    {

         public int Seasons { get; set; }
         public int Episodes { get; set; }
         public Boolean Concluded { get; set; }

    }

}

using CultureRecommendation.Infraestructure;
using System.Collections.Generic;

namespace CultureRecommendation.Dto.Criteria
{
    public class TvShowsViewerRecomendationCriteria : CriteriaBase
    {
     
        public string Genre { get; private set; }
        public List<string> AssociatedKeywords { get; set; }

        public TvShowsViewerRecomendationCriteria(IFilterSettings settings,  string genre,
            List<string> associatedKeywords)
            : base(settings)
        {
           
            Genre = genre;      
            AssociatedKeywords = associatedKeywords;
        }
       
    }

}

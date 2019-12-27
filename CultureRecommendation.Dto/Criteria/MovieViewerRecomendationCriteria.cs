using CultureRecommendation.Infraestructure;
using System;
using System.Collections.Generic;

namespace CultureRecommendation.Dto.Criteria
{
    public class MovieViewerRecomendationCriteria : CriteriaBase
    {

        public DateTime? DateStart  { get; private set; }
        public string Genre { get; private set; }
        public List<string> AssociatedKeywords { get; set; }


        public MovieViewerRecomendationCriteria(IFilterSettings settings, DateTime? dateStart,
            string genre,List<string> associatedKeywords)
            : base(settings)
        {
            DateStart = dateStart;
            Genre = genre;      
            AssociatedKeywords = associatedKeywords;
        }
      
    }

}

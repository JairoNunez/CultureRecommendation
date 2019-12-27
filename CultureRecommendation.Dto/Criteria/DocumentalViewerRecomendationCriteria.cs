using CultureRecommendation.Infraestructure;
using System.Collections.Generic;

namespace CultureRecommendation.Dto.Criteria
{

    public class DocumentalViewerRecomendationCriteria : CriteriaBase
    {
        public List<string> Themes { get; set; }

        public DocumentalViewerRecomendationCriteria(IFilterSettings settings,List<string> themes)
            : base(settings)
        {
            Themes = themes;
        }
        
    }

}

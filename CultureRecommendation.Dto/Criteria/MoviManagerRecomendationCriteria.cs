using CultureRecommendation.Infraestructure;
using System;

namespace CultureRecommendation.Dto.Criteria
{

    public class MovieManagerRecomendationCriteria : CriteriaBase
    {
        public DateTime DateStart  { get; private set; }
        public DateTime DateEnd { get; private set; }
        public string Genre { get; private set; }
        public int Age { get; private set; }
        public bool InTheLocalCity { get; private set; }

        public MovieManagerRecomendationCriteria(IFilterSettings settings,
         DateTime dateSart, DateTime dateEnd, string gnre, int age, bool inTheLocalCity)
           : base(settings)
        {
            DateStart = dateSart;
            DateEnd = dateEnd;
            Genre = gnre;
            Age = age;
            InTheLocalCity = inTheLocalCity;
        }

    }

}

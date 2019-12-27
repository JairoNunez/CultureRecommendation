using CultureRecommendation.Constants;
using CultureRecommendation.Dto.Criteria;
using System;

namespace CultureRecommendation.Service
{

    public class RecomendationServiceValidator
    {

        public bool ValidMovieManagerSmartBillBoardSuggestedCriteria (MovieManagerSmartBillBoardSuggestedCriteria criteria)
        {
           ValidDates(criteria);
           ValidNumberOfScreems(criteria);

           return true;
        }

        public bool ValidDates (MovieManagerSmartBillBoardSuggestedCriteria criteria)
        {
            if (criteria.DateStart >= criteria.DateEnd)
            {
                throw new Exception(RecomendationConstants.Exception.DatesStartAndEndInvalid);
            }

            return true;
        }

        public bool ValidNumberOfScreems (MovieManagerSmartBillBoardSuggestedCriteria criteria)
        {
            if (!(criteria.SmallScreems > 0 || criteria.BigScreems > 0))
            {
                throw new Exception(RecomendationConstants.Exception.InvalidNumberOfScreens);
            }

            return true;
        }

    }

}

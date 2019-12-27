using System;

namespace CultureRecommendation.Dto.Criteria
{
    public class MovieManagerSmartBillBoardSuggestedCriteria
    {

        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public int SmallScreems { get; private set; }
        public int BigScreems { get; private set; }
        public bool InTheLocalCity { get; private set; }

       public MovieManagerSmartBillBoardSuggestedCriteria(
       DateTime dateStart, DateTime dateEnd, int smallScreems, int bigScreems, bool inTheLocalCity)       
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            SmallScreems = smallScreems;
            BigScreems = bigScreems;
            InTheLocalCity = inTheLocalCity;
        }
      
    }

}

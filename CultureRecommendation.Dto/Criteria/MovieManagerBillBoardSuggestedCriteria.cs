namespace CultureRecommendation.Dto.Criteria
{
    public class MovieManagerBillBoardSuggestedCriteria 
    {

        public int Weeks { get; private set; }     
        public int Screems { get; private set; }
        public bool InTheLocalCity { get; private set; }

        public MovieManagerBillBoardSuggestedCriteria(
        int  weeks, int screems, bool inTheLocalCity)
        {
            Weeks = weeks;
            Screems = screems;
            InTheLocalCity = inTheLocalCity;
        }
      
    }

}

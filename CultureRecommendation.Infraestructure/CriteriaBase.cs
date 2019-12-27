namespace CultureRecommendation.Infraestructure
{

    public class CriteriaBase
    {

        public IFilterSettings Settings { get; set; }

        public CriteriaBase(IFilterSettings settings)
        {

            Settings = settings;
        }

    }
    
}

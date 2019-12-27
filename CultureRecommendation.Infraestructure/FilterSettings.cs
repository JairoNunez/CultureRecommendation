using System.ComponentModel;

namespace CultureRecommendation.Infraestructure
{

    public class FilterSettings : IFilterSettings
    {

        #region Members

        [DefaultValue(false)]
        private bool _paginated = false;

        #endregion

        #region Properties

        public int Start { get; set; }
        public string SortBy { get; set; }

        #endregion

        public FilterSettings() { }

        public FilterSettings(int limit, int start)
            : this(true)
        {
            //_limit = limit;
            Start = start;
        }

        public FilterSettings(bool paginated)
        {
            _paginated = paginated;
        }

    }

}

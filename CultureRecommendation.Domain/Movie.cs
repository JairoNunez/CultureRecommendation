using System;

namespace CultureRecommendation.Domain
{

    public class Movie
    {

        #region Properties
        public int Id { get; set; }
        public string OriginalTitle { get; set; }    
        public DateTime ReleaseDate { get; set; }
        public string OriginalLanguage { get; set; }
        public bool Adult { get; set; }
        #endregion

    }

}

namespace CultureRecommendation.Dto.MovieDiscover
{
    public class CriteriaMovieDiscover
    {
        public string Language { get; set; }
        public string Region { get; set; }
        public string SortBy { get; set; }        
        public string CertificationCountry { get; set; }   
        public string Certification { get; set; }
        public string CertificationLte { get; set; }
        public string CertificationGte { get; set; }
        public string IncludeAdult { get; set; }
        public string IncludeVideo { get; set; }
        public int Page { get; set; }
        public int PrimaryReleaseYear { get; set; }
        public string PrimaryReleaseDateGte { get; set; }
        public string PrimaryReleaseDateLte { get; set; }
        public string ReleaseDateGte { get; set; }
        public string ReleaseDateLte { get; set; }
        public int WithReleaseType { get; set; }
        public int Year{ get; set; }
        public string VoteCountGte { get; set; }
        public string VoteCountLte { get; set; }
        public string VoteAverageGte { get; set; }
        public string WithCast { get; set; }
        public string WithCrew { get; set; }
        public string WithPeople { get; set; }
        public string WithCompanies { get; set; }
        public string WithGenres { get; set; }
        public string WithoutGenres { get; set; }
        public string WithKeywords { get; set; }
        public string WithoutKeywords { get; set; }
        public string WithRuntimeGte { get; set; }
        public string WithRuntimeLte { get; set; }
        public string WithOriginalLanguage { get; set; }

        public CriteriaMovieDiscover(bool desc = false, int page = 1,  string  withGenres = "")
        {
            Page = page;

            if (desc)
            {
                SortBy = "popularity.desc";
            }
            else
            {
                SortBy = "popularity.asc";
            }

            WithGenres = withGenres;

        }

    }

}

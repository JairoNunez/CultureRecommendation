using CultureRecommendation.Dto.MovieDiscover;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CultureRecommendation.Dto;
using CultureRecommendation.Infraestructure;

namespace CultureRecommendation.Service
{

    public interface IMovieDiscoverFacade
    {

        Task<PagedResult<TvShowDto>> GetTvShowRecomendations(List<string> keywords, string gnere, int page = 1);
        Task<PagedResult<RecommendationDto>> GetDocumentalsRecomendations(List<string> themes, int page = 1);
        Task<PagedResult<RecommendationDto>> GetMovieRecomendations(DateTime dateStart,  string gnere, int page = 1, List<string> Keywords = null, DateTime? dateEnd = null, int? age = null);
        Task<IEnumerable<RecommendationDto>> DiscoverMoviesOrderByPopularity(bool desc = false, int page = 1, bool notPopularity = false);
        Task<MovieDiscoverDto> DiscoverMovies (CriteriaMovieDiscover criteria);
        int GetPageSizeDicoverMovies();

    }

}

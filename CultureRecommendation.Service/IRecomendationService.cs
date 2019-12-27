using CultureRecommendation.Dto;
using CultureRecommendation.Dto.Criteria;
using CultureRecommendation.Infraestructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CultureRecommendation.Service
{

    public interface IRecomendationService
    {

        Task<PagedResult<RecommendationDto>> GetMoviesRecomendationsForViewers
        (MovieViewerRecomendationCriteria criteria);

        Task<PagedResult<RecommendationDto>> GetDocumentalsRecomendationsForViewers
           (DocumentalViewerRecomendationCriteria criteria);

        Task<PagedResult<TvShowDto>> GetTvShowsRecomendationsForViewers
            (TvShowsViewerRecomendationCriteria criteria);

        Task<PagedResult<RecommendationDto>> GetMoviesRecomendationsForManagers
            (MovieManagerRecomendationCriteria criteria);

        Task<IEnumerable<RecommendationDto>> GetSuggestedMoviesBillboard
               (MovieManagerBillBoardSuggestedCriteria criteria);

        Task <IEnumerable<RecommendationDto>> GetSuggestedMoviesSmartBillboard
             (MovieManagerSmartBillBoardSuggestedCriteria criteria);

    }

}

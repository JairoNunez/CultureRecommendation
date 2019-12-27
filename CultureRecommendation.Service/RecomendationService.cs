using CultureRecommendation.Data.Repositories;
using CultureRecommendation.Dto;
using CultureRecommendation.Dto.Criteria;
using CultureRecommendation.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CultureRecommendation.Service
{

    public class RecomendationService: IRecomendationService
    {

        private readonly IRecommendationRepository _repo;
        private readonly IMovieDiscoverFacade _movieDiscoverFacade;
      
        public RecomendationService(IRecommendationRepository repo, IMovieDiscoverFacade movieDiscoverFacade)
        {
            _repo = repo;
            _movieDiscoverFacade = movieDiscoverFacade;         
        }

        public async Task<PagedResult<RecommendationDto>> GetMoviesRecomendationsForViewers
        (MovieViewerRecomendationCriteria criteria)
        {
            var res = await _movieDiscoverFacade.GetMovieRecomendations(criteria.DateStart.Value, criteria.Genre, criteria.Settings.Start, criteria.AssociatedKeywords);

            return res;
        }

       public async Task<PagedResult<RecommendationDto>> GetDocumentalsRecomendationsForViewers
           (DocumentalViewerRecomendationCriteria criteria)
        {
            var res = await _movieDiscoverFacade.GetDocumentalsRecomendations(criteria.Themes, criteria.Settings.Start);

            return res;
        }

        public async Task<PagedResult<TvShowDto>> GetTvShowsRecomendationsForViewers
            (TvShowsViewerRecomendationCriteria criteria)
        {
            var res = await _movieDiscoverFacade.GetTvShowRecomendations(criteria.AssociatedKeywords, criteria.Genre, criteria.Settings.Start);

            return res;
        }

        public async Task<PagedResult<RecommendationDto>> GetMoviesRecomendationsForManagers
            (MovieManagerRecomendationCriteria criteria)
        {
            var res = await _movieDiscoverFacade.GetMovieRecomendations(criteria.DateStart,string.Empty, criteria.Settings.Start, null, criteria.DateEnd, criteria.Age);

            return res;
        }

        public async Task<IEnumerable<RecommendationDto>> GetSuggestedMoviesBillboard
               (MovieManagerBillBoardSuggestedCriteria criteria)
        {
            //TODO: Aquí hay que desarrollar el código para el caso de uso numero 9,  reutilizando los métodos privados existentes o creando nuevos
            //TODO: Se realizará además una llamda a un metodo de la fachada para obtener datos de la API pública de películas.
            throw new NotImplementedException();    
        }

        //Caso de uso 10
        public async Task<IEnumerable<RecommendationDto>> GetSuggestedMoviesSmartBillboard
             (MovieManagerSmartBillBoardSuggestedCriteria criteria)
        {
            var validatorCriteria = new RecomendationServiceValidator();
            validatorCriteria.ValidMovieManagerSmartBillBoardSuggestedCriteria(criteria);

            if (!criteria.InTheLocalCity)
            {
                var res =  await GetSuggestedMoviesSmartBillboardOutofCity(criteria);

                return res.ToList();
            }

            return GetSuggestedMoviesSmartBillboardInTheCity(criteria);
        }

        private IEnumerable<RecommendationDto> GetSuggestedMoviesSmartBillboardInTheCity
            (MovieManagerSmartBillBoardSuggestedCriteria criteria)
        {
            var recomendations= _repo.GetAllRecomendationSessionsOrderBySeatsSold();
            var weeks = GetumberWeeksBetweenDate(criteria.DateStart, criteria.DateEnd);

            var moviesSmartBillboardBigScreems = recomendations.Take(weeks * criteria.BigScreems).ToList();
            var moviesSmartBillboardSmallScreems = recomendations.Reverse().Take(weeks * criteria.SmallScreems).ToList();

            return UnionListMovieRecomendation(moviesSmartBillboardBigScreems, moviesSmartBillboardSmallScreems);
        }

        private  async Task<IEnumerable<RecommendationDto>> GetSuggestedMoviesSmartBillboardOutofCity
            (MovieManagerSmartBillBoardSuggestedCriteria criteria)
        {
            int weeks = GetumberWeeksBetweenDate(criteria.DateStart, criteria.DateEnd);

            int numberodCallsBigScreens = GetNumberCallsDependingPeriodByScreem(weeks, criteria.BigScreems);                    
            var  listBigScreems = await ExecuteCallsOrderByPopulate(numberodCallsBigScreens,false);
       
            int numberodCallsSmallScreens = GetNumberCallsDependingPeriodByScreem(weeks, criteria.SmallScreems);       
            var listSmallScreems = await ExecuteCallsOrderByPopulate(numberodCallsSmallScreens,true);

            var res = UnionListMovieRecomendation(listBigScreems.Take(weeks * criteria.BigScreems).ToList(), 
                                                  listSmallScreems.Take(weeks * criteria.SmallScreems).ToList());

            return res;
        }

        private List<RecommendationDto> UnionListMovieRecomendation (List<RecommendationDto> listBigScreems, List<RecommendationDto> listSmallScreems)
        {
            return listBigScreems.Union(listSmallScreems).ToList();
        }

        private async Task<IEnumerable<RecommendationDto>> ExecuteCallsOrderByPopulate(int numberCalls, bool notPopularity )
        {
            List<RecommendationDto> res = new List<RecommendationDto>();
            
            for (int i = 1; i <= numberCalls; i++)
            {
                var page = GetPageByNumberPeticions(i);

                var movies = await _movieDiscoverFacade.DiscoverMoviesOrderByPopularity(true ,page, notPopularity);

                res.AddRange(movies);

            }

            return res;
        }

        private int GetNumberCallsDependingPeriodByScreem(int weeks, int numberScreems)
        {                
            return GetNumberCalls(weeks * numberScreems, _movieDiscoverFacade.GetPageSizeDicoverMovies());
        }

        private int GetumberWeeksBetweenDate  (DateTime dateStart, DateTime dateEnd)
        {
            TimeSpan res = dateEnd - dateStart;
            int weeks = res.Days / 7;

            return weeks;
        }

        private int GetNumberCalls (int total, int sizePage)
        {
            decimal number = (decimal) total / (decimal) sizePage;

            int  res = Decimal.ToInt32(
                Math.Ceiling(number)
                );

            return res;
        }

        private int GetPageByNumberPeticions (int numberPeticions)
        {
            int pageSize = _movieDiscoverFacade.GetPageSizeDicoverMovies();
            decimal number = (decimal)numberPeticions / pageSize;

            int res = Decimal.ToInt32(
                Math.Ceiling(number)
                );

            return res;
        }

    }

}

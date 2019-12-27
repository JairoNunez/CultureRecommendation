using CultureRecommendation.Dto.Criteria;
using CultureRecommendation.Infraestructure;
using CultureRecommendation.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CultureRecommendation.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CultureRecommendationController : ControllerBase
    {

        private readonly IRecomendationService _service;

        public CultureRecommendationController (IRecomendationService service)
        {
            _service = service;
        }

        [HttpGet("Movies/Viewers")]
        public async Task<IActionResult> GetMoviesRecomendationsForViewers(FilterSettings settings,DateTime DateStart, string genre = null, List<string> keyWords = null)
        {
            var criteria = new MovieViewerRecomendationCriteria(settings, DateStart, genre, keyWords);
            var res = await _service.GetMoviesRecomendationsForViewers(criteria);

            return Ok(res);
        }

        [HttpGet("Documentals/Viewers")]
        public async Task<IActionResult> GetDocumentalsRecomendationsForViewers(FilterSettings settings, List<string> themes)
        {
            var criteria = new  DocumentalViewerRecomendationCriteria(settings, themes);
            var res = await _service.GetDocumentalsRecomendationsForViewers(criteria);

            return Ok(res);
        }

        [HttpGet("TvShows/Viewers")]
        public async Task<IActionResult> GetTvShowsRecomendationsForViewers(FilterSettings settings, string genre = null, List<string> keyWords = null)
        {
            var criteria = new TvShowsViewerRecomendationCriteria(settings, genre, keyWords);
            var res = await _service.GetTvShowsRecomendationsForViewers(criteria);

            return Ok(res);
        }

        [HttpGet("Movies/Managers")]
        public async Task<IActionResult> GetMoviesRecomendationsForManagers(FilterSettings settings, DateTime startDate,
            DateTime endDate,string genre, int age,bool inTheLocalCity = false)
        {
            var criteria = new MovieManagerRecomendationCriteria(settings, startDate, endDate, genre, age, inTheLocalCity);
            var res = await _service.GetMoviesRecomendationsForManagers(criteria);

            return Ok(res);
        }

        [HttpGet("Movies/Managers/Billboard")]
        public async Task<IActionResult> GetSuggestedMoviesBillboard(int weeks, int screems, bool inTheLocalCity)
        {
            var criteria = new MovieManagerBillBoardSuggestedCriteria(weeks, screems,inTheLocalCity);
            var res = await _service.GetSuggestedMoviesBillboard(criteria);

            return Ok(res);
        }

        [HttpGet("Movies/Managers/Billboard/Smart")]
        public async Task<IActionResult> GetSuggestedMoviesSmartBillboard(DateTime dateStart, DateTime dateEnd,int smallScreems,int bigScreems,bool inTheLocalCity)
        {
            var criteria = new MovieManagerSmartBillBoardSuggestedCriteria(dateStart, dateEnd, smallScreems, bigScreems, inTheLocalCity);
            var res = await  _service.GetSuggestedMoviesSmartBillboard(criteria);

            return Ok(res);
        }

    }

}

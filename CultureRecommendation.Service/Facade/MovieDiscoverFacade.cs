using AutoMapper;
using CultureRecommendation.Dto;
using CultureRecommendation.Dto.MovieDiscover;
using CultureRecommendation.Infraestructure;
using CultureRecommendation.Infraestructure.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CultureRecommendation.Service
{

    public class MovieDiscoverFacade : IMovieDiscoverFacade
    {

        private readonly IHttpClientWrapper _service;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public MovieDiscoverFacade(IHttpClientWrapper httpClientWrapper, IConfiguration configuration, IMapper mapper)
        {
            _service = httpClientWrapper;
            _configuration = configuration;
            _mapper = mapper;
        }

        public Task<PagedResult<TvShowDto>> GetTvShowRecomendations(List<string> keywords, string gnere,int  page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<RecommendationDto>> GetDocumentalsRecomendations(List<string> themes, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<RecommendationDto>> GetMovieRecomendations(DateTime dateStart, string gnere, int page = 1, List<string> Keywords = null ,DateTime? dateEnd = null, int? age = null)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecommendationDto>> DiscoverMoviesOrderByPopularity(bool desc = false, int page = 1, bool notPopularity = false)
        {
            CriteriaMovieDiscover criteria;
         
            if (notPopularity)
            {
               var genres = _configuration.GetSection("GenresByPopularity:NotPopularity").Value;
               criteria = new CriteriaMovieDiscover(desc, page, genres);

            }
            else
            {
               var genres = _configuration.GetSection("GenresByPopularity:Popularity").Value;
               criteria = new CriteriaMovieDiscover(desc, page, genres);
            }
                     
            var response =   await DiscoverMovies(criteria);

            var res =  _mapper.Map<List<RecommendationDto>>(response.Results);

            return res;
        }

        public async Task<MovieDiscoverDto> DiscoverMovies(CriteriaMovieDiscover criteria)
        {
            var res =  await _service.GetAsyncWithApiKey<MovieDiscoverDto>(
                _configuration.GetSection("UriMovie").Value,
                _configuration.GetSection("QueryMovie").Value,
                CriteriaToParams(criteria),
                _configuration.GetSection("Apikey").Value, true);

            return res;
        }
       
        public int GetPageSizeDicoverMovies()
        {
           var res =  _configuration.GetSection("NumberResultbyPage").Value;

           return int.Parse(res);
        }

        private IEnumerable<KeyValuePair<string, string>>  CriteriaToParams (CriteriaMovieDiscover criteria)
        {
            var values = new List<KeyValuePair<string, string>>();
        
            values.Add(new KeyValuePair<string, string>("language", criteria.Language));
            values.Add(new KeyValuePair<string, string>("region", criteria.Region));
            values.Add(new KeyValuePair<string, string>("sortBy", criteria.SortBy));
            values.Add(new KeyValuePair<string, string>("certification_country", criteria.CertificationCountry));
            values.Add(new KeyValuePair<string, string>("certification", criteria.Certification));
            values.Add(new KeyValuePair<string, string>("certification.lte", criteria.CertificationLte));
            values.Add(new KeyValuePair<string, string>("certification.gte", criteria.CertificationGte));
            values.Add(new KeyValuePair<string, string>("include_adult", criteria.IncludeAdult));
            values.Add(new KeyValuePair<string, string>("include_video", criteria.IncludeVideo));
            values.Add(new KeyValuePair<string, string>("page", criteria.Page.ToString()));
            values.Add(new KeyValuePair<string, string>("primary_release_year", criteria.PrimaryReleaseYear.ToString()));
            values.Add(new KeyValuePair<string, string>("primary_release_date.gte", criteria.PrimaryReleaseDateGte));
            values.Add(new KeyValuePair<string, string>("primary_release_date.lte", criteria.PrimaryReleaseDateLte));
            values.Add(new KeyValuePair<string, string>("release_date.gte", criteria.ReleaseDateGte));
            values.Add(new KeyValuePair<string, string>("release_date.lte", criteria.ReleaseDateLte));     
            values.Add(new KeyValuePair<string, string>("vote_count.gte", criteria.VoteCountGte));
            values.Add(new KeyValuePair<string, string>("vote_count.lte", criteria.VoteCountLte));
            values.Add(new KeyValuePair<string, string>("vote_average.gte", criteria.VoteAverageGte));
            values.Add(new KeyValuePair<string, string>("with_cast", criteria.WithCast));
            values.Add(new KeyValuePair<string, string>("with_crew", criteria.WithCrew));
            values.Add(new KeyValuePair<string, string>("with_people", criteria.WithPeople));
            values.Add(new KeyValuePair<string, string>("with_companies", criteria.WithCompanies));
            values.Add(new KeyValuePair<string, string>("with_genres", criteria.WithGenres));
            values.Add(new KeyValuePair<string, string>("without_genres", criteria.WithoutGenres));
            values.Add(new KeyValuePair<string, string>("with_keywords", criteria.WithKeywords));
            values.Add(new KeyValuePair<string, string>("with_runtime.gte", criteria.WithRuntimeGte));
            values.Add(new KeyValuePair<string, string>("with_runtime.lte", criteria.WithRuntimeLte));
            values.Add(new KeyValuePair<string, string>("with_original_language", criteria.WithOriginalLanguage));
            values.Add(new KeyValuePair<string, string>("with_release_type",
             criteria.WithReleaseType == 0 ? "" : criteria.WithReleaseType.ToString()));
            values.Add(new KeyValuePair<string, string>("year",
                criteria.Year == 0 ? "" : criteria.Year.ToString()));

            return values;
        }

    }

}

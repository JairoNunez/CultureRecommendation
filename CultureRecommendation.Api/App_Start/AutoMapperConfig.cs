using AutoMapper;
using CultureRecommendation.Dto;
using CultureRecommendation.Dto.MovieDiscover;

namespace CultureRecommendation.Api
{

    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            Map();
        }

        private void Map()
        {
            CreateMap<Result, RecommendationDto>()
                .ForMember(d => d.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(d => d.Language, opt => opt.MapFrom(src => src.Original_language))
                .ForMember(d => d.Overview, opt => opt.MapFrom(src => src.Overview));
        }

    }

}

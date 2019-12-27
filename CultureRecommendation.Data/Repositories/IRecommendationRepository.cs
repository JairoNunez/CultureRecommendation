using CultureRecommendation.Dto;
using System.Collections.Generic;

namespace CultureRecommendation.Data.Repositories
{
    public interface IRecommendationRepository
    {

        IEnumerable<RecommendationDto> GetAllRecomendationSessionsOrderBySeatsSold();

    }

}

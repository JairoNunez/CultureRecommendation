using CultureRecommendation.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CultureRecommendation.Data.Repositories
{

    public class RecommendationRepository : IRecommendationRepository
    {

        protected IDbContextCulture _context;

        public RecommendationRepository(IDbContextCulture context)
        {
            _context = context;
        }

        public IEnumerable<RecommendationDto> GetAllRecomendationSessionsOrderBySeatsSold()
        {

            var query1 = from g in _context.Genre.AsNoTracking()
                         join mg in _context.MovieGenre.AsNoTracking() on g.Id equals mg.GenreId
                         join m in _context.Movie.AsNoTracking() on mg.MovieId equals m.Id
                         join s in _context.Session.AsNoTracking() on m.Id equals s.MovieId                                             
                         select new 
                         {
                             Id = g.Id,
                             Name = g.Name,
                             SeatsSold = s.SeatsSold
                         };

            var res  = query1.GroupBy(p => p.Id).
                Select(group => new
               {
                    GenreId = group.Key,
                    SeatsSolds = group.Sum(h => h.SeatsSold)
                }).OrderByDescending(h => h.SeatsSolds);


            var query2 = from m in _context.Movie.AsNoTracking()
                         join mg in _context.MovieGenre.AsNoTracking() on m.Id equals mg.MovieId
                         join q in res on mg.GenreId equals q.GenreId
                         orderby  q.SeatsSolds descending
                         select new RecommendationDto
                         {
                             Title = m.OriginalTitle,
                             Language = m.OriginalLanguage,
                             ReleaseDate = m.ReleaseDate,
                             Genre = mg.GenreId.ToString()

                         };

          

           return  query2.ToList();

        }

    }

}

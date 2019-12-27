using CultureRecommendation.Domain;
using Microsoft.EntityFrameworkCore;

namespace CultureRecommendation.Data
{

    public interface IDbContextCulture
    {

         DbSet<Cinema> Cinema { get; set; }
         DbSet<City> City { get; set; }
         DbSet<Genre> Genre { get; set; }
         DbSet <Movie> Movie { get; set; }
         DbSet<Room> Room { get; set; }
         DbSet<Session> Session { get; set; }
         DbSet<MovieGenre> MovieGenre { get; set; }

    }

}

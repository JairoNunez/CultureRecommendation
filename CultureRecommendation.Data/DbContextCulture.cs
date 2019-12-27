using CultureRecommendation.Domain;
using Microsoft.EntityFrameworkCore;

namespace CultureRecommendation.Data
{

    public class DbContextCulture : DbContext, IDbContextCulture
    {

        public DbContextCulture(DbContextOptions<DbContextCulture> options)
          : base(options)
        {

        }

        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>()
            .HasKey(e => new { e.Id });
            modelBuilder.Entity<Genre>()
            .HasKey(e => new { e.Id });
            modelBuilder.Entity<Movie>()
            .HasKey(e => new { e.Id});
            modelBuilder.Entity<Genre>()
            .HasKey(e => new { e.Id });
            modelBuilder.Entity<Session>()
            .HasKey(e => new { e.Id });
            modelBuilder.Entity<MovieGenre>()
            .HasKey(e => new { e.GenreId, e.MovieId });
            modelBuilder.Entity<Session>()
           .HasKey(e => new { e.Id });

            base.OnModelCreating(modelBuilder);
        }

    }

}

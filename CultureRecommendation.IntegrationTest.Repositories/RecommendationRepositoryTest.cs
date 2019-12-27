using CultureRecommendation.Data;
using CultureRecommendation.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace CultureRecommendation.IntegrationTest.Repositories
{

    public class RecommendationRepositoryTest
    {

        private  DbContextCulture context;
        private IRecommendationRepository repo;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DbContextCulture>()
            .UseInMemoryDatabase(databaseName: "GetAllUsers_FromDatabase_ShouldReturnAllData")
            .Options;

            context = new DbContextCulture(options);

            context.Genre.AddRange(DummyData.GenerateData.GenerateGenres());
            context.Cinema.AddRange(DummyData.GenerateData.GenerateCinemas());
            context.City.AddRange(DummyData.GenerateData.GenerateCities());
            context.Movie.AddRange(DummyData.GenerateData.GenerateMovies());
            context.MovieGenre.AddRange(DummyData.GenerateData.GenerateMovieGenre());
            context.Room.AddRange(DummyData.GenerateData.GenerateRooms());
            context.Session.AddRange(DummyData.GenerateData.GenerateSessions());

            context.SaveChanges();
        }

        [Test]
        public void GetAllRecomendationSessionsOrderBySeatsSold_ShouldReturnRecomendationsPopularityGenreFirsts()
        {
            // Arrange
            repo = new RecommendationRepository(context);

            // Act
            var res = repo.GetAllRecomendationSessionsOrderBySeatsSold();
            var firstResult = res.FirstOrDefault().Genre.ToString();
            var expectedGenreResult = "3";

            // Assert
            Assert.AreEqual(firstResult, expectedGenreResult);
        }

    }

}
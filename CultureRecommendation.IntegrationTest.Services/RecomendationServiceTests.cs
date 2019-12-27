using CultureRecommendation.Data.Repositories;
using CultureRecommendation.Dto.Criteria;
using CultureRecommendation.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace CultureRecommendation.IntegrationTest.Services
{
    public class RecomendationServiceTests
    {

        private Mock<IRecommendationRepository> _mockRepo;
        private Mock<IMovieDiscoverFacade> _mockServiceFacade;
        private RecomendationService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IRecommendationRepository>();
            _mockServiceFacade = new Mock<IMovieDiscoverFacade>();
            _service = new RecomendationService(_mockRepo.Object, _mockServiceFacade.Object);
        }

        [Test]
        public void GetSuggestedMoviesSmartBillboard_DateStartGreatThanDateEnd_ShouldThrowException()
        {
            //Arrange 
            var criteria = new MovieManagerSmartBillBoardSuggestedCriteria(DateTime.Now.AddDays(5), DateTime.Now, 3,3,true);

            //Act
            // Assert        
            Assert.ThrowsAsync<Exception>(() => _service.GetSuggestedMoviesSmartBillboard(criteria));
        }

        [Test]
        public void GetSuggestedMoviesSmartBillboard_InvalidNumberScreens_ShouldThrowException()
        {
            //Arrange 
            var criteria = new MovieManagerSmartBillBoardSuggestedCriteria(DateTime.Now, DateTime.Now, 0, 0, true);

            //Act
            // Assert        
            Assert.ThrowsAsync<Exception>(() => _service.GetSuggestedMoviesSmartBillboard(criteria));
        }

        [Test]
        public async Task GetSuggestedMoviesSmartBillboard_Call_VerifyCallRepo()
        {
            //Arrange 
            var criteria = new MovieManagerSmartBillBoardSuggestedCriteria(DateTime.Now, DateTime.Now, 3, 3, true);

            //Act
             await _service.GetSuggestedMoviesSmartBillboard(criteria);

            // Assert        
            _mockRepo.Verify(x => x.GetAllRecomendationSessionsOrderBySeatsSold(), Times.Once());
        }

        [Test]
        public async Task GetSuggestedMoviesSmartBillboard_Call_VerifyCallApi()
        {
            //Arrange 
            var criteria = new MovieManagerSmartBillBoardSuggestedCriteria(DateTime.Now, DateTime.Now.AddDays(33), 3, 3, false);
            _mockServiceFacade.Setup(x => x.GetPageSizeDicoverMovies()).Returns(20);
            //Act
            await _service.GetSuggestedMoviesSmartBillboard(criteria);

            // Assert        
            _mockServiceFacade.Verify(x => x.DiscoverMoviesOrderByPopularity(true,1,true), Times.Once());
        }

    }

}
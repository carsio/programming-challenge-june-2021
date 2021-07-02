using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Capiflix;
using Business.Interfaces;
using BusinessApi.Services;
using Domain.Data;
using Tests.Config;
using Xunit;

namespace Tests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class MovieServiceTest : IDisposable
    {
        private ApplicationDbContext _applicationDbContext;
        private readonly IntegrationTestFixture<Startup> _integrationTestFixture;

        public MovieServiceTest(IntegrationTestFixture<Startup> integrationTestFixture)
        {
            _integrationTestFixture = integrationTestFixture;
            _applicationDbContext = _integrationTestFixture.GetApplicationDbContext();
            Setup();
        }

        public void Setup() => _integrationTestFixture.InitialDb();
        
        public void Dispose() => _integrationTestFixture.Dispose();

        [Fact]
        public async Task TestGetMoviesByYearAndGenderShouldReturnData()
        {
            var service = _integrationTestFixture.GetService<IMovieService>();
            
            var movies1 = await service.GetMoviesByFilters(1995, 2);
            Assert.Equal(2, movies1.ToList().Count);
            
            var movies2 = await service.GetMoviesByFilters(1995, 3);
            Assert.Single(movies2);
            
            var movies3 = await service.GetMoviesByFilters(1996, 5);
            Assert.Equal(2, movies3.ToList().Count);

            var movies4 = await service.GetMoviesByFilters(1996, 8);
            Assert.Single(movies4);
            
            var movies5 = await service.GetMoviesByFilters(1996, 9);
            Assert.Empty(movies5);
        }
    }
}
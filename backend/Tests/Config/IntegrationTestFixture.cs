using System;
using System.Collections;
using Api.Capiflix;
using Domain.Data;
using Domain.Entity;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestFixtureCollection))]
    public class IntegrationApiTestFixtureCollection : ICollectionFixture<IntegrationTestFixture<Startup>>
    {
    }
    
    public class IntegrationTestFixture<TStartup> : IDisposable where TStartup : class
    {
        public AppFactory<TStartup> Factory;
        private ApplicationDbContext _applicationDbContext;
        private IServiceScope _serviceScope;

        public IntegrationTestFixture()
        {
            Factory = new AppFactory<TStartup>();
        }

        public ApplicationDbContext GetApplicationDbContext()
        {
            var scopeFactory = Factory.Services.GetService<IServiceScopeFactory>();
            _serviceScope = scopeFactory?.CreateScope();
            _applicationDbContext = _serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            return _applicationDbContext;
        }

        public void SetFakeData<TF>() where TF : class
        {
            var fakeData = FakeData.GetFakeDataByClass<TF>();
            _applicationDbContext.Set<TF>().AddRange(fakeData);
        }

        public T GetService<T>() where T : class => _serviceScope.ServiceProvider.GetService<T>();

        public void ResetDb() => _applicationDbContext.Database.EnsureDeleted();

        public void InitialDb()
        {
            SetFakeData<Movie>();
            SetFakeData<Gender>();
            SetFakeData<MovieGender>();
            _applicationDbContext.SaveChanges();
        }

        public void Dispose() => Factory.Dispose();
    }
}
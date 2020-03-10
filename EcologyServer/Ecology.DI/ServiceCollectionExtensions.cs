using Ecology.Data.Contexts;
using Ecology.Data.Repositories;
using Ecology.Data.Repositories.Contracts;
using Ecology.Data.UnitOfWork;
using Ecology.DTO;
using Ecology.ServiceContracts;
using Ecology.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecology.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services,
            DiContainer selectedContainer,
            AppData appData)
        {
            if (selectedContainer == DiContainer.AspNetCoreDependencyInjector)
            {
                BindRepositories(services);
                BindServices(services);
                BindDbContexts(services, appData);
            }

            return services;
        }

        public static void BindRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ISpeciesDistributionRepository, SpeciesDistributionRepository>();
            services.AddScoped<IRealmRepository, RealmRepository>();
            services.AddScoped<IBiomeRepository, BiomeRepository>();
            services.AddScoped<IEcoregionRepository, EcoregionRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ISpeciesRepository, SpeciesRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<ISpeciesDistributionService, SpeciesDistributionService>();
            services.AddScoped<IRealmService, RealmService>();
            services.AddScoped<IBiomeService, BiomeService>();
            services.AddScoped<IEcoregionService, EcoregionService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ISpeciesService, SpeciesService>();

            services.AddScoped<IDatabaseConfigurationService, DatabaseConfigurationService>();
        }

        public static void BindDbContexts(IServiceCollection services, AppData appData)
        {
            services.AddDbContext<MasterContext>(options => options.UseSqlServer(appData.MasterDbConnectionString));
            services.AddDbContext<EcologyContext>(options => options.UseSqlServer(appData.EcologyConnectionString));
        }
    }
}

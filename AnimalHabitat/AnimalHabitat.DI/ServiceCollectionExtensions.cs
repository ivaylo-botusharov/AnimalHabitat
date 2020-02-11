using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AnimalHabitat.Data.Contexts;
using AnimalHabitat.Data.Repositories;
using AnimalHabitat.Data.Repositories.Contracts;
using AnimalHabitat.Data.UnitOfWork;
using AnimalHabitat.DTO;
using AnimalHabitat.ServiceContracts;
using AnimalHabitat.Services;

namespace AnimalHabitat.DI
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInjection(
            this IServiceCollection services,
            DiContainers selectedContainer,
            AppData appData)
        {
            if (selectedContainer == DiContainers.AspNetCoreDependencyInjector)
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
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<IContinentRepository, ContinentRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void BindServices(IServiceCollection services)
        {
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IDatabaseConfigurationService, DatabaseConfigurationService>();
        }

        public static void BindDbContexts(IServiceCollection services, AppData appData)
        {
            services.AddDbContext<MasterContext>(options => options.UseSqlServer(appData.MasterDbConnectionString));
            services.AddDbContext<AnimalHabitatContext>(options => options.UseSqlServer(appData.AnimalHabitatDbConnectionString));
        }
    }
}

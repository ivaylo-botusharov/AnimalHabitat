using AnimalHabitat.API.Models;
using AnimalHabitat.Data.Models;
using AnimalHabitat.DI;
using AnimalHabitat.DTO;
using AutoMapper;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;

namespace AnimalHabitat.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(
                "AllowAll",
                p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            AppData appData = this.Configuration.GetSection("AppData").Get<AppData>();

            services.AddDependencyInjection(DiContainers.AspNetCoreDependencyInjector, appData);

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers(mvcOptions =>
                mvcOptions.EnableEndpointRouting = false);

            services.AddOData();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // TODO: Disabled because OData doesn't support it for now
            // When OData implements it, should be uncommented and app.UseMvc should be removed
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.Select().Filter().Expand().OrderBy().Count().MaxTop(100);
                routeBuilder.MapODataServiceRoute("odata", "odata", this.GetEdmModel());
            });
        }

        private IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<AnimalViewModel>("AnimalViewModels");
            odataBuilder.EntitySet<Animal>("Animals");
            odataBuilder.EntitySet<Continent>("Continent");

            return odataBuilder.GetEdmModel();
        }
    }
}

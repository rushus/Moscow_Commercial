using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Commercialobj.InfrastructureServices.Gateways.Database;
using Microsoft.EntityFrameworkCore;
using Commercialobj.ApplicationServices.GetAdmAreaListUseCase;
using Commercialobj.ApplicationServices.Ports.Gateways.Database;
using Commercialobj.ApplicationServices.Repositories;
using Commercialobj.DomainObjects.Ports;

namespace Commercialobj.WebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommercialobjContext>(opts => 
                opts.UseSqlite($"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "Commercialobj.db")}")
            );

            services.AddScoped<ICommercialobjDatabaseGateway, CommercialobjEFSqliteGateway>();

            services.AddScoped<DbCommercialobjRepository>();
            services.AddScoped<IReadOnlyCommercialobjRepository>(x => x.GetRequiredService<DbCommercialobjRepository>());
            services.AddScoped<ICommercialobjRepository>(x => x.GetRequiredService<DbCommercialobjRepository>());


            services.AddScoped<IGetCommercialobjListUseCase, GetCommercialobjListUseCase>();

            
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
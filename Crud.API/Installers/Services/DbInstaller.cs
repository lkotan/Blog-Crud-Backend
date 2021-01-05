using Crud.Core.Repositories;
using Crud.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Crud.API.Installers.Services
{
    public class DbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CrudContext>(x => x.UseSqlServer(configuration.GetConnectionString("Api")), ServiceLifetime.Transient);
            services.AddTransient<CrudContext>();
            services.AddTransient<DbContext, CrudContext>();
        }

        public void InstallConfigure(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<CrudContext>();
            context.Database.Migrate();
        }

      
    }
}

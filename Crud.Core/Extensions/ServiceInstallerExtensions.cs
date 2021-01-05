using Crud.Core.Repositories;
using Crud.Core.Repositories.EF;
using Crud.Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Crud.Core.Extensions
{
    public static class ServiceInstallerExtensions
    {
        public static void InstallCoreServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<,>));
            services.AddTransient(typeof(IDataAccessRepository<>), typeof(EfDataAccessRepository<>));
            ServiceTool.Create(services);
        }
    }
}

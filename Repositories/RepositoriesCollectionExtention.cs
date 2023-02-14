using Microsoft.Extensions.DependencyInjection;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class RepositoriesCollectionExtention
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository<Child>, ChildRepsitory>();
            services.AddScoped<IDataRepository<PersonalDetail>, PersonalDetailsRepository>();
            return services;

        }
    }
}

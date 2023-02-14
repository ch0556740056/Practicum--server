using Common.DTO_s;
using Context;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services.Interfaces;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IDataService<ChildDto>, ChildService>();
            services.AddScoped<IDataService<PersonalDetailDto>, PersonalDetailService>();
            services.AddSingleton<IContext, MyContext>();

            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}

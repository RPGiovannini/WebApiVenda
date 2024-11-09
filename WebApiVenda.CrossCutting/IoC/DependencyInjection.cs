using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Infrastructure.Context;

namespace WebApiVenda.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfrastructureApi(this IServiceCollection services,IConfiguration configuration)
        {
            var postgresConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                                              options.UseNpgsql(postgresConnection));
            return services;
        }
    }
}

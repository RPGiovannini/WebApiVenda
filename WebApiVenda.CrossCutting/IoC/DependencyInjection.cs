using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WebApiVenda.Application.Interfaces;
using WebApiVenda.Application.Mappings;
using WebApiVenda.Application.Services;
using WebApiVenda.Domain.Interfaces;
using WebApiVenda.Infrastructure.Context;
using WebApiVenda.Infrastructure.Repositories;

namespace WebApiVenda.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var postgresConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                                              options.UseNpgsql(postgresConnection));

            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IVendaItemRepository, VendaItemRepository>();
            services.AddScoped<IVendaItemService, VendaItemService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthService,AuthService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            return services;
        }
    }
}

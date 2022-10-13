using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiChurrasTop.Application.Interfaces;
using ApiChurrasTop.Application.Mapping;
using ApiChurrasTop.Application.Services;
using APIChurrasTop.Domain.Interfaces;
using APIChurrasTop.Infra.Data.Context;
using APIChurrasTop.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIChurrasTop.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(op =>
                op.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IAgendaPessoaRepository, AgendaPessoaRepository>();

            services.AddScoped<IAgendaService, AgendaService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IAgendaPessoaService, AgendaPessoaService>();

            services.AddAutoMapper(typeof(MappingDomainToDTO));

            return services;
        }
    }
}
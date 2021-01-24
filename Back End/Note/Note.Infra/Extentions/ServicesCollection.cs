using Microsoft.Extensions.DependencyInjection;
using Note.Core.Interfaces.IRepositories;
using Note.Core.Interfaces.IServices;
using Note.Core.Services;
using Note.Infra.Data;
using Note.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Infra.Extentions
{
    public static class ServicesCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Contexto
            services.AddScoped<NoteDbContext>();

            //Repositorios
            services.AddTransient<INotaRepository, NotaReposiory>();
            services.AddTransient<ICatalogoRepository, CatalogoRepository>();

            //Servicios
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ICatalogoService, CatalogoService>();

            return services;
        }
    }
}

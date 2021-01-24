using Note.Core.CustomEntities;
using Note.Core.Entities;
using Note.Core.Interfaces.IRepositories;
using Note.Core.Interfaces.IServices;
using Note.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core.Services
{
    public class NoteService : INoteService
    {
        private readonly INotaRepository repository;

        public NoteService( INotaRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<NoteList>> NoteList(NoteQueryFilters filters)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Accion", 1),
                new SqlParameter("@IdPrioridad", filters.Prioridad)
            };
            return await this.repository.GetAll("spNotas", parameters);
        }

        public async Task<Nota> GetNota(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Accion", 5),
                new SqlParameter("@IdNota", id)
            };
            return await this.repository.GetById("spNotas", parameters);
        }

        public async Task<bool> Add(Nota nota)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Accion", 2),
                new SqlParameter("@Titulo",nota.Titulo),
                new SqlParameter("@Cuerpo",nota.Cuerpo),
                new SqlParameter("@IdPrioridad", nota.IdPrioridad)
            };
            var rows = await this.repository.ExecuteCommand("spNotas", parameters);

            return rows > 0;
        }

        public async Task<bool> Update(Nota nota)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Accion", 3),
                new SqlParameter("@Titulo",nota.Titulo),
                new SqlParameter("@Cuerpo",nota.Cuerpo),
                new SqlParameter("@IdNota",nota.IdNota)
            };
            var rows = await this.repository.ExecuteCommand("spNotas", parameters);

            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Accion", 4),
                new SqlParameter("@IdNota", id)
            };
            var rows = await this.repository.ExecuteCommand("spNotas", parameters);

            return rows > 0;
        }
    }
}

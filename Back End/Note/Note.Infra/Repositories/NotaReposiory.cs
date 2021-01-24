using Note.Core.CustomEntities;
using Note.Core.Entities;
using Note.Core.Interfaces.IRepositories;
using Note.Infra.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Note.Infra.Repositories
{
    public class NotaReposiory : INotaRepository
    {
        private readonly NoteDbContext context;

        public NotaReposiory( NoteDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<NoteList>> GetAll(string sentencia, SqlParameter[] Parametro = null)
        {
            using (var reader = await this.context.ExecuteReader(sentencia, Parametro))
            {
                List<NoteList> list = new List<NoteList>();

                while (await reader.ReadAsync())
                {
                    NoteList nota = new NoteList();
                    nota.IdNota = (int)reader["IdNota"];
                    nota.Titulo = reader["Titulo"].ToString();
                    nota.Cuerpo = reader["Cuerpo"].ToString();
                    nota.FechaRegistro = reader["FechaRegistro"].ToString();
                    nota.Prioridad = reader["Prioridad"].ToString();

                    list.Add(nota);
                }

                return list;
            }
        }

        public async Task<Nota> GetById(string sentencia, SqlParameter[] Parametro = null)
        {
            using (var reader = await this.context.ExecuteReader(sentencia, Parametro))
            {
                Nota nota = new Nota();

                while (await reader.ReadAsync())
                {         
                    nota.IdNota = (int)reader["IdNota"];
                    nota.Titulo = reader["Titulo"].ToString();
                    nota.Cuerpo = reader["Cuerpo"].ToString();
                    nota.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                    nota.Prioridad.IdPrioridad = (int)reader["IdPrioridad"];
                }

                return nota;
            }
        }

        public async Task<int> ExecuteCommand(string sentencia, SqlParameter[] Parametro = null)
        {
            return await this.context.ExecuteNonQuery(sentencia, Parametro);
        }
    }
}

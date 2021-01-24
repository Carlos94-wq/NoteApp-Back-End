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
    public class CatalogoRepository : ICatalogoRepository
    {
        private readonly NoteDbContext context;

        public CatalogoRepository( NoteDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Estatus>> GetEstatus(string sentencia, SqlParameter[] Parametro = null)
        {
            using (var reader = await this.context.ExecuteReader(sentencia, Parametro))
            {
                List<Estatus> list = new List<Estatus>();

                while (await reader.ReadAsync())
                {
                    Estatus Estatus = new Estatus();
                    Estatus.IdEstatus = (int)reader["IdEstatus"];
                    Estatus.Descripcion = reader["Descripcion"].ToString();

                    list.Add(Estatus);
                }

                return list;
            }
        }

        public async Task<IEnumerable<Prioridad>> GetPriorid(string sentencia, SqlParameter[] Parametro = null)
        {
            using (var reader = await this.context.ExecuteReader(sentencia, Parametro))
            {
                List<Prioridad> list = new List<Prioridad>();

                while (await reader.ReadAsync())
                {
                    Prioridad Estatus = new Prioridad();
                    Estatus.IdPrioridad = (int)reader["IdPrioridad"];
                    Estatus.Descripcion = reader["Descripcion"].ToString();

                    list.Add(Estatus);
                }

                return list;
            }
        }
    }
}

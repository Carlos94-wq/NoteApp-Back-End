using Note.Core.Entities;
using Note.Core.Interfaces.IRepositories;
using Note.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly ICatalogoRepository repository;

        public CatalogoService( ICatalogoRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Estatus>> GetEstatus()
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Accion", 1)
            };
            return await this.repository.GetEstatus("spCatalogos", parameters);
        }

        public async Task<IEnumerable<Prioridad>> Prioridad()
        {
            SqlParameter[] parameters = {
                new SqlParameter("@Accion", 2)
            };
            return await this.repository.GetPriorid("spCatalogos", parameters);
        }
    }
}

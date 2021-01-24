using Note.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core.Interfaces.IRepositories
{
    public interface ICatalogoRepository
    {
        Task<IEnumerable<Estatus>> GetEstatus(string sentencia, SqlParameter[] Parametro = null);
        Task<IEnumerable<Prioridad>> GetPriorid(string sentencia, SqlParameter[] Parametro = null);
    }
}

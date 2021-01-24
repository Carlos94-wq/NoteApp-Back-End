using Note.Core.CustomEntities;
using Note.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core.Interfaces.IRepositories
{
    public interface INotaRepository
    {
        //Lista regstro
        Task<IEnumerable<NoteList>> GetAll(string sentencia, SqlParameter[] Parametro = null);
        //Obtiene regstros por id
        Task<Nota> GetById(string sentencia, SqlParameter[] Parametro = null);
        //ejecuta comandos
        Task<int> ExecuteCommand(string sentencia, SqlParameter[] Parametro = null);
    }
}

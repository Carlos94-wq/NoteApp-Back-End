using Note.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Note.Core.Interfaces.IServices
{
    public interface ICatalogoService
    {
        Task<IEnumerable<Estatus>> GetEstatus();
        Task<IEnumerable<Prioridad>> Prioridad();
    }
}

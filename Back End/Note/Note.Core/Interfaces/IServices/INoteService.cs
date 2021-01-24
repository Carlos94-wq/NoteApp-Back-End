using Note.Core.CustomEntities;
using Note.Core.Entities;
using Note.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Note.Core.Interfaces.IServices
{
    public interface INoteService
    {
        Task<bool> Add(Nota nota);
        Task<bool> Delete(int id);
        Task<Nota> GetNota(int id);
        Task<IEnumerable<NoteList>> NoteList(NoteQueryFilters filters);
        Task<bool> Update(Nota nota);
    }
}
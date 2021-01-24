using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Core.QueryFilters
{
    public class NoteQueryFilters
    {
        public int? Prioridad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}

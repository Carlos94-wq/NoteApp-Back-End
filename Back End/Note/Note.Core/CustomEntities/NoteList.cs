using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Core.CustomEntities
{
    public class NoteList
    {
        public int IdNota { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public string FechaRegistro { get; set; }
        public string Prioridad { get; set; }
    }
}

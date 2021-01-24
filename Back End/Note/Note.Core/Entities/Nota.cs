using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Core.Entities
{
    public class Nota
    {
        public int IdNota { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public int? IdPrioridad { get; set; }
        public int? IdEstatus { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }

        //Relaciones
        public Estatus Estatus { get; set; }
        public Prioridad Prioridad { get; set; }

        public Nota()
        {
            this.Estatus = new Estatus();
            this.Prioridad = new Prioridad();
        }
    }
}

using System;
using System.Collections.Generic;

namespace IntroduccionEfcLinqJwt.Models
{
    public partial class Curso
    {
        public Curso()
        {
            CursoPersona = new HashSet<CursoPersona>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Cupos { get; set; }
        public string Dias { get; set; }
        public int? Turno { get; set; }

        public virtual Turno TurnoNavigation { get; set; }
        public virtual ICollection<CursoPersona> CursoPersona { get; set; }
    }
}

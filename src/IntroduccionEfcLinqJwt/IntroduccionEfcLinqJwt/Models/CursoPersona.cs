using System;
using System.Collections.Generic;

namespace IntroduccionEfcLinqJwt.Models
{
    public partial class CursoPersona
    {
        public int Id { get; set; }
        public int? IdCurso { get; set; }
        public int? IdPersona { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
    }
}

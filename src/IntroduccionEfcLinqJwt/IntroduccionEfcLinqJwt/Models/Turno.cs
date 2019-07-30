using System;
using System.Collections.Generic;

namespace IntroduccionEfcLinqJwt.Models
{
    public partial class Turno
    {
        public Turno()
        {
            Curso = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace IntroduccionEfcLinqJwt.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Persona = new HashSet<Persona>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}

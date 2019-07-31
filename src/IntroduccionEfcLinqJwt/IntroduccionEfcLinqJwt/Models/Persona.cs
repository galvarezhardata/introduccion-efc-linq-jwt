using System;
using System.Collections.Generic;

namespace IntroduccionEfcLinqJwt.Models
{
    public partial class Persona
    {
        public Persona()
        {
            CursoPersona = new HashSet<CursoPersona>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int? Rol { get; set; }

        public virtual Rol RolNavigation { get; set; }
        public virtual ICollection<CursoPersona> CursoPersona { get; set; }
    }
}

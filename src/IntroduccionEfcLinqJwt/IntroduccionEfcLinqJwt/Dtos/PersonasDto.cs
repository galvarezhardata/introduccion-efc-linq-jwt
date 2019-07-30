using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntroduccionEfcLinqJwt.Dtos
{
    public class PersonasDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Rol { get; set; }
        public string[] Cursos { get; set; }
    }
}

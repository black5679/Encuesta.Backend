using Encuesta.Backend.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Backend.Domain.Models
{
    public class UsuarioModel : AuditModel
    {
        public int Id { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Correo { get; set; }
        public required string Celular { get; set; }
        public required DateTime FechaNacimiento { get; set; }
        public required string Password { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Backend.Application.Commands.Usuario.Login
{
    public class LoginUsuarioRequest
    {
        public required string Correo { get; set; }
        public required string Password { get; set; }
    }
}

using Encuesta.Backend.Domain.Exceptions;
using Encuesta.Backend.Domain.Repositories;
using Encuesta.Backend.Domain.Services;
using Encuesta.Backend.Domain.UoW;
using Encuesta.Backend.Infrastructure.Repositories;
using Encuesta.Backend.Infrastructure.UoW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta.Backend.Application.Commands.Usuario.Login
{
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, string>
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IJwtService jwtService;
        public LoginUsuarioCommandHandler(IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            this.jwtService = jwtService;
            this.unitOfWork = unitOfWork;
            usuarioRepository = new UsuarioRepository(unitOfWork.Connection, unitOfWork.Transaction);
        }

        public async Task<string> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            _ = await usuarioRepository.GetByCorreo(request.Correo) ?? throw new UnauthorizedException("El usuario no existe");
            var password = jwtService.EncryptString(request.Password);
            var usuario = await usuarioRepository.GetByCorreoAndPassword(request.Correo, password) ?? throw new UnauthorizedException("Credenciales incorrectas");
            // Genera el Token
            var token = jwtService.GenerateToken(usuario.Id);
            unitOfWork.Commit();
            return token;
        }
    }
}

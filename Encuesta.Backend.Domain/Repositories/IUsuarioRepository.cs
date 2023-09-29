using Encuesta.Backend.Domain.Models;

namespace Encuesta.Backend.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task<UsuarioModel> GetByCorreoAndPassword(string correo, string password);
        Task<UsuarioModel> GetByCorreo(string correo);
    }
}

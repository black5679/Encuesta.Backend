using Dapper;
using Encuesta.Backend.Domain.Models;
using Encuesta.Backend.Domain.Repositories;
using System.Data;

namespace Encuesta.Backend.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbConnection connection;
        private readonly IDbTransaction? transaction;
        public UsuarioRepository(IDbConnection connection, IDbTransaction? transaction)
        {
            this.connection = connection;
            this.transaction = transaction;
        }
        public async Task<UsuarioModel> GetByCorreo(string correo)
        {
            var usuario = await connection.QueryFirstOrDefaultAsync<UsuarioModel>("GetByCorreo", new { Correo = correo }, transaction, null, CommandType.StoredProcedure);
            return usuario;
        }
        public async Task<UsuarioModel> GetByCorreoAndPassword(string correo, string password)
        {
            var usuario = await connection.QueryFirstOrDefaultAsync<UsuarioModel>("GetByCorreoAndPassword", new { Correo = correo, Password = password }, transaction, null, CommandType.StoredProcedure);
            return usuario;
        }
    }
}

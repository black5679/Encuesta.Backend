using Encuesta.Backend.Domain.Services;
using Encuesta.Backend.Domain.UoW;
using Encuesta.Backend.Infrastructure.Services;
using Encuesta.Backend.Infrastructure.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Encuesta.Backend.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IDb, Db>();
            return services;
        }
    }
}

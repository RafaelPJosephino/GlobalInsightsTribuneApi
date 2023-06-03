using GlobalInsightsTribune.Application.Interfaces;
using GlobalInsightsTribune.Application.Services;
using GlobalInsightsTribune.Domain.Interfaces;
using GlobalInsightsTribune.Infra.Data.Context;
using GlobalInsightsTribune.Infra.Data.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GlobalInsightsTribune.Infra.Ioc
{
    public static class DependencyInjection
    {
            
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {

            services.AddDbContext<ApplicationDbContext>(options => 
                { 
                    options.UseMySql(
                        configuration.GetConnectionString("ProductionConnection"),
                        ServerVersion.Parse("8.0.23")
                        ); 
                });
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("app/Keys")).ProtectKeysWithDpapi();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GlobalInsightsTribune", Version = "v1" });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}

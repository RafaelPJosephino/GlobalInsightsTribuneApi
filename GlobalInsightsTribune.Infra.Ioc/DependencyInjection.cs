using GlobalInsightsTribune.Application.Interfaces;
using GlobalInsightsTribune.Application.Services;
using GlobalInsightsTribune.Domain.Interfaces;
using GlobalInsightsTribune.Infra.Data.Context;
using GlobalInsightsTribune.Infra.Data.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
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
                        Environment.GetEnvironmentVariable("DATABASE_URL") ??configuration.GetConnectionString("DefaultConnection"),
                        ServerVersion.Parse("8.0.23")
                     );
                });
            services.AddDataProtection().UseCryptographicAlgorithms(
                new AuthenticatedEncryptorConfiguration
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                });
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo("/root/.aspnet/DataProtection-Keys"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GlobalInsightsTribune",
                    Version = "v1",
                    Description = "This News API provides access to a wide range of articles and real-time news information. It enables users to search, filter, and access the latest updates from various news sources, facilitating the creation of informative and dynamic applications. Developed by [Dinesh Joshi](https://www.linkedin.com/in/dinesh-joshi-1029a9286/) and [Rafael P. Josephino](https://www.linkedin.com/in/rafael-puckoski-josephino/)."
                });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}

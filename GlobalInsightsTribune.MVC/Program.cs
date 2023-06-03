using GlobalInsightsTribune.Infra.Ioc;
using GlobalInsightsTribune.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using GlobalInsightsTribune.MVC.MappingConfig;
using GlobalInsightsTribune.Application.Interfaces;
using GlobalInsightsTribune.Application.Services;

namespace GlobalInsightsTribune.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddAutoMapperConfiguration();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                scope.ServiceProvider.GetRequiredService<ILogger<Program>>().LogError(ex, "An error occurred in the migration and/or insertion of data"); 
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalInsightsTribune V1"); });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.Run();
        }
    }
}
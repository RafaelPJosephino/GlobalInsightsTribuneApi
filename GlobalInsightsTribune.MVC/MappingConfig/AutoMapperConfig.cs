using GlobalInsightsTribune.Application.Mappings;

namespace GlobalInsightsTribune.MVC.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null)  throw new ArgumentNullException(nameof(services)); 

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile), typeof(DTOToDomainMappingProfile));
        }
 
    }
}

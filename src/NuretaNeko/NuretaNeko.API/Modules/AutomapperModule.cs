using AutoMapper;

namespace NuretaNeko.API.Modules
{
    public static class AutomapperModule
    {
        public static IServiceCollection AddAutomapperModule(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile(new Mappings.AppMappingProfile());
                //config.AddProfile(new Mappings.UserMappingProfile());
                //config.AddProfile(new Mappings.UserSettingsMappingProfile());
            });

            //configuration.AssertConfigurationIsValid();

            return configuration;
        }

    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TranslationsService.Entities.Settings;
using TranslationsService.Services;

namespace TranslationsService.Extentions
{
    public static class ServiceExtensions
    {
        public static void AddCacheService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<CacheRepositoySettings>(
                Configuration.GetSection("TranslationsCacheDatabaseSettings"));

            services.AddSingleton<ICacheRepositoySettings>(sp =>
                sp.GetRequiredService<IOptions<CacheRepositoySettings>>().Value);

            services.AddSingleton<ICacheService, Services.CacheService>(); 
        }

        public static void AddTranslationsService(this IServiceCollection services)
        {
            services.AddSingleton<ITranslationService, Services.TranslationService>();
        }
    }
}
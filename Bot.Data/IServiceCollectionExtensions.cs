using Bot.Data.Abstractions;
using Bot.Data.DbContexts;
using Bot.Data.Models;
using Bot.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bot.Data
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<BotDbContext, BotDbContext>();
            services.AddScoped<SettingDbContext, SettingDbContext>();

            services.AddScoped<IRepository<WordModel>, WordRepository>();
            services.AddScoped<IRepository<Link>, LinkRepository>();
            services.AddScoped<IRepository<Settings>, SettingsRepository>();
            services.AddScoped<IRepository<Message>, MessageRepository>();
            services.AddScoped<IRepository<Report>, ReportRepository>();
            services.AddScoped<IRepository<Mute>, MuteRepository>();

            return services;
        } 
    }
}
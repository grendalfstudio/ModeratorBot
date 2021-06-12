using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business.Implementation.Services;

namespace Bot.Business
{
    public static class BusinessServices
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUpdateService, UpdateService>();
            services.AddSingleton<IBotService, BotService>();

            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<ICheckImageService, CheckImageService>();
            services.AddTransient<ICheckLinkService, CheckLinkService>();
            services.AddTransient<ICheckMessageService, CheckMessageService>();
            services.AddTransient<ICheckTextService, CheckTextService>();
            services.AddTransient<ICheckVoiceService, CheckVoiceService>();
            services.AddTransient<IDeleteMessageService, DeleteMessageService>();
            services.AddTransient<IMuteService, MuteService>();
            services.AddTransient<IReportService, ReportService>();

            return services;
        }
    }
}

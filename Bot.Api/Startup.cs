using Bot.Business.Abstractions.ServicesAbstractions;
using Bot.Business;
using Bot.Data;
using Bot.Data.Abstractions;
using Bot.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Bot.Business.Implementation.Services;

namespace Bot.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterBusinessServices();
            services.Configure<BotConfiguration>(Configuration.GetSection("BotConfiguration"));
            services.Configure<BotDatabaseSettings>(
                Configuration.GetSection(nameof(BotDatabaseSettings)));
            services.Configure<SettingDatabaseSettings>(
                Configuration.GetSection(nameof(SettingDatabaseSettings)));

            services.AddSingleton<ISettingDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<SettingDatabaseSettings>>().Value);
            services.AddSingleton<IBotDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BotDatabaseSettings>>().Value);

            services.AddDataServices();

            services
                .AddControllers()
                .AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
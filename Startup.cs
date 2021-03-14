using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SearchEngine.LoggerAPI.Core.ApplicationServices;
using SearchEngine.LoggerAPI.Core.ApplicationServices.Services;
using SearchEngine.LoggerAPI.Core.DomainServices;
using SearchEngine.LoggerAPI.Infrastructure;
using SearchEngine.LoggerAPI.Infrastructure.Client;
using SearchEngine.LoggerAPI.Infrastructure.Client.Database;

namespace SearchEngine.LoggerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)));
            services.Configure<DatabaseMetadata>(Configuration.GetSection(nameof(DatabaseMetadata)));

            services.AddSingleton<IDatabaseSettings, DatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);
            services.AddSingleton<IDatabaseMetadata, DatabaseMetadata>(sp =>
                sp.GetRequiredService<IOptions<DatabaseMetadata>>().Value);

            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IClient, Client>();

            services.AddControllers().AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SearchEngine - LoggerAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SearchEngine - LoggerAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

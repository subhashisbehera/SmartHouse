using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartHouseDashBoard.Interfaces.Repositories;
using SmartHouseDashBoard.Interfaces.Services;
using SmartHouseDashBoard.Persistence.Models;
using SmartHouseDashBoard.Persistence.Repositories;
using SmartHouseDashBoard.Services.Services;

namespace SmartHouseDashBoard.API
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
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddEntityFrameworkSqlServer().AddDbContext<SmartHouseDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("SmartHouseDashboardDbConnectionString"), sqlServerOptions =>
                    {
                        sqlServerOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    })
                        .EnableSensitiveDataLogging()
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                }, ServiceLifetime.Transient);
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IFloorRepository, FloorRepository>();
            services.AddTransient<IRoomRepository, RoomRepository>();
            services.AddTransient<ISensorRepository, SensorRepository>();
            services.AddTransient<IDashBoardService, DashBoardService>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("*")
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST", "PUT");
                    });
            });
                services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "SmartHouse Dash Board API",
                        Version = "v1"
                    });

            });
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors();
            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json",
                    "SmartHouse Dash Board(v1)");
                options.RoutePrefix = string.Empty;
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Contracts;
using TaskManagement.Controllers;
using TaskManagement.Models;
using TaskManagement.Repository;
using TaskManagement.Service;

namespace TaskManagement
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
            services.AddControllers();
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(option =>
                {
                    option.SaveToken = true;
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidAudience = Configuration["Jwt:ValidAudience"],
                        ValidIssuer = Configuration["Jwt:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RoleClaimType = "UserId",
                        NameClaimType = "hhhh"
                    };
                });
            services.AddDbContext<TaskManagementContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TaskManagement")));
            services.AddControllers();
            services.AddTransient<ITaskManagementRepository, TaskManagementRepository>();
            services.AddTransient<ITaskManagementService, TaskManagementService>();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            ILogger<TaskManagementController> logger = serviceProvider.GetService<ILogger<TaskManagementController>>();
            services.AddSingleton(typeof(ILogger), logger);
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TaskManagement",
                    Version = "v1",
                    Description = "Open API TaskManagement",
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using AutoMapper;
using Identity.BusinessLogic.Interfaces;
using Identity.BusinessLogic.Services;
using Identity.Core;
using Identity.Core.Filters;
using Identity.Core.Helpers;
using Identity.Core.Middleware;
using Identity.Domain;
using Identity.Domain.Mappings;
using Identity.Domain.Model;
using IdentityServer.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;

namespace IdentityServer.API
{
    public class Startup
    {
        private readonly Appsettings _appsettings;
        public Startup(IConfiguration configuration)
        {
            _appsettings = new Appsettings();
            Configuration = configuration;
            Configuration.Bind(_appsettings);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<Appsettings>(Configuration);
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                    },
                    new string[] { }
                }
                });
            });

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(_appsettings.ConnectionStrings.Identity);
            }, ServiceLifetime.Scoped);

            services.AddCors(options =>
            {
                options.AddPolicy(name: "default",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                                  });
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps(Assembly.GetAssembly(typeof(UserProfile)));
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                options.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IContextService, ContextService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddAuth(_appsettings.JwtSettings);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(AuthorizationFilter));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("default");

            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

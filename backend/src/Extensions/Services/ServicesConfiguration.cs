using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using src.Configurations.Options;
using src.Configurations.Policies.IsSudoPolicy;
using src.Data;
using src.Entities.Entities;
using src.Interfaces.IServices;
using src.Services;

namespace src.Extensions.Services
{
    public static class ServicesConfiguration
    {
        public static void ConfigureSerilog(this IServiceCollection services)
        {
            services.AddSerilog(options =>
                      {
                          options.MinimumLevel.Information()
                          .WriteTo.Console(
                              restrictedToMinimumLevel: LogEventLevel.Debug,
                              outputTemplate: "{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
                          ).WriteTo.File("Logs/log.txt",
                              rollOnFileSizeLimit: true,
                              rollingInterval: RollingInterval.Day,
                              fileSizeLimitBytes: 1000000,
                              outputTemplate: "{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                              restrictedToMinimumLevel: LogEventLevel.Warning
                          );
                      });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["JWT:Issuer"],
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"] ?? throw new Exception("Security Key not found within configuration")))
                };
            });
        }

        public static void ConfigureAuthorization(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("SudoPolicy", p => p.AddRequirements(
                    new IsSudoRequirement()
                ));
                options.AddPolicy("SudoRole", p => p.RequireRole("Sudo"));
            });
        }

        public static void ConfigureOptions(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<RolesData>(config.GetSection(RolesData.Section));
            services.Configure<SudoData>(config.GetSection(SudoData.Section));
        }

        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(config.GetConnectionString("Default")));
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<Usuario, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<AppDbContext>();
        }

        public static void ConfigureDependenciesInjections(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, IsSudoHandler>();
            services.AddScoped<SeederInitialiser>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<ITokenServices, TokenServices>();
        }

    }
}
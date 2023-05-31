using KarDo.Domain.AggregateModels.UserAggregate;
using KarDo.Domain.Interfaces;
using KarDo.Infrastructure.EFCore.Context;
using KarDo.Infrastructure.EFCore.Library;
using KarDo.Infrastructure.EFCore.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarDo.Infrastructure.EFCore
{
    public static class DependencyInjection
    {
        public static void AddEFCoreDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnectionString");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is null or empty.");
            }
            string secretStr = configuration["Application:Secret"];
            byte[] secret = Encoding.UTF8.GetBytes(secretStr);

            // DB
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

            // Services
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserEventJoinRepository, UserEventJoinRepository>();
            

            // JWT

            // rol bazlı attribute lar çalışsın diye eklendi
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddRoleManager<RoleManager<IdentityRole>>()
                    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Audience = configuration["Application:Audience"];
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(secret),
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}

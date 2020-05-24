using Cherry.Application.IdentityApplication.ConfigurationModels;
using Cherry.Domain.IdentityAggregate;
using Cherry.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cherry.Web.InstallerServices
{
    public static class IdentityServiceInstaller
    {
        public static void InstallIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection tokenSection = configuration.GetSection("TokenSection");
            TokenConfigurationModel tokenConfigurationModel = tokenSection.Get<TokenConfigurationModel>();
            services.Configure<TokenConfigurationModel>(tokenSection);

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<CherryDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = tokenConfigurationModel.ValidIssuer,
                    ValidAudience = tokenConfigurationModel.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigurationModel.IssuerSigningKey))
                };
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });
        }

    }
}

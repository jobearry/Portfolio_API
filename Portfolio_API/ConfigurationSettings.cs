using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portfolio_API.Mapper;
using Portfolio_API.DataTypes.Models;
using Portfolio_API.DataTypes.Models.DTOs;
using Portfolio_API.DataAccess.Repositories;
using Portfolio_API.Services;
using System.Text;
using Portfolio_API.DataAccess.Data.ScaffoldExisting;
using Portfolio_API.DataTypes.Interfaces;
using Portfolio_API.DataAccess.Repositories.Portfolio;
using Portfolio_API.Services.Portfolio;
using Portfolio_API.Services.Notion;
using System.Net.Http.Headers;
using Portfolio_API.DataTypes.Options;

namespace Portfolio_API
{
    public static class ConfigurationServices
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Read connection string from appsettings.json or environment variables
            var jdbConnectionString = configuration.GetConnectionString("JDBConnection");
            
            //Notion
            services.Configure<NotionOptions>(configuration.GetSection("Notion"));
            services.AddHttpClient<NotionClientService>();

            // Register DbContext
            services.AddDbContext<JDBContext>(options => options.UseSqlServer(jdbConnectionString));

            // Register base repository
            services.AddScoped(typeof(IRepository<>), typeof(BaseProjectRepository<>));

            // Register base Services
            services.AddScoped(typeof(IService<>), typeof(BaseProjectService<>));
        }

        public static void AddCredits(this IServiceCollection services, IConfiguration configuration)
        {
            var azureAd = configuration.GetSection("AzureAd").Get<EntraOptions>()!;

            var contactInfo = new OpenApiContact
            {
                Name = "Jonathan Golimlim",
                Url = new Uri("https://ng-web-resume.vercel.app/")
            };
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JDB Portfolio API: Portfolio",
                    Version = "v1",
                    Description = "Portfolio Resource Backend Definition",
                    Contact = contactInfo
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "JDB Portfolio API: Notion Integration",
                    Version = "v2",
                    Description = "",
                    Contact = contactInfo
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        new string[] { }
                    }
                });
            });
        }
    
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // bind options and register
            services.Configure<EntraOptions>(configuration.GetSection("AzureAd"));
            services.Configure<JwtOptions>(configuration.GetSection("Jwt"));

            var jwtOptions = configuration.GetSection("Jwt").Get<JwtOptions>()!;
            var jwtKey = Encoding.UTF8.GetBytes(jwtOptions.Key);
            
            // register authorization
            services.AddAuthorization();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtOptions.Issuer,
                    ValidAudience = jwtOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtKey),
                };

            });

        }
    
        public static void AddCorsOrigins(this IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowSPA",
                    opts => opts.WithOrigins("http://localhost:4200","https://jg-portfolio-dashboard.vercel.app")
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials());
            });
        }
    }
}

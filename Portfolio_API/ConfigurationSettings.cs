using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Portfolio_API.Contexts;
using Portfolio_API.Models;
using Portfolio_API.Repositories;
using Portfolio_API.Services.EmployeeManagementService;
using Portfolio_API.Models.DTOs;
using Microsoft.Identity.Web;

namespace Portfolio_API
{
    public static class ConfigurationServices
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Read connection string from appsettings.json or environment variables
            var employeeConnectionString = configuration.GetConnectionString("SqLiteEmployeeConnection");
            var resumeConnectionString = configuration.GetConnectionString("SqLiteResumeConnection");

            // Register DbContext
            services.AddDbContext<EmployeeDbContext>(options =>
                options.UseSqlite(employeeConnectionString));
            services.AddDbContext<ResumeDbContext>(options =>
            options.UseSqlite(resumeConnectionString));

            // Register generic repository
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));

            // Register services
            services.AddScoped<EmployeeService>();
            services.AddScoped<AttendanceService>();
            services.AddScoped<UserService>();
        }

        public static void AddCredits(this IServiceCollection services, IConfiguration configuration)
        {
            var azureAd = configuration.GetSection("AzureAd").Get<AzureAd>()!;

            var contactInfo = new OpenApiContact
            {
                Name = "Jonathan Golimlim",
                Url = new Uri("https://web-resume-jg.vercel.app/")
            };
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JDB Portfolio API: v1",
                    Version = "v1",
                    Description = "Portfolio Resource Backend Definition",
                    Contact = contactInfo
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "JDB Portfolio API: v2",
                    Version = "v2",
                    Description = "Attendance Management Backend Definition",
                    Contact = contactInfo
                });

                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{azureAd.TenantId}/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri($"https://login.microsoftonline.com/{azureAd.TenantId}/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { azureAd.Scope, "Access the Portfolio API" }
                            }
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
                        },
                        new[] { azureAd.Scope }
                    }
                });
            });
        }
    
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureAd>(configuration.GetSection("AzureAd"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));
            
        }
    }
}

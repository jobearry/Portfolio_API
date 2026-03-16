using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portfolio_API.Contexts;
using Portfolio_API.Mapper;
using Portfolio_API.Models;
using Portfolio_API.Models.DTOs;
using Portfolio_API.Models.EmployeeManagementModels;
using Portfolio_API.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.Repositories;
using Portfolio_API.Services;
using System;
using System.Text;

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
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //// Register services
            //services.AddScoped<EmployeeService>();
            //services.AddScoped<AttendanceService>();
            //services.AddScoped<UserService>();

            //Common Services
            services.AddScoped(typeof(IBaseService<,>), typeof(BaseService<,>));

            //Mapper
            services.AddScoped<IMapper<Employee,DTOEmployee>, EmployeeMapper>();
            services.AddScoped<IMapper<Attendance, DTOAttendance>, AttendanceMapper>();
            services.AddScoped<IMapper<User, DTOUser>, UserMapper>();
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

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Scheme = "bearer",
                    BearerFormat = "JWT"

                    //Flows = new OpenApiOAuthFlows
                    //{
                    //    AuthorizationCode = new OpenApiOAuthFlow
                    //    {
                    //        AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{azureAd.TenantId}/oauth2/v2.0/authorize"),
                    //        TokenUrl = new Uri($"https://login.microsoftonline.com/{azureAd.TenantId}/oauth2/v2.0/token"),
                    //        Scopes = new Dictionary<string, string>
                    //        {
                    //            { azureAd.Scope, "Access the Portfolio API" }
                    //        }
                    //    }
                    //}
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                        },
                        //new[] { azureAd.Scope }
                        new string[] { }
                    }
                });
            });
        }
    
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EntraOptions>(configuration.GetSection("AzureAd"));
            // bind options and register
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
                //uncomment for entra id implementation
                //var azureAd = configuration.GetSection("AzureAd").Get<AzureAd>()!;
                //options.Authority = $"https://login.microsoftonline.com/{azureAd.TenantId}/v2.0";
                //options.Audience = azureAd.ClientId;
                //options.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuer = true,
                //    ValidIssuers = new[] { $"https://login.microsoftonline.com/{azureAd.TenantId}/v2.0" },
                //    ValidateAudience = true,
                //    ValidAudiences = new[] { azureAd.ClientId },
                //    ValidateLifetime = true
                //};

                options.RequireHttpsMetadata = false; // dev only
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
    }
}

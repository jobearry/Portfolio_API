using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Portfolio_API.DataAccess.Contexts;
using Portfolio_API.Mapper;
using Portfolio_API.DataTypes.Models;
using Portfolio_API.DataTypes.Models.DTOs;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels;
using Portfolio_API.DataTypes.Models.EmployeeManagementModels.DTOs;
using Portfolio_API.DataAccess.Repositories;
using Portfolio_API.DataAccess.Repositories.EmployeeManagementRepository;
using Portfolio_API.Services;
using Portfolio_API.Services.Employee;
using System.Text;
using Portfolio_API.Mapper.EmployeeManagement;
using Portfolio_API.DataAccess.Repositories.ResumeRepository;
using Portfolio_API.Services.Resume;

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

            // Register generic repository for Employee management
            services.AddScoped(typeof(IEmployeeBaseRepository<>), typeof(EmployeeBaseRepository<>));
            services.AddScoped(typeof(IResumeBaseRepository<>), typeof(ResumeBaseRepository<>));

            //Common Services
            services.AddScoped(typeof(IEmployeeBaseService<,>), typeof(EmployeeBaseService<,>));
            services.AddScoped(typeof(IResumeBaseService<>), typeof(ResumeBaseService<>));

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
                    Title = "JDB Portfolio API: Portfolio",
                    Version = "v1",
                    Description = "Portfolio Resource Backend Definition",
                    Contact = contactInfo
                });

                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "JDB Portfolio API: Employee Management",
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
    }
}

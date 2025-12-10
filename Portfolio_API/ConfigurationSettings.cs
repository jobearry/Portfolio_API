using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Portfolio_API.Contexts;
using Portfolio_API.Repositories;
using Portfolio_API.Services;

namespace Portfolio_API
{
    public class ConfigurationSettings
    {
        public static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            // Read connection string from appsettings.json or environment variables
            var connectionString = configuration.GetConnectionString("SqLiteConnection");

            // Register DbContext
            services.AddDbContext<PortfolioDbContext>(options =>
                options.UseSqlite(connectionString));
            // Register generic repository
            services.AddScoped(typeof(IEmployeeRepository<>), typeof(EmployeeRepository<>));

            // Register services
            services.AddScoped<EmployeeService>();
            services.AddScoped<AttendanceService>();
            //services.AddScoped<UserService>();

        }

        public static void AddCredits(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "JDB Portfolio API",
                    Version = "v1",
                    Description = "A showcase of backend APIs for personal projects",
                    Contact = new OpenApiContact
                    {
                        Name = "Jonathan Golimlim",
                        Url = new Uri("https://web-resume-jg.vercel.app/")
                    }
                });
            });
        }
    }
}

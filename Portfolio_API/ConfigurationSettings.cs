using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Portfolio_API.Contexts;

namespace Portfolio_API
{
    public class ConfigurationSettings
    {
        public static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            // Read connection string from appsettings.json or environment variables
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Register DbContext with DI
            services.AddDbContext<EmployeeManagementDevContext>(options =>
                options.UseNpgsql(connectionString)); // Replace with UseNpgsql, UseSqlite, etc.
        }

        public static void AddCredits(IServiceCollection services, IConfiguration configuration) {
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

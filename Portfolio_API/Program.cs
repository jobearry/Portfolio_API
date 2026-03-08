using Microsoft.OpenApi.Models;
using Portfolio_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
ConfigurationSettings.AddCredits(builder.Services, builder.Configuration);
ConfigurationSettings.AddDatabase(builder.Services, builder.Configuration);

var app = builder.Build();

//Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("v2/swagger.json", "JDB Portfolio API v2");
        ui.SwaggerEndpoint("v1/swagger.json", "JDB Portfolio API v1");
    });
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

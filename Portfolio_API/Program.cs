using Microsoft.OpenApi.Models;
using Portfolio_API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCredits(builder.Configuration);
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddCorsOrigins();

var app = builder.Build();

app.UseCors("AllowSPA");
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(ui =>
    {
        ui.SwaggerEndpoint("v1/swagger.json", "JDB Portfolio API v1");
        ui.SwaggerEndpoint("v2/swagger.json", "JDB Portfolio API v2");
        ui.OAuthClientId(builder.Configuration["AzureAd:ClientId"]);
        ui.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

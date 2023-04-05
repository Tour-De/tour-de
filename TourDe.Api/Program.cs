using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TourDe.Api.Routes;
using TourDe.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tour De",
        Description = "Don't be a jerk",
        Version = "v1"
    });
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<TourDeContext>(options => { options.UseInMemoryDatabase("tourde"); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tour De API v1");
    });
}

app.UseHttpsRedirection();

app.MapPersonRoutes();

app.Run();
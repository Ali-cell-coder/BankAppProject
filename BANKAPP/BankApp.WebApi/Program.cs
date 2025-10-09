using BankApp.Core.CrossCuttingConcerns.Exceptions.Middlewares;
using BankApp.Persistence;
using BankApp.Application;
using BankApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BankApp.Application.Services.Repositories;
using BankApp.Persistence.Repositories;
using MediatR;
using AutoMapper;
using BankApp.Application.Features.CreditApplications.Commands.Create;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
      
    });
});

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddDbContext<BankAppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddScoped<ICreditApplicationRepository, CreditApplicationRepository>();
builder.Services.AddScoped<ICreditTypeRepository, CreditTypeRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(BankApp.Application.AssemblyReference.Assembly));
builder.Services.AddAutoMapper(typeof(CreateCreditApplicationCommand).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataBank Core API v1");
        c.IndexStream = () => File.OpenRead("wwwroot/swagger/index.html");
    });
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseExceptionMiddleware();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

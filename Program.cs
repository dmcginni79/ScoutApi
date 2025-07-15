using FastEndpoints;
using ScoutApi.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using ScoutApi.Scouts;
using FluentValidation;
using ScoutApi.Guardians;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ScoutApiContext>();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register FastEndpoints

builder.Services.AddFastEndpoints();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IScoutService, ScoutService>();
builder.Services.AddScoped<IGuardianService, GuardianService>();
builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

var app = builder.Build();
app.UseFastEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();



app.Run();


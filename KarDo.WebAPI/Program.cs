using FluentValidation.AspNetCore;
using KarDo.Application;
using KarDo.Application.Users.Commands.UserRegistration;
using KarDo.Infrastructure.EFCore;
using KarDo.Infrastructure.EFCore.Context;
using KarDo.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserRegistrationCommandValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration
var config = builder.Configuration;
builder.Services.AddSingleton<IConfiguration>(config);

// Dependency Injection
builder.Services.AddEFCoreDependencyInjection(config);
builder.Services.AddApplicationDependencyInjection();

var app = builder.Build();

// Apply any pending migrations to the database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    await dbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

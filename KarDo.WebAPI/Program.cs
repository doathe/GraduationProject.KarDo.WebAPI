using FluentValidation.AspNetCore;
using KarDo.Application;
using KarDo.Application.Users.Commands.UserRegistration;
using KarDo.Infrastructure.EFCore;
using KarDo.Infrastructure.EFCore.Context;
using KarDo.WebAPI.Middlewares;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Net;


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    private static bool isShuttingDown = false;

    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        // API'yi kapatmadan önce gelen istekleri iþlemeyi durdur
        var applicationLifetime = host.Services.GetService<IHostApplicationLifetime>();
        applicationLifetime.ApplicationStopping.Register(() =>
        {
            isShuttingDown = true;
        });

        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls("https://192.168.1.30:7017/");
            });
}





//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserRegistrationCommandValidator>());
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//// Configuration
//var config = builder.Configuration;
//builder.Services.AddSingleton<IConfiguration>(config);

//// Dependency Injection
//builder.Services.AddEFCoreDependencyInjection(config);
//builder.Services.AddApplicationDependencyInjection();

//var app = builder.Build();

//// Apply any pending migrations to the database
//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
//    await dbContext.Database.MigrateAsync();
//}

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseMiddleware<GlobalExceptionHandler>();

//app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseRouting();
//app.UseAuthorization();

//app.MapControllers();

//var host = new WebHostBuilder()
//            .UseKestrel(options =>
//            {
//                options.Listen(IPAddress.Any, 7017, listenOptions =>
//                {
//                    listenOptions.UseHttps();
//                });
//            })
//            .UseContentRoot(Directory.GetCurrentDirectory())
//            .UseIISIntegration()
//            .UseStartup<Startup>()
//            .UseUrls("https://192.168.1.30:7017/") // <-----
//            .UseUrls("http://192.168.1.30:7017/")
//            .Build();

//host.Run();




//app.Run();

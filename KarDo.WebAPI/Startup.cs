using FluentValidation.AspNetCore;
using KarDo.Application;
using KarDo.Application.Users.Commands.UserRegistration;
using KarDo.Infrastructure.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        // Servisleri yapılandırma kodlarını burada ekle
        // Örneğin: services.AddControllers();
        services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<UserRegistrationCommandValidator>());
        services.AddEndpointsApiExplorer();
        // Swagger'ı etkinleştirme
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Name", Version = "v1" });
        });

        // DI konfigürasyonlarını buraya ekleyin
        services.AddSingleton<IConfiguration>(Configuration);
        services.AddEFCoreDependencyInjection(Configuration);
        services.AddApplicationDependencyInjection();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // HTTP request pipeline'ını yapılandırma kodlarını burada ekle
        // Örneğin: app.UseRouting();, app.UseEndpoints();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            // Swagger UI'ı etkinleştirme ve yapılandırma
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Name V1");
                // Swagger UI'ın anasayfa olarak açılmasını isterseniz aşağıdaki satırı kullanabilirsiniz.
                //c.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
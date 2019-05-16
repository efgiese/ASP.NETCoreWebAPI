using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ASP.NETCoreWebAPI.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureCors(this IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
            builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
                );
      });

    }

    public static void ConfigureSwaggerGen(this IServiceCollection services)
    {
      // Register the Swagger generator, defining one or more Swagger documents
      services.AddSwaggerGen(swag =>
      {
        swag.SwaggerDoc("v1", new Info
        {
          Title = "ASP.NETCoreWebAPI",
          Version = "0.1.0",
          Description = "ASP.NET Core Web API",
          TermsOfService = "None",
          Contact = new Contact { Name = "Edgar Giese", Email = "edgar@egiese.de" },
          License = new License { Name = "Use restricted", Url = "http://egiese.de" }
        });
        //Set the comments path for the swagger json and ui.
        var basePath = AppContext.BaseDirectory;
        var xmlPath = Path.Combine(basePath, "ASP.NETCoreWebAPI.xml");
        swag.IncludeXmlComments(xmlPath);
      });
    }

  }
}
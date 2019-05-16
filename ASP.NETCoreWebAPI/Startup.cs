using System;
using ASP.NETCoreWebAPI.Data;
using ASP.NETCoreWebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace ASP.NETCoreWebAPI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // Add CORS services.
      services.ConfigureCors();

      // Register the Swagger generator, defining one or more Swagger documents
      services.ConfigureSwaggerGen();

      services.AddDbContextPool<AppDbContext>(
          options => options.UseMySql("Server=localhost;Database=CoreWebApi;user=root;password=felina;", mySqlOptions =>
        {
          mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql);
        }
      ));

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // global cors policy
      app.UseCors("CorsPolicy");

      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NETCoreWebAPI v1");
      });

      app.UseMvc();
    }
  }
}

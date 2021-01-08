using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using InsuranceApp.Data;
using InsuranceApp.HealthCheck;
using InsuranceApp.Middleware;
using InsuranceApp.Entities;
using InsuranceApp.Validators;
using InsuranceApp.Models;

namespace InsuranceApp
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
            services.AddMvc();
            services.AddControllers()
                    .AddFluentValidation();
            services.AddDbContext<InsuranceDbContext>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<InsuranceDbInitializer>();
            services.AddScoped<IValidator<PersonDto>, PersonValidator>();
            services.AddHealthChecks()
                    .AddCheck<HealthCheckApp>("health_check");
            services.AddScoped<LimitRequestsMiddleware>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "Insurance API",
                    Description = "Webservices documentations for insurance company.",
                    Contact = new OpenApiContact
                    {
                        Name = "kicbar",
                        Email = "kicbar@gmail.com",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InsuranceDbInitializer insuranceDbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Insurance API_V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseMiddleware<LimitRequestsMiddleware>();
            app.UseMiddleware<LoggingRequestsMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHealthChecks("/health");
            });

            insuranceDbInitializer.Initialize();
        }
    }
}

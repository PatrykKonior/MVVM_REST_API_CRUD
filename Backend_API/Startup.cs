﻿using Backend_API.Data;
using Backend_API.Models.Entities;
using Backend_API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Backend_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<DesignOfficeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // CORS policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            
            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Backend API",
                    Version = "v1",
                    Description = "API Documentation for Backend System"
                });
            });

            // Register all services here
            services.AddScoped<ClientService>();
            services.AddScoped<ClientDetailsService>();
            services.AddScoped<ProjectService>();
            services.AddScoped<TasksService>();
            services.AddScoped<EmployeeService>();
            services.AddScoped<DepartmentService>();
            services.AddScoped<InvoiceService>();
            services.AddScoped<PaymentsService>();
            services.AddScoped<MaterialService>();
            services.AddScoped<ProjectMaterialService>();
            services.AddScoped<SalesService>();
            services.AddScoped<SaleItemsService>();
            services.AddScoped<ContractService>();
            services.AddScoped<ExpenseService>();
            services.AddScoped<TimeLogsService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Enable Swagger in Development
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend API v1");
                    c.RoutePrefix = "swagger"; // Swagger UI will be at root URL
                });
            }

            // Enable CORS
            app.UseCors("AllowAllOrigins");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
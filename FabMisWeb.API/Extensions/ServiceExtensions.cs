using FabMisWeb.Model;
using FabMisWeb.Repository.Contracts;
using FabMisWeb.Repository.Implementations;
using FabMisWeb.Services.Contracts;
using FabMisWeb.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FabMisWeb.Common.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            //Adding Policy
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();
            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

            //Registering Repository
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IMDDRepository, MDDRepository>();


            //Registering Service
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IMDDService, MDDService>();
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
    }
}

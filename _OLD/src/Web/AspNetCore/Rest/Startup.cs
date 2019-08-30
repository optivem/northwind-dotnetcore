﻿using System;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Northwind.Core.Application.Services;
using Optivem.Northwind.Core.Application.Services.Default;
using Optivem.Northwind.Core.Domain.Repositories;
using Optivem.Northwind.Infrastructure.Application.Mapping.AutoMapper;
using Optivem.Northwind.Infrastructure.Domain.Repositories.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.Common.Mapping.AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using MediatR;
using System.Linq;
using Optivem.Northwind.Core.Application.UseCases.SupplierUseCases.CreateSupplier;
using FluentValidation;
using FluentValidation.AspNetCore;
// using static FluentValidation.DependencyInjectionExtensions;
using Optivem.Northwind.Core.Application.UseCases.Behaviors;

namespace Optivem.Northwind.Web.Rest
{
    public class Startup
    {
        private const string NorthwindContextConnectionStringKey = "Northwind";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateSupplierValidator>());

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // var useCaseAssembly = allAssemblies.Single(e => e.FullName == "Optivem.Northwind.Core.Application.UseCases");
            var useCaseAssembly = typeof(CreateSupplierHandler).Assembly;

            // MediatR

            services.AddMediatR(useCaseAssembly);
            // AddScopedCollection<IValidator>(services, useCaseAssembly);
            // AddScopedCollection<IValidator>(services, useCaseAssembly);
            // AddScopedCollection<IValidator>(services, useCaseAssembly);
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));


            // CORS

            services.AddCors();

            // Mapping

            services.AddScoped<IMappingService, AutoMapperMappingService>();

            // services.AddAutoMapper(Assembly.GetAssembly(typeof(SupplierRequestMapping)));

            services.AddAutoMapper(useCaseAssembly);

            // DB Context
            var connection = Configuration.GetConnectionString(NorthwindContextConnectionStringKey);
            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connection));

            // Unit of work
            services.AddScoped<INorthwindUnitOfWork, NorthwindUnitOfWork>();

            // Application services
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeePrivilegeService, EmployeePrivilegeService>();
            services.AddScoped<IInventoryTransactionService, InventoryTransactionService>();
            services.AddScoped<IInventoryTransactionTypeService, InventoryTransactionTypeService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderDetailStatusService, OrderDetailStatusService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<IOrderTaxStatusService, OrderTaxStatusService>();
            services.AddScoped<IPrivilegeService, PrivilegeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
            services.AddScoped<IPurchaseOrderDetailService, PurchaseOrderDetailService>();
            services.AddScoped<IPurchaseOrderStatusService, PurchaseOrderStatusService>();
            services.AddScoped<IShipperService, ShipperService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }

        // TODO: VC: Move to extensions
        /*
        private static void AddScopedCollection<T>(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(e => e.DefinedTypes.Where(f => f.GetInterfaces().Contains(typeof(T))));

            foreach(var type in types)
            {
                services.AddScoped(typeof(T), type);
            }
        }
        */
    }
}
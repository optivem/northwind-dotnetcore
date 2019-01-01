﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Optivem.Northwind.Core.Application.Mapping;
using Optivem.Northwind.Core.Application.Service;
using Optivem.Northwind.Core.Domain.Repository;
using Optivem.Northwind.Infrastructure.Repository;

namespace Optivem.Northwind
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
            services.AddMvc();

            // Mapping
            services.AddAutoMapper(e =>
            {
                e.AddProfile(new SupplierRequestMapping());
                e.AddProfile(new SupplierResponseMapping());
            });

            // DB Context
            var connection = Configuration.GetConnectionString(NorthwindContextConnectionStringKey);
            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connection));

            // Unit of work
            services.AddScoped<INorthwindUnitOfWork, NorthwindUnitOfWork>();

            // Application services
            services.AddScoped<ISupplierService, SupplierService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IRegionService, RegionService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ICustomerService, CustomerService>();
			services.AddScoped<ICustomerCustomerDemoService, CustomerCustomerDemoService>();

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

		// TODO: JC: Test commit
    }
}

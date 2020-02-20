using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MDProducaoAPI.Repository;
using MDProducaoAPI.Repository.Interfaces;
using MDProducaoAPI.Service;
using MDProducaoAPI.Service.Interfaces;
using MDProducaoAPI.Repository.Transformers;
using System.Net.Http;

namespace MDProducaoAPI
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
            services.AddCors();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IManufacturingPlanService, ManufacturingPlanService>();
            services.AddTransient<IManufacturingPlanRepository, ManufacturingPlanRepository>();
            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<IOperationRepository, OperationRepository>();

            var sqlConnection = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<Context>(opt => opt.UseSqlServer(sqlConnection));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting(option =>
        {
            option.ConstraintMap["ProductId"] = typeof(ProductIdParameterTransformer);
            option.LowercaseUrls = true;
        });
            services.AddRouting(option =>
        {
            option.ConstraintMap["ManufacturingPlanId"] = typeof(ManufacturingPlanIdParameterTransformer);
            option.LowercaseUrls = true;
        });
            services.AddRouting(option =>
        {
            option.ConstraintMap["OperationId"] = typeof(OperationIdParameterTransformer);
            option.LowercaseUrls = true;
        });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

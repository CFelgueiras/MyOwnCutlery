using MDFabricaAPI.Repository;
using MDFabricaAPI.Repository.Interfaces;
using MDFabricaAPI.Service;
using MDFabricaAPI.Service.Interfaces;
using MDFabricaAPI.Repository.Transformers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MDFabricaAPI
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
            services.AddOpenApiDocument();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IOperationService, OperationService>();
            services.AddTransient<IOperationRepository, OperationRepository>();
            services.AddTransient<IMachineService, MachineService>();
            services.AddTransient<IMachineRepository, MachineRepository>();
            services.AddTransient<IMachineTypeService, MachineTypeService>();
            services.AddTransient<IMachineTypeRepository, MachineTypeRepository>();
            services.AddTransient<IProductionLineService, ProductionLineService>();
            services.AddTransient<IProductionLineRepository, ProductionLineRepository>();

            var sqlConnection = Configuration.GetConnectionString("sqlConnection");
            services.AddDbContext<Context>(opt => opt.UseSqlServer(sqlConnection));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting(option =>
            {
                option.ConstraintMap["OperationId"] = typeof(OperationIdParameterTransformer);
                option.LowercaseUrls = true;
            });
            services.AddRouting(option =>
            {
                option.ConstraintMap["MachineId"] = typeof(MachineIdParameterTransformer);
                option.LowercaseUrls = true;
            });
            services.AddRouting(option =>
            {
                option.ConstraintMap["MachineTypeId"] = typeof(MachineTypeIdParameterTransformer);
                option.LowercaseUrls = true;
            });
            services.AddRouting(option =>
            {
                option.ConstraintMap["ProductionLineId"] = typeof(ProductionLineIdParameterTransformer);
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
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseReDoc();
        }
    }
}

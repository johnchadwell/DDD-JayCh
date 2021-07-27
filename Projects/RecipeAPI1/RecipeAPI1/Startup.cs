using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeAPI1.Models;
using RecipeAPI1.Repositories;

namespace RecipeAPI1
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
            ////services.AddSingleton<ICustomerRepository, CustomerRepository>();
            ////services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            //services.AddDbContext<RecipeContext>(opt => opt.UseInMemoryDatabase("EmployeeList"));
            services.AddDbContext<RecipeContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:RecipeDB"]));
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            services.AddScoped<IIngredientItemRepository, IngredientItemRepository>();
            services.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            //services.AddScoped<IKindOfMenuItemRepository, KindOfMenuItemRepository>();
            //services.AddScoped<IMenuRepository, MenuRepository>();
            //services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            //services.AddScoped<IOptionalMenuItemRepository, OptionalMenuItemRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipeAPI1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipeAPI1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .WithOrigins("https://localhost:44382/")
                .WithOrigins("https://localhost:44311/")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

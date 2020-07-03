using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BiSanat.DAL.Repositories;
using BiSanat.DAL.Repositories.Abstract;
using BiSanat.DAL.Repositories.Concrete.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace BiSanat.API
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
            services.AddControllers();
            services.AddDbContext<BiContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);
            services.AddTransient<ICategoriesProductDAL, CategoriesProductDAL>();
            services.AddTransient<ICategoryDAL, CategoryDAL>();
            services.AddTransient<ICommentDAL, CommentDAL>();
            services.AddTransient<IOrderDAL, OrderDAL>();
            services.AddTransient<IOrderLineItemDAL, OrderLineItemDAL>();
            services.AddTransient<IPersonDAL, PersonDAL>();
            services.AddTransient<IProductDAL, ProductDAL>();
            services
                .AddMvc()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy
                    = null);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

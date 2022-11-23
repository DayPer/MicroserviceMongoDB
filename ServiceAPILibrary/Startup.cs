using APIServiceCard.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using APIServiceCard.Core;
using APIServiceCard.Core.ContextMongoDB;
using ServiceAPILibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIServiceCard
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
            services.Configure<MongoSetting>(
                options =>
                {
                    options.ConnecionString = Configuration.GetSection("MongoDB:ConnectionString").Value;
                    options.DataBase = Configuration.GetSection("MongoDB:DataBase").Value;
                });

            services.AddSingleton<MongoSetting>();
            services.AddTransient<ICardContext, CardContext>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "APIServiceCard", Version = "v1" });
            });

            //CORS Control
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsRule", rule =>
                 {
                     rule.AllowAnyHeader().AllowAnyMethod().WithOrigins("*");
                 });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIServiceCard v1"));
            }

            app.UseRouting();

            app.UseCors("CorsRule");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

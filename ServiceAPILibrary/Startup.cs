using APIServiceTest.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using APIServiceTest.Core;
using APIServiceTest.Core.ContextMongoDB;
using ServiceAPILibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using APIServiceTest.Repository;
using APIServiceTest.Core.ContextMongoDB;

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
                    options.ConnecionString = Configuration.GetSection("MongoDB:DBConnectionString").Value;
                    options.DataBase = Configuration.GetSection("MongoDB:DataBase").Value;

        });

            services.AddSingleton<MongoSetting>();

            services.AddTransient<ICardContext, CardContext>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CardRepository>());

            services.AddTransient<IUserContext, UserContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserRepository>());

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

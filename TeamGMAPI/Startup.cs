using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamGM.DATA.Context;
using TeamGMAPI.Configuration;
using BaseAPI.Data;
using System.Reflection;
using System.IO;

namespace TeamGMAPI
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
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            

            services.AddIdentityConfiguration(Configuration);
            services.AddTeamGmService();
            services.AddControllers();

            services.AddDbContext<DesafioAtosContext>(options =>
            options.UseOracle(Configuration.GetConnectionString("DesafioAtosConnection")));
            /*options.UseSqlServer(Configuration.GetConnectionString("SQL_SERVER_Connection"),
            b => b.MigrationsAssembly("Base.DATA")));*/

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Desafio Atos 2021", 
                    Version = "v1",
                    Description = "ASP.NET Core Web API para gerenciamento de Vendas e Clientes da Empresa NetBull."
                });
                options.IncludeXmlComments(xmlPath, true);
            });
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TeamGMAPI v1"));
            }
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthorization();
            


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

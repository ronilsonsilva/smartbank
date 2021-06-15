using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SmartBank.DataValid.Api.Configurations;
using SmartBank.DataValid.Api.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartBank.DataValid.api
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartBank.DataValid.api", Version = "v1" });
            });

            this.ResolveDependencias(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartBank.DataValid.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ResolveDependencias(IServiceCollection services)
        {
            //var dataValid = new DataValidConfig()
            //{
            //    ConsumerKey = this.Configuration.GetSection("DATA_VALID:CONSUMER_KEY").ToString(),
            //    ConsumerSecret = this.Configuration.GetSection("DATA_VALID:CONSUMER_SECRET").ToString(),
            //    UriBase = this.Configuration.GetSection("DATA_VALID:URI_BASE").ToString(),
            //};
            
            var dataValid = new DataValidConfig()
            {
                ConsumerKey = "gsmoVBrf59naN86smzFd2NrKQoga",
                ConsumerSecret = "Ebdl6VQH_cLe7hkMDzELTLspCooa",
                UriBase = "https://gateway.apiserpro.serpro.gov.br",
            };
            services.AddSingleton<DataValidConfig>(dataValid);

            services.AddSingleton<IDataValidIntegrationServices, DataValidIntegrationServices>();

        }
    }
}

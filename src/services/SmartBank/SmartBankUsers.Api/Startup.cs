using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBank.Api.Configurations;
using SmartBank.Application.AutoMapper;
using SmartBank.Infra.CrossCutting.Ioc;

namespace SmartBankUsers.Api
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
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));

            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddApiConfiguration();
            //services.AddIdentityConfiguration(Configuration);
            services.AddSwaggerConfiguration();

            // Configurar Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Configuration());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            RegisterServices(services, this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);
        }

        private static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}

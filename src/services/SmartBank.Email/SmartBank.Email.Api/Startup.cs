using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartBank.Email.Api.Application.Services;
using SmartBank.Email.Api.Configurations;
using SmartBank.Email.Api.Models;

namespace SmartBank.Email.Api
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
            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new Configuration());
            //});

            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);
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
            #region [Email]

            //Configuração do E-mail
            var emailConfiguration = new EmailConfiguration();
            emailConfiguration.From = configuration["EmailConfiguration:From"];
            emailConfiguration.SmtpServer = configuration["EmailConfiguration:SmtpServer"];
            emailConfiguration.Port = int.Parse(configuration["EmailConfiguration:Port"]);
            emailConfiguration.UserName = configuration["EmailConfiguration:UserName"];
            emailConfiguration.Password = configuration["EmailConfiguration:Password"];
            emailConfiguration.SendGridKey = configuration["EmailConfiguration:SendGridKey"];
            services.AddSingleton<EmailConfiguration>(emailConfiguration);

            services.AddScoped<IEmailSender, EmailSender>();

            #endregion

            services.AddMessageBusConfiguration(configuration);
        }
    }
}

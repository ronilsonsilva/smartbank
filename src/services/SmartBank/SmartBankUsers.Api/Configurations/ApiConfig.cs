using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SmartBank.Api.Extensions;
using SmartBank.Api.Filters;

namespace SmartBank.Api.Configurations
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services
                .AddControllers(options => options.Filters.Add<NotificationFilter>())
                .AddNewtonsoftJson(options => options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects);

            #region [Configurações do IdentityServer]

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://sso.ronilson.dev";
                o.Audience = "api_teste";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                //options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            });

            #endregion

            return services;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            //app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}

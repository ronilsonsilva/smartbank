using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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

            services.AddAuthentication("Bearer")
                .AddJwtBearer(o =>
                {
                    o.Authority = "https://sso.ronilson.dev";
                    o.Audience = "api_cliente_smart_bank";
                    o.RequireHttpsMetadata = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("ClientIdPolicy", policy => policy.RequireClaim("client_id", "movieClient", "movies_mvc_client"));
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}

﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;;
using Microsoft.OpenApi.Models;
using System;

namespace SmartBank.DataValid.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "SmartBank API Obras",
                    Version = "1.0",
                    Description = "API para gerenciamento de clientes",
                    Contact = new OpenApiContact() { Name = "Ronilson Silva", Email = "ronilson@sousasilva.eng.br" },
                    License = new OpenApiLicense() { Name = "Privada", Url = new Uri("http://sousasilva.eng.br/") }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API - SmartObras V0.0.001");
            });

            return app;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace ProjetoFilmes
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "react.front";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adiciona padrão MVC ao projeto
                .AddMvc()

                // Define a versão compatível do SDK .NET Core
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1)

            .AddJsonOptions(options => {
                 options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
             });

            // Documentação Swagger

            // https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.1&tabs=visual-studio
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Senai.Filmes.WebApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // cors configuration
            services
               .AddCors(options =>
               {
                   options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                   {
                       builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                   });
               });

            services
                // Define as configurações de autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })


                // Define os parâmetros de autenticação
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // Valida o emissor
                        ValidateIssuer = true,

                        // Valida o receptor
                        ValidateAudience = true,

                        // Valida o tempo de vida
                        ValidateLifetime = true,

                        // Define a chave de autenticação
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao")),

                        // Define o tempo de expiração
                        ClockSkew = TimeSpan.FromMinutes(30),

                        // Define quem é emissor
                        ValidIssuer = "Filmes.WebApi",

                        // Define quem é o receptor
                        ValidAudience = "Filmes.WebApi"
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai.Filmes.WebApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            // Define o uso de autenticação
            app.UseAuthentication();

            // Define o uso do MVC
            app.UseMvc();
        }
    }
}

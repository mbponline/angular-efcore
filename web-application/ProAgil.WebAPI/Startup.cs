using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using ProAgil.Domain.identity;
using ProAgil.Repository;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.Swagger;
using ProAgil.WebAPI.Helpers;
using Microsoft.OpenApi.Models;
using System;
using ProAgil.Domain;

namespace ProAgil.WebAPI
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
            var migrationAssembly = "ProAgil.Repository"; // typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ProAgilContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sql => sql.MigrationsAssembly(migrationAssembly)));

            IdentityBuilder builder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<ProAgilContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                           .AddJwtBearer(options =>
                               {
                                   options.TokenValidationParameters = new TokenValidationParameters
                                   {
                                       // validação pela assinatura da chave do emissor
                                       ValidateIssuerSigningKey = true,
                                       // chave do emissor
                                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                                       ValidateIssuer = false,
                                       ValidateAudience = false
                                   };
                               }
                           );

            services.AddMvc(options =>
            {
                // política para autorizar acesso a controlers 
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Injetar Dependecias
            services.AddScoped<IProAgilRepository<RedeSocial>, ProAgilRepository<RedeSocial>>();
            services.AddScoped<IProAgilRepository<Evento>, ProAgilRepository<Evento>>();
            services.AddScoped<IProAgilRepository<Lote>, ProAgilRepository<Lote>>();
            services.AddScoped<IProAgilRepository<Palestrante>, ProAgilRepository<Palestrante>>();
            services.AddAutoMapper();
            services.AddApiVersioning(options =>
            {
                options.UseApiBehavior = false;
                // assume valor padrão se não específicado
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(majorVersion: 2, minorVersion: 0);
                // pode ser usado para criar diferentes versões de métodos API sem ter que criar outra URL
                // bastando adicionar no header da requisição o key abaixo e valor definido no método
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
                // informa no cabeçalho se versão está obsoleta
                options.ReportApiVersions = true;
                //   options.ApiVersionReader = new  ApiVersionHeader("");
            });

            services.AddVersionedApiExplorer(options =>
            {
                // v -> versão VV -> major e minor version V -> Path Url
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;

            });

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Documentação API Eventos Swagger",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Shayne Boyer",
                            Email = string.Empty,
                            Url = new Uri("https://twitter.com/spboyer"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    });
                    c.SwaggerDoc("v2", new OpenApiInfo
                    {
                        Version = "v2",
                        Title = "Documentação API Eventos Swagger",
                        Description = "A simple example ASP.NET Core Web API",
                        TermsOfService = new Uri("https://example.com/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "Shayne Boyer",
                            Email = string.Empty,
                            Url = new Uri("https://twitter.com/spboyer"),
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX",
                            Url = new Uri("https://example.com/license"),
                        }
                    });
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Por favor coloque o valor 'Bearer' seguido de um espaço em branco e depois o valor do token no formato JWT!",
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey
                    });

                   c.AddSecurityRequirement( new OpenApiSecurityRequirement { { new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }, new string[] { } } } );
                    //  c.DocumentFilter<SwaggerExcludeFilter>(); // para ocultar models DTO na tela pricipal add o nome da model dentro da classe.
                });

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //permite compartilhamento de recursos cruzados para toda origem, todos os métodos e todos os cabeçalhos
                app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }
            else
            {
                //permite compartilhamento de recursos cruzados para toda origem, todos os métodos e todos os cabeçalhos
                app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                app.UseHsts();
            }
            // app.UseHttpsRedirection(); desabilitado https temporariamente

            app.UseStaticFiles(); //acessar imagens no diretorio raiz
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseSwagger();
            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1.0");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "API V2.0");

                }
                );
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);
            app.UseAuthentication();

            app.UseMvc();
        }

    }

}

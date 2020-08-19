using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Help247.Utilities.Configurations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Help247.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Help247
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            //Connection String
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Identity
            services.AddIdentity<Help247.Data.Entities.User, IdentityRole>(opt => opt.SignIn.RequireConfirmedEmail = true)
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<AppDbContext>()
                        .AddDefaultTokenProviders();

            //JWT
            services.AddAuthentication()
               .AddJwtBearer(cfg =>
               {
                   cfg.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidIssuer = Configuration["Tokens:Issuer"],
                       ValidAudience = Configuration["Tokens:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                   };
               });

            //AutoMapper
            var mapping = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mapping.CreateMapper();
            services.AddSingleton(mapper);

            //Dependency Injection
            IocConfig.InjectServices(services);
            services.AddHttpContextAccessor();

            services.AddMvc(options => options.EnableEndpointRouting = false);
            //OR).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "Help24/7 API", 
                    Version = "v1", 
                    Description = "Help 24/7",
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            //if (!env.IsDevelopment())
            //{
            //    app.UseSpaStaticFiles();
            //}

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Help24/7 API V1");
                c.RoutePrefix = "swagger";
            });

            app.UseCors(builder => builder.WithOrigins("*")/*.AllowAnyOrigin()*/.AllowAnyHeader().AllowAnyMethod());


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseAngularCliServer(npmScript: "start");
            //    }
            //});

            // for each angular client we want to host. 
            app.Map(new PathString("/admin"), client =>
            {
                if (env.IsDevelopment())
                {
                    StaticFileOptions clientApp1Dist = new StaticFileOptions()
                    {
                        FileProvider = new PhysicalFileProvider(
                                Path.Combine(
                                    Directory.GetCurrentDirectory(),
                                    @"ClientApp"
                                )
                            )
                    };
                    client.UseSpaStaticFiles(clientApp1Dist);
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp";

                        // it will use package.json & will search for start command to run
                        spa.UseAngularCliServer(npmScript: "start");
                    });

                }
                else
                {
                    // Each map gets its own physical path
                    // for it to map the static files to. 
                    StaticFileOptions clientAppDist = new StaticFileOptions()
                    {
                        FileProvider = new PhysicalFileProvider(
                                Path.Combine(
                                    Directory.GetCurrentDirectory(),
                                    @"ClientApp/dist"
                                )
                            )
                    };

                    // Each map its own static files otherwise
                    // it will only ever serve index.html no matter the filename 
                    client.UseSpaStaticFiles(clientAppDist);

                    // Each map will call its own UseSpa where
                    // we give its own sourcepath
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "ClientApp";
                        spa.Options.DefaultPageStaticFileOptions = clientAppDist;
                    });

                }

            });

            // for each angular client we want to host. 
            app.Map(new PathString("/app"), client =>
            {
                if (env.IsDevelopment())
                {
                    StaticFileOptions helpWebDist = new StaticFileOptions()
                    {
                        FileProvider = new PhysicalFileProvider(
                                Path.Combine(
                                    Directory.GetCurrentDirectory(),
                                    @"HelpWeb"
                                )
                            )
                    };
                    client.UseSpaStaticFiles(helpWebDist);
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "HelpWeb";

                        // it will use package.json & will search for start command to run
                        spa.UseAngularCliServer(npmScript: "start");
                    });

                }
                else
                {
                    // Each map gets its own physical path
                    // for it to map the static files to. 
                    StaticFileOptions helpWebDist = new StaticFileOptions()
                    {
                        FileProvider = new PhysicalFileProvider(
                                Path.Combine(
                                    Directory.GetCurrentDirectory(),
                                    @"HelpWeb/dist"
                                )
                            )
                    };

                    // Each map its own static files otherwise
                    // it will only ever serve index.html no matter the filename 
                    client.UseSpaStaticFiles(helpWebDist);

                    // Each map will call its own UseSpa where
                    // we give its own sourcepath
                    client.UseSpa(spa =>
                    {
                        spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                        spa.Options.SourcePath = "HelpWeb";
                        spa.Options.DefaultPageStaticFileOptions = helpWebDist;
                    });

                }

            });



        }
    }
}

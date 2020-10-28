using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using serverdespacho.Entidades;
using serverdespacho.Negocio;
using serverdespacho.Peristencia;
using serverdespacho.Seguridad;
using System;
using System.IO;
using System.Reflection;

namespace serverdespacho
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
            services.AddTransient<AuthNegocio, AuthNegocio>();
            services.AddTransient<DespachoNegocio, DespachoNegocio>();
            services.AddTransient<NotificacionNegocio, NotificacionNegocio>();
            services.AddTransient<OfertaNegocio, OfertaNegocio>();
            services.AddTransient<UsuarioNegocio, UsuarioNegocio>();
            services.AddTransient<ConfiguracionNegocio, ConfiguracionNegocio>();
            services.AddTransient<CatalogoNegocio, CatalogoNegocio>();
            services.AddTransient<ServicioNegocio, ServicioNegocio>();

            services.AddIdentity<Usuario, Rol>(options =>
            {
                //User options
                options.User.RequireUniqueEmail = true;

                //Login options
                //options.SignIn.RequireConfirmedEmail = true;

                //Password options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<DBContext>().AddDefaultTokenProviders();

          
            services.AddDbContext<DBContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DBConnection"))
            );

            //JWT Auth
            services.AddTokenAuthentication(Configuration);


            //Enable CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "JWT Authentication API",
                    Description = "API to authentication with JWT.",
                    TermsOfService = new Uri("https://scare.org.co/politica-privacidad/"),
                    Contact = new OpenApiContact
                    {
                        Name = "S.C.A.R.E.",
                        Email = "servicioalcliente@scare.org.co",
                        Url = new Uri("https://scare.org.co/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://scare.org.co/politica-privacidad/"),
                    }

                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });


            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "API Autenticación";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "JWT Auth API");
                c.RoutePrefix = String.Empty;
            });
            //Enable CORS
            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

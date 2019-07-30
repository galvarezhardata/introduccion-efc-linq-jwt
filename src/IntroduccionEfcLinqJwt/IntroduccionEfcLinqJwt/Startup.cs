using IntroduccionEfcLinqJwt.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntroduccionEfcLinqJwt
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Agregamos servicios de autorización, el motor de vistas Razor y los formateadores JSON.
            // IMPORTANTE!: existe algo llamado AddMvcCore(), cumple la misma función que AddMvc() PERO agrega menos funcionalidades. AddMvc() es la posta
            services.AddMvc();

            // Nos aseguramos de que las cosas no dejen de funcionar si en futuras versiones los chicos de MS hacen cambios en el comportamiento del framework.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Agregamos los servicios necesarios para poder conectarnos con el servidor de T-SQL.
            // Pero antes de hacer ésto debemos 
            // 1) Tener la base de datos ya creada.
            // 2) Instalar las dependencias: Microsoft.EntityFrameworkCore.SqlServer.
            // 3) Ejecutar en la línea de comandos de desarrollo (Tools / NuGet Package Manager / Package Manager Console):
            // Server=.;Database=EfcLinqJwtIntro;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
            services.AddDbContext<EfcLinqJwtIntroContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MyConnectionString")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}

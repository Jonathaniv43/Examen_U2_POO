using ExamenSegundaUnidad.Database.Context;
using ExamenSegundaUnidad.Helpers;
using ExamenSegundaUnidad.Service;
using ExamenSegundaUnidad.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ExamenSegundaUnidad
{
    public class Startup
    {
       
            private IConfiguration Configuration { get; }

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public void ConfigureServices(IServiceCollection services)
            {
                services.AddControllers();
                services.AddEndpointsApiExplorer();
                services.AddSwaggerGen();
                var name = Configuration.GetConnectionString("DefaultConnection");
     
                services.AddDbContext<ProjectServiceDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      
                services.AddTransient<IProspectsService, ProspectsService>();


                // Add AutoMapper
                services.AddAutoMapper(typeof(AutoMapperProfile));

            }
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseAuthorization();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }

        }
    }



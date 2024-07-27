using ExamenSegundaUnidad.Database.Context;
using ExamenSegundaUnidad.Database.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ExamenSegundaUnidad.Database.SeederLog
{
    public class ProjectServiceSeeder
    {
        public static async Task LoadDataAsync(
           ProjectServiceDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                await LoadNewAsync(context, loggerFactory);
                //await LoadPackageAsync(context, loggerFactory);

            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProjectServiceSeeder>();
                logger.LogError(e, "Error inicializando la data del API.");
            }
        }

        public static async Task LoadNewAsync(ProjectServiceDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var jsonFilePath = "SeedData/loans.json";
                var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
                var news = JsonConvert.DeserializeObject<List<ProspectsEntity>>(jsonContent);

                if (!await context.Prospects.AnyAsync())
                {
                    //foreach (var n in News)
                    //{
                    //    n.OrderDate = DateTime.Now;
                    //}

                    await context.Prospects.AddRangeAsync(news);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<ProjectServiceSeeder>();
                logger.LogError(e, "Error al ejecutar el Seed Order.");
            }
        }

        //public static async Task LoadPackageAsync(ILoggerFactory loggerFactory, PackageServiceDbContext contex)
        //{
        //    var jsonFilePath = "SeedData/Package.json";
        //    var jsonContent = await File.ReadAllTextAsync(jsonFilePath);
        //    var package = JsonConvert.DeserializeObject<List<PackageEntity>>(jsonContent);
        //    if (!await contex.Packages.AnyAsync()) { 

        //        for (int i=0; i<package.Count; i++)
        //        {

        //        }
        //    }
        //}
    }
}

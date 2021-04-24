using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Api.Search
{
    /// <summary>
    /// The Program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Main
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create Host Builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

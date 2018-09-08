using Microsoft.Extensions.Configuration;
using System.IO;

namespace SAC.CORE.WEB.Infrastructure
{
    public class Helper
    {
        public static IConfiguration Configuration { get; set; }

        public string GetUrlPathApi()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            return Configuration["PathServer"].ToString();
        }
    }
}
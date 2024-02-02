using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace MovieRental.DAL
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MovieRental"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MSSql");
            }
        }
    }
}

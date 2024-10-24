using System.Reflection;

namespace RechartsAPI
{
    public class Settings
    {
        //pego meu diretório do appsetings
        private static string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/appsettings.json";

        //Crio minha connectionString
        private static IConfiguration configuration = new ConfigurationBuilder()
                                               .SetBasePath(Path.GetDirectoryName(directory))
                                               .AddJsonFile("appsettings.json")
                                               .Build();
        public static string SQLConnectionString => configuration.GetConnectionString("DefaultConnection");
    }
}

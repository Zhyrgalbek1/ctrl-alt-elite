using Microsoft.Extensions.Configuration;

namespace Task_Meneger.Controllers.Additional_settings.Connection
{
    public class Connection
    {
        public string ChangeCon(string nameJsonFile)
        {
            var config = new ConfigurationBuilder().AddJsonFile($"{nameJsonFile}").Build();
            var connectionString = config.GetSection("ConnectionStrings:DefaultConnection").Value;
            return connectionString;
        }
        public string DefaultCon()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = config.GetSection("ConnectionStrings:DefaultConnection").Value;
            return connectionString;
        }
    }
}

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Training.Docker.WebApp.Models.ItemRepository;

namespace Training.Docker.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .MigrateDatabase()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }   
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Training.Docker.WebApp.Models.ItemRepository
{
    public static class ItemContextSeed
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ItemContext>();

                context.Database.Migrate();

                if (!context.Items.Any())
                {
                    var list = new List<Item>
                    {
                        new Item { Value = "To drink coffe" },
                        new Item { Value = "To conquer the world" },
                        new Item { Value = "To go to sleep" }
                    };

                    context.Items.AddRange(list);
                    context.SaveChanges();
                }
            }

            return webHost;
        }
    }
}

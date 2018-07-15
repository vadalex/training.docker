using Microsoft.EntityFrameworkCore;

namespace Training.Docker.WebApp.Models.ItemRepository
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options) { }

        public virtual DbSet<Item> Items { get; set; }
    }    
}

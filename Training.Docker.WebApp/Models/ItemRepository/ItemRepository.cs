using System.Collections.Generic;

namespace Training.Docker.WebApp.Models.ItemRepository
{
    public class ItemRepository : IItemRepository
    {
        private ItemContext itemContext;

        public ItemRepository(ItemContext itemContext)
        {
            this.itemContext = itemContext;
        }

        public IEnumerable<Item> GetAll()
        {
            return itemContext.Items;
        }

        public void Add(string value)
        {
            itemContext.Add(new Item { Value = value });
            itemContext.SaveChanges();
        }
    }
}

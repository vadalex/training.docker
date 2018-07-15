using System.Collections.Generic;

namespace Training.Docker.WebApp.Models.ItemRepository
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();

        void Add(string value);
    }
}

using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using catalog.Entities;

namespace catalog.Repositories{
   

    public class InMemItemsRepository  : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id=Guid.NewGuid(),Name="potion",Price=9,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id=Guid.NewGuid(),Name="Iron Sword",Price=20,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id=Guid.NewGuid(),Name="Potion",Price=9,CreatedDate = DateTimeOffset.UtcNow}

        };
        public IEnumerable<Item> GetItemsAsync()
        {
            //var items = repository.GetItems();
            return items;
        }
        public Item GetItemAsync(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreatItemAsync(Item item){
            items.Add(item);
        }

        public void UpdateItemAsync(Item item)
        {
            var index =items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
        public void DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
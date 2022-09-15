using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using catalog.Entities;
using System.Threading.Tasks;

namespace catalog.Repositories{
   

    public class InMemItemsRepository  : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id=Guid.NewGuid(),Name="potion",Price=9,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id=Guid.NewGuid(),Name="Iron Sword",Price=20,CreatedDate = DateTimeOffset.UtcNow},
            new Item {Id=Guid.NewGuid(),Name="Potion",Price=9,CreatedDate = DateTimeOffset.UtcNow}

        };
        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            //var items = repository.GetItems();
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreatItemAsync(Item item){
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index =items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }
        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}
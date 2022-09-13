using System;
using System.Collections.Generic;
using catalog.Entities;

namespace catalog.Repositories
{
    public interface IItemsRepository
    {
        Item GetItemAsync(Guid id);
        IEnumerable<Item> GetItemsAsync();
        void  CreatItemAsync(Item item);
        void UpdateItemAsync(Item item);
        void DeleteItemAsync(Guid id);
         
    }
}
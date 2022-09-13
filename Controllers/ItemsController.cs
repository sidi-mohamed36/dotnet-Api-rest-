using System;
using System.Collections.Generic;
using catalog.Repositories;
using catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using catalog.Dtos;

namespace catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemsController(IItemsRepository repository)
        {
            this.repository =repository;
        }
        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
           var items =repository.GetItemsAsync().Select(item => item.AsDto()
           );
           return items;
        }
        // GET/items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
           var item =repository.GetItemAsync(id).AsDto();
           if(item is null){
            return NotFound();
           }
           return item;
        }
         //POST /items
         [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto){
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreatItemAsync(item);
            return CreatedAtAction(nameof(GetItem),new {id = item.Id},item.AsDto());
        }

        //PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItemAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            Item updatedItem = existingItem with {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }
        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItemAsync(id);
            if(existingItem is null)
            {
                return NotFound();
            }
            repository.DeleteItemAsync(id);
            return NoContent();
            
        }
    }
}
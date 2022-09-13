using System.ComponentModel.DataAnnotations;

namespace catalog.Dtos
{
    public class CreateItemDto
    {
        [Required]
        public string Name {get;init;}
        [Required]
        [Range(1,10000)]
        public decimal Price {get;init;}
    }
}
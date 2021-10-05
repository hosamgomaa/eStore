using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Product
{
    public class Product :BaseEntity
    {   [Required]
        public string Name { get; set; }
    }
}
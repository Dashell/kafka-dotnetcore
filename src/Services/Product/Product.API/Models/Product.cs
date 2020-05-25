using System.ComponentModel.DataAnnotations;

namespace Product.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

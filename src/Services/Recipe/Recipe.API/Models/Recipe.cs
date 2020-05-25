using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recipe.API.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RecipeProduct> Products { get; set; }
    }
}

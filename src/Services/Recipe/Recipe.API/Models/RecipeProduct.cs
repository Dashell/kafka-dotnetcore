using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.API.Models
{
    public class RecipeProduct
    {
        public virtual Recipe Recipe { get; set; }
        public int RecipeId { get; set; }

        public int ProductId { get; set; }

    }
}

namespace Recipe.API.Models
{
    public class RecipeProduct
    {
        public virtual Recipe Recipe { get; set; }
        public int RecipeId { get; set; }

        public int ProductId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.API.Repositories.Interfcaces
{
    public interface IRecipeRepository
    {
        Task RemoveRecipeWithProduct(int productId);
        Task<IEnumerable<Models.Recipe>> GetAll();
    }
}

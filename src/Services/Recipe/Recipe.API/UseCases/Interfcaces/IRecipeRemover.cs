using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipe.API.UseCases.Interfcaces
{
    public interface IRecipeRemover
    {
        Task Execute(int productId);
    }
}

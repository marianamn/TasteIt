namespace TatseIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TatseIt.Services.Data.Contracts;

    public class IngredientsService : IIngredientsService
    {
        private IDbRepository<Ingredient> ingredients;

        public IngredientsService(IDbRepository<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public IQueryable<Ingredient> GetAll()
        {
            var allIngredients = this.ingredients.All();

            return allIngredients;
        }

        public IQueryable<Ingredient> GetRandomIngredients(int count)
        {
            var randomIngredients = this.ingredients.All()
                                                    .OrderBy(x => Guid.NewGuid())
                                                    .Take(count);

            return randomIngredients;
        }
    }
}

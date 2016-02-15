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

    public class RecipesService : IRecipesService
    {
        private IDbRepository<Recipe> recipes;

        public RecipesService(IDbRepository<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public IQueryable<Recipe> GetAll()
        {
            var allRecipes = this.recipes.All();

            return allRecipes;
        }

        public IQueryable<Recipe> GetMostLikedRecipes(int count)
        {
            var mostLikedRecipes = this.recipes.All()
                                                .OrderByDescending(x => x.Likes.Count())
                                                .Take(count);

            return mostLikedRecipes;
        }
    }
}

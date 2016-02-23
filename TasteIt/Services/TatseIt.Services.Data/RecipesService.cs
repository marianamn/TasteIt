namespace TatseIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TasteIt.Services.Web.Contracts;
    using TatseIt.Services.Data.Contracts;

    public class RecipesService : IRecipesService
    {
        private IDbRepository<Recipe> recipes;
        private readonly IIdentifierProvider identifierProvider;

        public RecipesService(IDbRepository<Recipe> recipes, IIdentifierProvider identifierProvider)
        {
            this.recipes = recipes;
            this.identifierProvider = identifierProvider;
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

        public Recipe GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var recipe = this.recipes.GetById(intId);

            return recipe;
        }
        

        public IQueryable<Recipe> GetBySeason(string season)
        {
            var recipes = this.recipes.All()
                                    .Where(x => x.Season.ToString() == season);

            return recipes;
        }

        public IQueryable<Recipe> GetByOccasion(string occasion)
        {
            var recipes = this.recipes.All()
                                    .Where(x => x.Occasion.Name == occasion);

            return recipes;
        }

        public Recipe Create(string title, string cookingTime,string desctiption, string image)
        {
            var recipe = new Recipe()
            {
                Title = title,
                CookingTime = cookingTime,
                CreatedOn= DateTime.UtcNow,
                Description = desctiption,
                RecipeImage = image
            };

            return recipe;
        }

        public void Add(Recipe recipe)
        {
            this.recipes.Add(recipe);

            this.recipes.SaveChanges();

        }
    }
}

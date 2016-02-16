namespace TasteIt.Web.Controllers
{
    using Infrastructure.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TasteIt.Web.Models.Recipe;
    using TatseIt.Services.Data.Contracts;

    public class RecipeController : Controller
    {
        private readonly IRecipesService recipes;

        public RecipeController(IRecipesService recipes)
        {
            this.recipes = recipes;
        }

        // GET: Recipe
        public ActionResult Index()
        {
            var allRecipes = this.recipes
                                  .GetAll()
                                  .To<RecipeViewModel>()
                                  .ToList();

            return this.View(allRecipes);
        }
    }
}
namespace TasteIt.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using TasteIt.Web.Models.Recipe;
    using TatseIt.Services.Data.Contracts;

    public class RecipesController : BaseController
    {
        private readonly IRecipesService recipes;

        public RecipesController(IRecipesService recipes)
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

        [HttpGet]
        public ActionResult Details(string id)
        {
            var recipe = this.recipes.GetById(id);
            var viewModel = this.Mapper.Map<RecipeViewModel>(recipe);

            return this.View("Details", viewModel);
        }
    }
}
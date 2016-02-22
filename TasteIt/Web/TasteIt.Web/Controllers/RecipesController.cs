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
    using Data.Models;
    public class RecipesController : BaseController
    {
        private readonly IRecipesService recipes;
        private readonly IOccasionsService occasions;

        public RecipesController(IRecipesService recipes, IOccasionsService occasions)
        {
            this.recipes = recipes;
            this.occasions = occasions;
        }

        // GET: Recipe
        public ActionResult Index()
        {
            var occasions = this.occasions.GetAll()
                                        .To<OccasionViewModel>()
                                        .ToList();
            
            var recipes = this.recipes.GetAll()
                                  .To<RecipeViewModel>()
                                  .ToList();
            
            var viewModel = new RecipesIndexViewModel
            {
                Occasions = occasions,
                Recipes = recipes
            };
            
            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var recipe = this.recipes.GetById(id);
            var viewModel = this.Mapper.Map<RecipeViewModel>(recipe);

            return this.View("Details", viewModel);
        }

        [HttpGet]
        public ActionResult GetBySeason(string season)
        {
            var recipes = this.recipes.GetBySeason(season)
                                      .To<RecipeViewModel>()
                                      .ToList();

            var viewModel = new RecipesIndexViewModel
            {
                Recipes = recipes
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetByOccasion(string occasion)
        {
            var recipes = this.recipes.GetByOccasion(occasion)
                                      .To<RecipeViewModel>()
                                      .ToList();

            var viewModel = new RecipesIndexViewModel
            {
                Recipes = recipes
            };

            return this.View(viewModel);
        }
    }
}
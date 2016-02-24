namespace TasteIt.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using TasteIt.Web.Models.Recipe;
    using TatseIt.Services.Data.Contracts;

    public class RecipesController : BaseController
    {
        private readonly IRecipesService recipes;
        private readonly IOccasionsService occasions;
        private readonly ISanitizer sanitizer;

        public RecipesController(IRecipesService recipes, IOccasionsService occasions, ISanitizer sanitizer)
        {
            this.recipes = recipes;
            this.occasions = occasions;
            this.sanitizer = sanitizer;
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

            if (viewModel == null)
            {
                return this.Redirect("/");
            }

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

            if (viewModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult GetByOccasion(string occasion)
        {
            var recipes = this.recipes.GetByOccasion(occasion)
                                      .Where(x => x != null)
                                      .To<RecipeViewModel>()
                                      .ToList();

            var viewModel = new RecipesIndexViewModel
            {
                Recipes = recipes
            };

            if (viewModel == null)
            {
                return this.Redirect("/");
            }

            return this.View(viewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeInputModel recipe)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView(recipe);
            }

            var newRecipe = this.recipes.Create(
                this.sanitizer.Sanitize(recipe.Title),
                this.sanitizer.Sanitize(recipe.Description),
                this.sanitizer.Sanitize(recipe.CookingTime),
                this.sanitizer.Sanitize(recipe.RecipeImage));

            if (this.User.Identity.IsAuthenticated)
            {
                newRecipe.AuthorId = this.User.Identity.GetUserId();
            }
            
            newRecipe.CreatedOn = DateTime.UtcNow;

            this.recipes.Add(newRecipe);

            var resultRecipe = this.Mapper.Map<RecipeInputModel>(newRecipe);

            this.TempData["Notification"] = "Recipe was successfully added!";

            return this.PartialView(resultRecipe);
        }
    }
}
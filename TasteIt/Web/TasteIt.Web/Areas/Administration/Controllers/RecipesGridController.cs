namespace TasteIt.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Repositories;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TasteIt.Data.Models;

    public class RecipesGridController : Controller
    {
        private readonly IDbRepository<Recipe> recipes;

        public RecipesGridController(IDbRepository<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Recipes_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Recipe> recipes = this.recipes.All();
            DataSourceResult result = recipes.ToDataSourceResult(
                request, 
                recipe => new
                {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                CreatedOn = recipe.CreatedOn,
                CookingTime = recipe.CookingTime,
                Season = recipe.Season,
                RecipeImage = recipe.RecipeImage,
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Create([DataSourceRequest]DataSourceRequest request, Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var entity = new Recipe
                {
                    Title = recipe.Title,
                    Description = recipe.Description,
                    CreatedOn = recipe.CreatedOn,
                    CookingTime = recipe.CookingTime,
                    Season = recipe.Season,
                    RecipeImage = recipe.RecipeImage,
                };

                this.recipes.Add(entity);
                this.recipes.SaveChanges();
                recipe.Id = entity.Id;
            }

            return this.Json(new[] { recipe }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Update([DataSourceRequest]DataSourceRequest request, Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var entity = new Recipe
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    Description = recipe.Description,
                    CreatedOn = recipe.CreatedOn,
                    CookingTime = recipe.CookingTime,
                    Season = recipe.Season,
                    RecipeImage = recipe.RecipeImage,
                };

                this.recipes.Update(entity);
                this.recipes.SaveChanges();
            }

            return this.Json(new[] { recipe }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Recipes_Destroy([DataSourceRequest]DataSourceRequest request, Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var entity = new Recipe
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    Description = recipe.Description,
                    CreatedOn = recipe.CreatedOn,
                    CookingTime = recipe.CookingTime,
                    Season = recipe.Season,
                    RecipeImage = recipe.RecipeImage,
                };

                this.recipes.Delete(entity);
                this.recipes.SaveChanges();
            }

            return this.Json(new[] { recipe }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.recipes.Dispose();
            base.Dispose(disposing);
        }
    }
}

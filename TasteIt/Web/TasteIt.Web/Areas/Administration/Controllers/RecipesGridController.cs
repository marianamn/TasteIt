namespace TasteIt.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TasteIt.Data.Models;
    using Data.Repositories;

    public class RecipesGridController : Controller
    {
        private readonly IDbRepository<Recipe> recipes;

        public RecipesGridController(IDbRepository<Recipe> recipes)
        {
            this.recipes = recipes;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Recipes_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Recipe> recipes = this.recipes.All();
            DataSourceResult result = recipes.ToDataSourceResult(request, recipe => new {
                Id = recipe.Id,
                Title = recipe.Title,
                Description = recipe.Description,
                CreatedOn = recipe.CreatedOn,
                CookingTime = recipe.CookingTime,
                Season = recipe.Season,
                RecipeImage = recipe.RecipeImage,
            });

            return Json(result);
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

            return Json(new[] { recipe }.ToDataSourceResult(request, ModelState));
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

            return Json(new[] { recipe }.ToDataSourceResult(request, ModelState));
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

            return Json(new[] { recipe }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.recipes.Dispose();
            base.Dispose(disposing);
        }
    }
}

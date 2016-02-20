namespace TasteIt.Web.Controllers
{
    using Models.Ingredient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TatseIt.Services.Data.Contracts;

    public class IngredientsController : BaseController
    {
        private readonly IIngredientsService ingredients;

        public IngredientsController(IIngredientsService ingredients)
        {
            this.ingredients = ingredients;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var ingredient = this.ingredients.GetById(id);
            var viewModel = this.Mapper.Map<IngredientViewModel>(ingredient);

            return this.View("Details", viewModel);
        }
    }
}
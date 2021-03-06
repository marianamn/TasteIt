﻿namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Models.Ingredient;
    using TatseIt.Services.Data.Contracts;
    using Infrastructure;

    public class IngredientsController : BaseController
    {
        private readonly IIngredientsService ingredients;
        private readonly ISanitizer sanitizer;

        public IngredientsController(IIngredientsService ingredients, ISanitizer sanitizer)
        {
            this.ingredients = ingredients;
            this.sanitizer = sanitizer;
        }

        public ActionResult Index(string selectedLetter)
        {
            var model = new AlphabeticalPagingViewModel { SelectedLetter = selectedLetter };

            model.FirstLetters = this.ingredients.GetFirstLetters();

            if (string.IsNullOrEmpty(selectedLetter) || selectedLetter == "All")
            {
                model.Ingredients = this.ingredients.GetAll()
                                           .OrderBy(p => p.Name)
                                           .To<IngredientViewModel>()
                                           .ToList();

                return this.View(model);
            }
            else
            {
                model.Ingredients = this.ingredients.GetIngredientsWithCommonLetter(selectedLetter.ToLower())
                                         .To<IngredientViewModel>()
                                         .ToList();
            }

            return this.View(model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var ingredient = this.ingredients.GetById(id);
            var viewModel = this.Mapper.Map<IngredientViewModel>(ingredient);

            return this.View("Details", viewModel);
        }

        [HttpGet]
        public ActionResult ShowList(string firstLetter)
        {
            var ingredients = this.ingredients.GetIngredientsWithCommonLetter(firstLetter.ToLower())
                                             .To<IngredientViewModel>()
                                             .ToList();

            return this.View("ShowList", ingredients);
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientViewModel ingredient)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView(ingredient);
            }

            var newIngredient = this.ingredients.Create(
                this.sanitizer.Sanitize(ingredient.Name), 
                this.sanitizer.Sanitize(ingredient.IngredientDetails), 
                this.sanitizer.Sanitize(ingredient.IngredientImage));

            var resultIngredient = this.Mapper.Map<IngredientViewModel>(newIngredient);

            this.TempData["Notification"] = "Ingredient was successfully created!";

            return this.PartialView(resultIngredient);
        }
    }
}
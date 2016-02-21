namespace TasteIt.Web.Controllers
{
    using Models.Ingredient;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TatseIt.Services.Data.Contracts;
    using Infrastructure.Mapping;
    using Data.Repositories;
    using Data.Models;
    using Data;

    public class IngredientsController : BaseController
    {
        private readonly IIngredientsService ingredients;

        public IngredientsController(IIngredientsService ingredients)
        {
            this.ingredients = ingredients;
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
    }
}
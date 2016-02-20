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

            model.FirstLetters = this.ingredients.GetAll()
                                                 .GroupBy(p => p.Name.Substring(0, 1))
                                                 .Select(x => x.Key.ToUpper())
                                                 .ToList();

            if (string.IsNullOrEmpty(selectedLetter) || selectedLetter == "All")
            {
                model.IngredientNames = this.ingredients.GetAll()
                                             .Select(p => p.Name)
                                             .ToList();

                model.Id = this.ingredients.GetAll()
                                             .Select(p => p.Id)
                                             .ToList();
            }
            else
            {
                model.IngredientNames = this.ingredients.GetAll()
                                            .Where(p => p.Name.StartsWith(selectedLetter))
                                            .Select(p => p.Name)
                                            .ToList();

                model.Id = this.ingredients.GetAll()
                                             .Where(p => p.Name.StartsWith(selectedLetter))
                                             .Select(p => p.Id)
                                             .ToList();
            }

            return View(model);
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
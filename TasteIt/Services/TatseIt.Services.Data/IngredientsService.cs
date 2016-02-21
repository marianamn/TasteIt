﻿namespace TatseIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TatseIt.Services.Data.Contracts;
    using TasteIt.Services.Web.Contracts;

    public class IngredientsService : IIngredientsService
    {
        private IDbRepository<Ingredient> ingredients;
        private readonly IIdentifierProvider identifierProvider;

        public IngredientsService(IDbRepository<Ingredient> ingredients, IIdentifierProvider identifierProvider)
        {
            this.ingredients = ingredients;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Ingredient> GetAll()
        {
            var allIngredients = this.ingredients.All();

            return allIngredients;
        }

        public IQueryable<Ingredient> GetRandomIngredients(int count)
        {
            var randomIngredients = this.ingredients.All()
                                                    .OrderBy(x => Guid.NewGuid())
                                                    .Take(count);

            return randomIngredients;
        }

        public Ingredient GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var ingredient = this.ingredients.GetById(intId);

            return ingredient;
        }

        public IQueryable<Ingredient> GetIngredientsWithCommonLetter(string letter)
        {
            var igredientsWithCommonLetter = this.ingredients.All()
                                                 .Where(p => p.Name.StartsWith(letter.ToLower()))
                                                 .OrderBy(p => p.Name);

            return igredientsWithCommonLetter;
        }

        public List<string> GetFirstLetters()
        {
            var letters = this.ingredients.All()
                                          .GroupBy(p => p.Name.Substring(0, 1))
                                          .Select(x => x.Key.ToUpper())
                                          .ToList();

            return letters;
        }

        public Ingredient Create(string name, string description, string IngredientImage)
        {
            var ingredient = new Ingredient()
            {
                Name = name,
                IngredientDetails = description,
                IngredientImage = IngredientImage
            };

            this.ingredients.Add(ingredient);

            this.ingredients.SaveChanges();

            return ingredient;
        }
    }
}

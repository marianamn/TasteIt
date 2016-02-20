using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteIt.Web.Models.Ingredient
{
    public class IndexIngredientsViewModel
    {
        public AlphabeticalPagingViewModel Letters { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
    }
}
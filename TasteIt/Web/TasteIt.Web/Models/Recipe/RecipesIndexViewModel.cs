using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteIt.Web.Models.Recipe
{
    public class RecipesIndexViewModel
    {
        public IEnumerable<OccasionViewModel> Occasions { get; set; }

        public IEnumerable<RecipeViewModel> Recipes { get; set; }
    }
}
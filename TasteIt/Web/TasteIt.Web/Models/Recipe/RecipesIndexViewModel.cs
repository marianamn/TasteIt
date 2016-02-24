namespace TasteIt.Web.Models.Recipe
{
    using System.Collections.Generic;

    public class RecipesIndexViewModel
    {
        public IEnumerable<OccasionViewModel> Occasions { get; set; }

        public IEnumerable<RecipeViewModel> Recipes { get; set; }
    }
}
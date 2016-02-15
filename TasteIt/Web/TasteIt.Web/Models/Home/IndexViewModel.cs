namespace TasteIt.Web.Models.Home
{
    using System.Collections.Generic;
    using Article;
    using Ingredients;
    using Recipe;

    public class IndexViewModel
    {
        public IEnumerable<IngredientsViewModel> Ingredients { get; set; }

        public IEnumerable<RecipeViewModel> Recipes { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
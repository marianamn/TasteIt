namespace TasteIt.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using TasteIt.Web.Models.Article;
    using TasteIt.Web.Models.Recipe;

    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public string ImageURL { get; set; }
        
        public IEnumerable<ArticleViewModel> MyArticles { get; set; }
        
        public IEnumerable<CommentViewModel> MyComments { get; set; }
        
        public IEnumerable<RecipeViewModel> MyRecipes { get; set; }
    }
}
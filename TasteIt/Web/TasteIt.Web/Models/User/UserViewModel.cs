﻿namespace TasteIt.Web.Models.User
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Comment;
    using Infrastructure.Mapping;
    using TasteIt.Web.Models.Article;
    using TasteIt.Web.Models.Recipe;

    public class UserViewModel : IMapFrom<Data.Models.User>
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
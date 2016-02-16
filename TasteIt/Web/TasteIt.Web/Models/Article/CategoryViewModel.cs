namespace TasteIt.Web.Models.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        public string CategoryImage { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
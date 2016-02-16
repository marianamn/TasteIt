namespace TasteIt.Web.Models.Article
{
    using System.Collections.Generic;

    public class DetailsViewModel
    {
        public ArticleViewModel Article { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasteIt.Web.Models.Article
{
    public class ArticleListViewModel
    {
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<ArticleViewModel> Articles { get; set; }
    }
}
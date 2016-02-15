namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Models.Article;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;

    public class ArticlesController : Controller
    {
        private IDbRepository<Article> articles;

        public ArticlesController(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            var newestArticles = this.articles
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(10)
                .To<ArticleViewModel>()
                .ToList();

            return this.View(newestArticles);
        }
    }
}
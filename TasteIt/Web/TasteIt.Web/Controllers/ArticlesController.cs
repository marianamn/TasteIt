namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Models.Article;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TatseIt.Services.Data.Contracts;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articles;

        public ArticlesController(IArticlesService articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            var allArticles = this.articles
                                     .GetAll()
                                     .To<ArticleViewModel>()
                                     .ToList();

            return this.View(allArticles);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var article = this.articles.GetById(id);
            var viewModel = this.Mapper.Map<ArticleViewModel>(article);

            return this.View("Details", viewModel);
        }

        [HttpGet]
        public ActionResult RelatedArticles(string id)
        {
            var relatedArticles = this.articles.GetRelatedArticles(id)
                                                .To<ArticleViewModel>()
                                                .ToList();

            if (relatedArticles == null)
            {
                return this.RedirectToAction("NoArticlesFound");
            }

            return this.View("RelatedArticles", relatedArticles);
        }
    }
}
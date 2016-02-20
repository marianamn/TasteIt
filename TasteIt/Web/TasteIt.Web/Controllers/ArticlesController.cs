namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Models.Article;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TatseIt.Services.Data.Contracts;
    using System;
    using Common;

    public class ArticlesController : BaseController
    {
        const int ItemsPerPage = GlobalConstants.itemsPerPage;

        private readonly IArticlesService articles;

        public ArticlesController(IArticlesService articles)
        {
            this.articles = articles;
        }

        public ActionResult Index(int id = 1)
        {
            var page = id;
            var allItemsCount = this.articles.Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;
            var allArticles =this.articles
                                 .GetAll()
                                 .OrderByDescending(x =>x.CreatedOn)
                                 .Skip(itemsToSkip)
                                 .Take(ItemsPerPage)
                                 .To<ArticleViewModel>()
                                 .ToList();

            var viewModel = new ArticleListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Articles = allArticles
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var article = this.articles.GetById(id);
            var viewModel = this.Mapper.Map<ArticleViewModel>(article);

            return this.View("Details", viewModel);
        }

        [HttpGet]
        public ActionResult RelatedArticles(string id, int page = 1)
        {
            var relatedArticles = this.articles.GetRelatedArticles(id);
            var allItemsCount = relatedArticles.Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var result = relatedArticles.OrderByDescending(x => x.CreatedOn)
                            .Skip(itemsToSkip)
                            .Take(ItemsPerPage)
                            .To<ArticleViewModel>()
                            .ToList();

            if (result == null)
            {
                return this.RedirectToAction("NoArticlesFound");
            }

            var viewModel = new ArticleListViewModel()
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Articles = result
            };

            return this.View("RelatedArticles", viewModel);
        }
    }
}
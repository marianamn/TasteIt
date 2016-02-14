namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Models.Article;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using Infrastructure.Mapping;
    using AutoMapper.QueryableExtensions;
    using AutoMapper;

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
                //.To<ArticleViewModel>()
                .ProjectTo<ArticleViewModel>()
                //.Select(x => new ArticleViewModel()
                //{
                //    Title = x.Title,
                //    CreatedOn = x.CreatedOn,
                //    ArticleImage = x.ArticleImage,
                //    Category = x.Category.Name,
                //    Author = x.Author.FirstName +" "+ x.Author.LastName
                //})
                .ToList();

            return View(newestArticles);
        }
    }
}
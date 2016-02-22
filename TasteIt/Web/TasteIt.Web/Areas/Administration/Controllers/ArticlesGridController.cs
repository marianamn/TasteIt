namespace TasteIt.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Repositories;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TasteIt.Data.Models;
    using Microsoft.AspNet.Identity;
    public class ArticlesGridController : Controller
    {
        private readonly IDbRepository<Article> articles;

        public ArticlesGridController(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Articles_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.articles.All()
            .ToDataSourceResult(request, article => new  {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CreatedOn = article.CreatedOn,
                ArticleImage = article.ArticleImage,
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Create([DataSourceRequest]DataSourceRequest request, Article article)
        {
            if (ModelState.IsValid)
            {
                var entity = new Article
                {
                    Title = article.Title,
                    Content = article.Content,
                    CreatedOn = article.CreatedOn,
                    ArticleImage = article.ArticleImage,
                };

                this.articles.Add(entity);
                this.articles.SaveChanges();
                article.Id = entity.Id;
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Update([DataSourceRequest]DataSourceRequest request, Article article)
        {
            if (ModelState.IsValid)
            {
                var entity = new Article
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    CreatedOn = article.CreatedOn,
                    ArticleImage = article.ArticleImage,
                };

                this.articles.Update(entity);
                this.articles.SaveChanges();
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Destroy([DataSourceRequest]DataSourceRequest request, Article article)
        {
            if (ModelState.IsValid)
            {
                var entity = new Article
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                    CreatedOn = article.CreatedOn,
                    ArticleImage = article.ArticleImage,
                };

                this.articles.Delete(article.Id);
                this.articles.SaveChanges();
            }

            return Json(new[] { article }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.articles.Dispose();
            base.Dispose(disposing);
        }
    }
}

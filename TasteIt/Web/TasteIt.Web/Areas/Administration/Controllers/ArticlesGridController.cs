namespace TasteIt.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Repositories;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TasteIt.Data.Models;

    public class ArticlesGridController : Controller
    {
        private readonly IDbRepository<Article> articles;

        public ArticlesGridController(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Articles_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.articles.All()
            .ToDataSourceResult(
                request, 
                article => new
                {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CreatedOn = article.CreatedOn,
                ArticleImage = article.ArticleImage,
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Create([DataSourceRequest]DataSourceRequest request, Article article)
        {
            var newId = 0;
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
                newId = entity.Id;
            }

            var articleToDisplay = this.articles.All().FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { articleToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Update([DataSourceRequest]DataSourceRequest request, Article article)
        {
            if (ModelState.IsValid)
            {
                var entity = this.articles.GetById(article.Id);
                entity.Title = article.Title;
                entity.Content = article.Content;
                entity.CreatedOn = article.CreatedOn;
                entity.ArticleImage = article.ArticleImage;

                this.articles.SaveChanges();
            }

            var articleToDisplay = this.articles.All().FirstOrDefault(x => x.Id == article.Id);

            return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Destroy([DataSourceRequest]DataSourceRequest request, Article article)
        {
            if (ModelState.IsValid)
            {
                this.articles.Delete(article.Id);
                this.articles.SaveChanges();
            }

            return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.articles.Dispose();
            base.Dispose(disposing);
        }
    }
}

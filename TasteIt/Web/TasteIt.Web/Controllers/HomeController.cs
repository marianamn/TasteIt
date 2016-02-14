namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Data.Repositories;
    using Data.Models;

    public class HomeController : Controller
    {
        private IDbRepository<Article> articles;

        public HomeController(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.ViewData.Add("Username", this.User.Identity);
            }

            var newestArticles = this.articles.All().OrderBy(x => x.CreatedOn).Take(3);
            return this.View(newestArticles);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}
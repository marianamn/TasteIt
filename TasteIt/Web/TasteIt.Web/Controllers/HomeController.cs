namespace TasteIt.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Repositories;
    using Data.Models;
    using Models.Article;

    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                this.ViewData.Add("Username", this.User.Identity);
            }

            return this.View();
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
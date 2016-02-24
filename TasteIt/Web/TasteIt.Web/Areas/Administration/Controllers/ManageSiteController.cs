namespace TasteIt.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    public class ManageSiteController : Controller
    {
        // GET: Administration/ManageSite
        public ActionResult Index()
        {
            return this.View("ManageSite");
        }
    }
}
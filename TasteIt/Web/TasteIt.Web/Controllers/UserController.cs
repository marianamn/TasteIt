namespace TasteIt.Web.Controllers
{
    using System.Web.Mvc;

    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
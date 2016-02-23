namespace TasteIt.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using TasteIt.Data.Models;
    using Data.Repositories;

    public class CommentsGridController : Controller
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsGridController(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comments_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Comment> comments = this.comments.All();
            DataSourceResult result = comments.ToDataSourceResult(request, comment => new {
                Id = comment.Id,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Create([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Content = comment.Content,
                    CreatedOn = comment.CreatedOn,
                };

                this.comments.Add(entity);
                this.comments.SaveChanges();
                comment.Id = entity.Id;
            }

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Update([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedOn = comment.CreatedOn,
                };

                this.comments.Update(entity);
                this.comments.SaveChanges();
            }

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Comments_Destroy([DataSourceRequest]DataSourceRequest request, Comment comment)
        {
            if (ModelState.IsValid)
            {
                var entity = new Comment
                {
                    Id = comment.Id,
                    Content = comment.Content,
                    CreatedOn = comment.CreatedOn,
                };

                this.comments.Delete(entity);
                this.comments.SaveChanges();
            }

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.comments.Dispose();
            base.Dispose(disposing);
        }
    }
}

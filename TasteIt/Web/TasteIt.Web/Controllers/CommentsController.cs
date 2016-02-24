namespace TasteIt.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using Infrastructure;
    using Microsoft.AspNet.Identity;
    using Models.Comment;
    using Services.Web.Contracts;
    using TatseIt.Services.Data.Contracts;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService comments;
        private readonly IRecipesService recipes;
        private readonly ISanitizer sanitizer;
        private readonly IIdentifierProvider identifierProvider;

        public CommentsController(ICommentsService comments, IRecipesService recipes, IIdentifierProvider identifierProvider, ISanitizer sanitizer)
        {
            this.comments = comments;
            this.recipes = recipes;
            this.sanitizer = sanitizer;
            this.identifierProvider = identifierProvider;
        }

        public ActionResult Index()
        {
            // var recipe = this.recipes.GetById(id);
            // var recipeComments = this.comments.GetAll()
            //                                   .Where(x => x.RecipeId == recipe.Id)
            //                                   .To<CommentViewModel>()
            //                                   .OrderByDescending(x => x.CreatedOn);
            // 
            // return PartialView(recipeComments);
            return this.View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return this.PartialView();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentInputModel comment)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView(comment);
            }

            var newComment = this.comments.Create(this.sanitizer.Sanitize(comment.Content));

            if (this.User.Identity.IsAuthenticated)
            {
                newComment.PostedById = this.User.Identity.GetUserId();
            }

           newComment.CreatedOn = DateTime.UtcNow;

           // string id = this.Url.RequestContext.RouteData.Values["Id"].ToString();
           // var recipe = this.recipes.GetById(id);
           // newComment.RecipeId = recipe.Id;
            this.comments.Add(newComment);

            var resultComment = this.Mapper.Map<CommentInputModel>(newComment);

            return this.PartialView(resultComment);
        }
    }
}
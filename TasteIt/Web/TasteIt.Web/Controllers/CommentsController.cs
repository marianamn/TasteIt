﻿namespace TasteIt.Web.Controllers
{
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models.Comment;
    using Models.Recipe;
    using Services.Web.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using TatseIt.Services.Data.Contracts;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService comments;
        private readonly IRecipesService recipes;

        public CommentsController(ICommentsService comments, IRecipesService recipes)
        {
            this.comments = comments;
            this.recipes = recipes;
        }

        public ActionResult Index()
        {
            //var recipe = this.recipes.GetById(id);
            //var recipeComments = this.comments.GetAll()
            //                                  .Where(x => x.RecipeId == recipe.Id)
            //                                  .To<CommentViewModel>()
            //                                  .OrderByDescending(x => x.CreatedOn);
            //
            //return PartialView(recipeComments);

            return View();
        }

        [Authorize]
        public ActionResult Create()
        {
            return PartialView();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentInputModel comment, string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.PartialView(comment);
            }

            var recipe = this.recipes.GetById(id);
            comment.AuthorId = this.User.Identity.GetUserId();

            var newComment = this.comments.Create(comment.Content, comment.AuthorId, recipe.Id, DateTime.Now);
            var resultComment = this.Mapper.Map<CommentInputModel>(newComment);

            return this.PartialView(resultComment);
        }
    }
}
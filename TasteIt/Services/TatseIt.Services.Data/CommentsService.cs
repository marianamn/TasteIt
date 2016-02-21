namespace TatseIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TasteIt.Services.Web.Contracts;
    using TatseIt.Services.Data.Contracts;

    public class CommentsService : ICommentsService
    {
        private IDbRepository<Comment> comments;
        private IDbRepository<Recipe> recipes;
        private readonly IIdentifierProvider identifierProvider;

        public CommentsService(IDbRepository<Comment> comments, IDbRepository<Recipe> recipes, IIdentifierProvider identifierProvider)
        {
            this.comments = comments;
            this.recipes = recipes;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Comment> GetAll()
        {
            var allComments = this.comments.All();

            return allComments;
        }

        public Comment GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var comment = this.comments.GetById(intId);

            return comment;
        }

        public Comment Create(string content, string postedById, int RecipeId, DateTime createdOn)
        {
            //var intRecipeId = this.identifierProvider.DecodeId(RecipeId);

            var comment = new Comment()
            {
                Content = content,
                PostedById = postedById,
                RecipeId = RecipeId,
                CreatedOn = createdOn
            };

            this.comments.Add(comment);

            this.comments.SaveChanges();

            return comment;
        }
    }
}

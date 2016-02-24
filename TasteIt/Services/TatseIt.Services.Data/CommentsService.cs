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
        private readonly IIdentifierProvider identifierProvider;
        private IDbRepository<Comment> comments;
        private IDbRepository<Recipe> recipes;

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

        public Comment Create(string content)
        {
            var comment = new Comment()
            {
                Content = content
            };

            return comment;
        }

        public void Add(Comment comment)
        {
            this.comments.Add(comment);

            this.comments.SaveChanges();
        }
    }
}

namespace TatseIt.Services.Data.Contracts
{
    using System;
    using System.Linq;
    using TasteIt.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();

        Comment GetById(string id);

        Comment Create(string content, string postedById, int RecipeId, DateTime createdOn);
    }
}

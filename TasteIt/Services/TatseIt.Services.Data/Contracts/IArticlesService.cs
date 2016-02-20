namespace TatseIt.Services.Data.Contracts
{
    using System.Linq;
    using TasteIt.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetAll();

        IQueryable<Article> GetNewestArticles(int count);

        Article GetById(string id);

        int Count();

        IQueryable<Article> GetRelatedArticles(string id);

        IQueryable<Article> GetRandomArticles(int count);
    }
}

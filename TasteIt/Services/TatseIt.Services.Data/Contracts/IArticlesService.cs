namespace TatseIt.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetAll();

        IQueryable<Article> GetNewestArticles(int count);

        Article GetById(string id);
    }
}

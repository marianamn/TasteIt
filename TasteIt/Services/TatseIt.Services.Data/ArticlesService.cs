namespace TatseIt.Services.Data
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;

    public class ArticlesService : IArticlesService
    {
        private IDbRepository<Article> articles;

        public ArticlesService(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> GetAll()
        {
            var allArticles = this.articles.All();

            return allArticles;
        }

        public IQueryable<Article> GetNewestArticles(int count)
        {
            var newestArticles = this.articles
                                .All()
                                .OrderByDescending(x => x.CreatedOn)
                                .Take(count);

            return newestArticles;
        }
    }
}

namespace TatseIt.Services.Data
{
    using System;
    using System.Linq;
    using Contracts;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TasteIt.Services.Web.Contracts;

    public class ArticlesService : IArticlesService
    {
        private readonly IIdentifierProvider identifierProvider;
        private IDbRepository<Article> articles;

        public ArticlesService(IDbRepository<Article> articles, IIdentifierProvider identifierProvider)
        {
            this.articles = articles;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Article> GetAll()
        {
            var allArticles = this.articles
                                 .All()
                                 .OrderByDescending(x => x.CreatedOn);

            return allArticles;
        }

        public int Count()
        {
            var count = this.articles.All().Count();

            return count;
        }

        public IQueryable<Article> GetNewestArticles(int count)
        {
            var newestArticles = this.articles
                                .All()
                                .OrderByDescending(x => x.CreatedOn)
                                .Take(count);

            return newestArticles;
        }

        public Article GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var article = this.articles.GetById(intId);

            return article;
        }

        public IQueryable<Article> GetRandomArticles(int count)
        {
            var randomArticles = this.articles.All()
                                                .OrderBy(x => Guid.NewGuid())
                                                .Take(count);

            return randomArticles;
        }

        public IQueryable<Article> GetRelatedArticles(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
 
            var currentArticle = this.articles.GetById(intId);
            var currentArticleCaregory = currentArticle.Category.Name;

            var relatedArticles = this.articles
                                      .All()
                                      .Where(x => x.Category.Name == currentArticleCaregory);

            return relatedArticles;
        }
    }
}

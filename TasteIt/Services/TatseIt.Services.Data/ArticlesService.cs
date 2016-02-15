﻿namespace TatseIt.Services.Data
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TasteIt.Services.Web.Contracts;

    public class ArticlesService : IArticlesService
    {
        private IDbRepository<Article> articles;
        private readonly IIdentifierProvider identifierProvider;

        public ArticlesService(IDbRepository<Article> articles, IIdentifierProvider identifierProvider)
        {
            this.articles = articles;
            this.identifierProvider = identifierProvider;
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

        public Article GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var article = this.articles.GetById(intId);

            return article;
        }
    }
}

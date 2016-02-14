namespace TasteIt.Web.Models.Article
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;
    using AutoMapper;

    public class ArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ArticleImage { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            //configuration.CreateMap<Article, ArticleViewModel>(null)
            //   .ForMember(x => x.AuthorId, opts => opts.MapFrom(u => (u.AuthorId)));
            //
            configuration.CreateMap<Article, ArticleViewModel>(null)
               .ForMember(x => x.Author, opts => opts.MapFrom(x => (x.Author.FirstName + " " + x.Author.LastName)));
            //
            //configuration.CreateMap<Article, ArticleViewModel>(null)
            //   .ForMember(x => x.CategoryId, opts => opts.MapFrom(u => (u.CategoryId)));
        
            configuration.CreateMap<Article, ArticleViewModel>(null)
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
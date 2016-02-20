namespace TasteIt.Web.Models.Article
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Web;
    using Services.Web.Contracts;
    using TasteIt.Data.Models;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
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

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            {
                configuration.CreateMap<Article, ArticleViewModel>()
                    .ForMember(x => x.Author, opt => opt.MapFrom(x => (x.Author.FirstName + " " + x.Author.LastName)));

                configuration.CreateMap<Article, ArticleViewModel>()
                    .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
            }
        }
    }
}
namespace TasteIt.Web.Areas.Administration.Models.ArticlesGridModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using TasteIt.Data.Models;
    using TasteIt.Web.Infrastructure.Mapping;

    public class ArticlesGridModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ArticleImage { get; set; }

        public string AuthorEmail { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticlesGridModel>()
              .ForMember(x => x.AuthorEmail, opt => opt.MapFrom(x => x.Author.Email));
        }
    }
}
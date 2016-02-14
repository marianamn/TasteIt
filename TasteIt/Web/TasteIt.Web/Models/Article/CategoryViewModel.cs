namespace TasteIt.Web.Models.Article
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public IEnumerable<string> Articles { get; set; }
        //
        //public void CreateMappings(IMapperConfiguration configuration)
        //{
        //    configuration.CreateMap<Articles, ArticleViewModel>(null)
        //        .ForMember(spm => spm.Title, opts => opts.MapFrom(u => u..Select(t => t.Name).ToList()));
        //}
    }
}
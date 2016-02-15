namespace TasteIt.Web.Models.Recipe
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;

    public class LikeViewModel : IMapFrom<Like>, IHaveCustomMappings
    {
       public int Id { get; set; }
       
       public bool Value { get; set; }

       public string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Like, LikeViewModel>()
                   .ForMember(x => x.Author, opt => opt.MapFrom(x => (x.Author.FirstName + " " + x.Author.LastName)));
        }
    }
}
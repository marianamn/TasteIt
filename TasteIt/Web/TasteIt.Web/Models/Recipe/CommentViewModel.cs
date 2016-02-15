namespace TasteIt.Web.Models.Recipe
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Content { get; set; }
        
        public string PostedById { get; set; }

        public string PostedBy { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                   .ForMember(x => x.PostedBy, opt => opt.MapFrom(x => (x.PostedBy.FirstName + " " + x.PostedBy.LastName)));
        }
    }
}
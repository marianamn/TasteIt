namespace TasteIt.Web.Models.Comment
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;
    using System;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Content { get; set; }

        [Required]
        public string PostedById { get; set; }

        public string PostedBy { get; set; }

        public string PostedByImage { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                   .ForMember(x => x.PostedBy, opt => opt.MapFrom(x => (x.PostedBy.FirstName + " " + x.PostedBy.LastName)));

            configuration.CreateMap<Comment, CommentViewModel>()
                   .ForMember(x => x.PostedByImage, opt => opt.MapFrom(x => x.PostedBy.ImageURL));
        }
    }
}
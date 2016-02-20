namespace TasteIt.Web.Models.Recipe
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using Services.Web;
    using Services.Web.Contracts;
    using TasteIt.Data.Models;
    using Ingredient;

    public class RecipeViewModel : IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CookingTime { get; set; }

        public Season Season { get; set; }

        public string RecipeImage { get; set; }

        public string Author { get; set; }

        public string Occasion { get; set; }

        public string CountLikes { get; set; }

        public string CountComments { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }

        public IEnumerable<LikeViewModel> Likes { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

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
            configuration.CreateMap<Recipe, RecipeViewModel>()
                   .ForMember(x => x.Author, opt => opt.MapFrom(x => (x.Author.FirstName + " " + x.Author.LastName)));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                   .ForMember(x => x.Occasion, opt => opt.MapFrom(x => x.Occasion.Name));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                  .ForMember(x => x.CountLikes, opt => opt.MapFrom(x => x.Likes.Count()));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                 .ForMember(x => x.CountComments, opt => opt.MapFrom(x => x.Comments.Count()));
        }
    }
}
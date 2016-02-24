namespace TasteIt.Web.Models.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Comment;
    using Infrastructure.Mapping;
    using Ingredient;
    using Services.Web;
    using Services.Web.Contracts;
    using TasteIt.Data.Models;

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

        public string AuthorId { get; set; }

        public string Author { get; set; }

        public string Occasion { get; set; }

        public string CountLikes { get; set; }

        public string CountComments { get; set; }

        public IEnumerable<IngredientViewModel> Ingredients { get; set; }

        public IEnumerable<Like> Likes { get; set; }

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
                  .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.AuthorId));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                   .ForMember(x => x.Author, opt => opt.MapFrom(x => (x.Author.FirstName + " " + x.Author.LastName)));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                   .ForMember(x => x.Occasion, opt => opt.MapFrom(x => x.Occasion.Name));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                  .ForMember(x => x.CountLikes, opt => opt.MapFrom(x => x.Likes.Any() ? x.Likes.Sum(v => (int)v.Value) : 0));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                 .ForMember(x => x.CountComments, opt => opt.MapFrom(x => (x.Comments.Count() - 1)));
        }
    }
}
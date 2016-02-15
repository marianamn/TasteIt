namespace TasteIt.Web.Models.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
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

        public string Author { get; set; }

        public string Occasion { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<Like> Likes { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Recipe, RecipeViewModel>()
                   .ForMember(x => x.Author, opt => opt.MapFrom(x => (x.Author.FirstName + " " + x.Author.LastName)));

            configuration.CreateMap<Recipe, RecipeViewModel>()
                   .ForMember(x => x.Occasion, opt => opt.MapFrom(x => x.Occasion.Name));
        }
    }
}
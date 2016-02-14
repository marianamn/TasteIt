namespace TasteIt.Web.Models.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;
    using Ingredients;

    public class RecipeViewModel : IMapFrom<Recipe>
    {
        //public int Id { get; set; }
        //
        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        //public string Title { get; set; }
        //
        //[Required]
        //public string Description { get; set; }
        //
        //public DateTime CreatedOn { get; set; }
        //
        //public string CookingTime { get; set; }
        //
        //public SeasonViewModel Season { get; set; }
        //
        //public string RecipeImage { get; set; }
        //
        //[Required]
        //public string AuthorId { get; set; }
        //
        //[ForeignKey("AuthorId")]
        //public virtual UserViewModel Author { get; set; }
        //
        //[Required]
        //public int OccasionId { get; set; }
        //
        //[ForeignKey("OccasionId")]
        //public virtual OccasionViewModel Occasion { get; set; }
        //
        //public virtual ICollection<IngredientsViewModel> Ingredients { get; set; }
        //
        //public virtual ICollection<LikeViewModel> Likes { get; set; }
        //
        //public virtual ICollection<CommentViewModel> Comments { get; set; }
    }
}
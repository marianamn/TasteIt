namespace TasteIt.Web.Models.Recipe
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class RecipeInputModel
    {
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CookingTime { get; set; }

        public string RecipeImage { get; set; }

        public string AuthorId { get; set; }

        public string Occasion { get; set; }
    }
}
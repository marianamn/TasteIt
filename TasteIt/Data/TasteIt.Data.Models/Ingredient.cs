namespace TasteIt.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Quantity { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string IngredientDetails { get; set; }

        public string IngredientImage { get; set; }

        [Required]
        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}

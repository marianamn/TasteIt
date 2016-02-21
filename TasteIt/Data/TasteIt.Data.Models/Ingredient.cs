namespace TasteIt.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ingredient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Quantity { get; set; }

        [Required]
        public string IngredientDetails { get; set; }

        public string IngredientImage { get; set; }
    }
}

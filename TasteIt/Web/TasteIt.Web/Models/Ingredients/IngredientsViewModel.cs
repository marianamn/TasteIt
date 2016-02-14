namespace TasteIt.Web.Models.Ingredients
{
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using Data.Models;

    public class IngredientsViewModel : IMapFrom<Ingredient>
    {
        //public int Id { get; set; }
        //
        //[Required]
        //public string Name { get; set; }
        //
        //[Required]
        //public string Quantity { get; set; }
        //
        //[Required]
        //public string IngredientDetails { get; set; }
        //
        //public string IngredientImage { get; set; }
    }
}
namespace TasteIt.Web.Models.Ingredient
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web.Contracts;
    using Services.Web;
    using System.Collections.Generic;
    using System.Linq;

    public class IngredientViewModel : IMapFrom<Ingredient>
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Quantity { get; set; }
        
        [Required]
        public string IngredientDetails { get; set; }
        
        public string IngredientImage { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/{identifier.EncodeId(this.Id)}";
            }
        }
    }
}
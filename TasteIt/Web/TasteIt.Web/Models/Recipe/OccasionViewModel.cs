namespace TasteIt.Web.Models.Recipe
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;

    public class OccasionViewModel : IMapFrom<Occasion>
    {
        //private ICollection<RecipeViewModel> recipes;
        //
        //public OccasionViewModel()
        //{
        //    this.recipes = new HashSet<RecipeViewModel>();
        //}
        //
        //public int Id { get; set; }
        //
        //[Required]
        //[Index(IsUnique = true)]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        //public string Name { get; set; }
        //
        //public virtual ICollection<RecipeViewModel> Recipies
        //{
        //    get { return this.recipes; }
        //    set { this.recipes = value; }
        //}
    }
}
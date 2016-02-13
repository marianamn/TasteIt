namespace TasteIt.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Occasion
    {
        private ICollection<Recipe> recipes;

        public Occasion()
        {
            this.recipes = new HashSet<Recipe>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipies
        {
            get { return this.recipes; }
            set { this.recipes = value; }
        }
    }
}

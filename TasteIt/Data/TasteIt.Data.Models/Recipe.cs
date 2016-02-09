namespace TasteIt.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Recipe
    {
        private ICollection<Ingredient> ingredients;

        private ICollection<Like> likes;

        public Recipe()
        {
            this.ingredients = new HashSet<Ingredient>();
            this.likes = new HashSet<Like>();
        }

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

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        [Required]
        public int OccasionId { get; set; }

        [ForeignKey("OccasionId")]
        public virtual Occasion Occasion { get; set; }

        public virtual ICollection<Ingredient> Ingredients
        {
            get { return this.ingredients; }
            set { this.ingredients = value; }
        }

        public virtual ICollection<Like> Likes
        {
            get { return this.likes; }
            set { this.likes = value; }
        }
    }
}

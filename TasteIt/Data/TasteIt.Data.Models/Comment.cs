namespace TasteIt.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}

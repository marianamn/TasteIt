namespace TasteIt.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Like
    {
        public int Id { get; set; }

        public LikeType Value { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}

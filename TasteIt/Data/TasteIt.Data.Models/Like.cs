﻿namespace TasteIt.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Like
    {
        public int Id { get; set; }

        public LikeType Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}

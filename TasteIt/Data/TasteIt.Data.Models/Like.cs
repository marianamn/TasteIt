﻿namespace TasteIt.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Like : BaseModel<int>
    {
        public bool Value { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}

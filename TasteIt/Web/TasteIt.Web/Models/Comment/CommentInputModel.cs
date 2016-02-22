namespace TasteIt.Web.Models.Comment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class CommentInputModel
    {
        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Content { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string AuthorId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string RecipeId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime CreatedOn { get; set; }
    }
}
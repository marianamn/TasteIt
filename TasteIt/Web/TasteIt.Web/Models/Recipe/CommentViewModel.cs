namespace TasteIt.Web.Models.Recipe
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;

    public class CommentViewModel : IMapFrom<Comment>
    {
        //public int Id { get; set; }
        //
        //[Required]
        //[StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        //public string Content { get; set; }
        //
        //public string PostedById { get; set; }
        //
        //[ForeignKey("PostedById")]
        //public virtual UserViewModel PostedBy { get; set; }
    }
}
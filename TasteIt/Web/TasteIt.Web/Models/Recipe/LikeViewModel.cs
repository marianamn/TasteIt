namespace TasteIt.Web.Models.Recipe
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Infrastructure.Mapping;
    using TasteIt.Data.Models;

    public class LikeViewModel : IMapFrom<Like>
    {
       //public int Id { get; set; }
       //
       //public bool Value { get; set; }
       //
       //public string AuthorId { get; set; }
       //
       //[ForeignKey("AuthorId")]
       //public virtual UserViewModel Author { get; set; }
    }
}
namespace TasteIt.Web.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using TasteIt.Web.Infrastructure.Mapping;

    public class UserDetailsViewModel : IMapFrom<TasteIt.Data.Models.User>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImageURL { get; set; }
    }
}
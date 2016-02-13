namespace TasteIt.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginConfirmationViewModel
    {
        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
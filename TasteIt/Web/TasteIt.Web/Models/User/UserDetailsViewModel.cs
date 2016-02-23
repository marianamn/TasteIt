using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TasteIt.Web.Infrastructure.Mapping;

namespace TasteIt.Web.Models.User
{
    public class UserDetailsViewModel: IMapFrom<TasteIt.Data.Models.User>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImageURL { get; set; }

    }
}
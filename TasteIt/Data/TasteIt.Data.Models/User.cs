namespace TasteIt.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<Recipe> recipes;

        private ICollection<Article> articles;

        private ICollection<Comment> comments;

        public User()
        {
            this.recipes = new HashSet<Recipe>();
            this.articles = new HashSet<Article>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string ImageURL { get; set; }


        public virtual ICollection<Recipe> Recipes
        {
            get { return this.recipes; }

            set { this.recipes = value; }
        }

        public virtual ICollection<Article> Articles
        {
            get { return this.articles; }

            set { this.articles = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }

            set { this.comments = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}

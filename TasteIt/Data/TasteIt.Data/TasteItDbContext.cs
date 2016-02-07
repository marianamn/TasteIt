namespace TasteIt.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class TasteItDbContext : IdentityDbContext<User>, ITasteItDbContext
    {
        public TasteItDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Occasion> Occasions { get; set; }

        public IDbSet<Recipe> Recipes { get; set; }

        public IDbSet<Ingredient> Ingredients { get; set; }

        public IDbSet<Like> Likes { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Article> Articles { get; set; }

        public static TasteItDbContext Create()
        {
            return new TasteItDbContext();
        }
    }
}

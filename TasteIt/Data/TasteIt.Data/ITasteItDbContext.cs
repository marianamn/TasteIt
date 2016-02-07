namespace TasteIt.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TasteIt.Data.Models;

    public interface ITasteItDbContext
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Occasion> Occasions { get; set; }

        IDbSet<Recipe> Recipes { get; set; }

        IDbSet<Ingredient> Ingredients { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Article> Articles { get; set; }

        DbSet<TEntry> Set<TEntry>() where TEntry : class;

        DbEntityEntry<TEntry> Entry<TEntry>(TEntry entity) where TEntry : class;
    }
}

namespace TasteIt.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface ITasteItDbContext
    {
        IDbSet<Occasion> Occasions { get; set; }

        IDbSet<Recipe> Recipes { get; set; }

        IDbSet<Ingredient> Ingredients { get; set; }

        IDbSet<Like> Likes { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Article> Articles { get; set; }

        int SaveChanges();

        void Dispose();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}

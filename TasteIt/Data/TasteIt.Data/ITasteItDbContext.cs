namespace TasteIt.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using TasteIt.Data.Models;

    public interface ITasteItDbContext
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        //TODO: Add models
     
        DbSet<TEntry> Set<TEntry>() where TEntry : class;

        DbEntityEntry<TEntry> Entry<TEntry>(TEntry entity) where TEntry : class;
    }
}

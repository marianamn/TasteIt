namespace TasteIt.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TasteItDbContext : IdentityDbContext<User>, ITasteItDbContext
    {
        public TasteItDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //TODO: Add models

        public static TasteItDbContext Create()
        {
            return new TasteItDbContext();
        }
    }
}
